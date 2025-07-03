// CartRepository.cs
using Dapper;
using EdCommerce.Domain.Models;
using EdCommerce.Domain.Models.Request;
using Shopping.API.Infrastructure.Data.Interfaces;
using Shopping.API.Infrastructure.Repositories.Interfaces;

namespace Shopping.API.Infrastructure.Repositories
{
    public class CarrinhoRepository : ICarrinhoRepository
    {
        private readonly IDbContext _dbContext;

        public CarrinhoRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Carrinho?> GetCarrinhoPorIdAsync(int idCarrinho)
        {
            using var connection = _dbContext.CreateConnection();

            var carrinho = await connection.QueryFirstOrDefaultAsync<Carrinho>(
                "SELECT * FROM Carrinho WHERE IdCarrinho = @idCarrinho",
                new { idCarrinho = idCarrinho });

            if (carrinho == null)
                return null;

             var itensCar = (List<ItensCarrinho>)await connection.QueryAsync<ItensCarrinho>(
                "SELECT * FROM ItensCarrinho WHERE IdCarrinho = @idCarrinho",
                new { IdCarrinho = idCarrinho });

            decimal calculoValorTotal = 0;
            foreach (var item in itensCar)
            {
               carrinho.ItensCarrinho = itensCar.ToList();


                string idProduto = item.IdProd.ToString();
                var produtoCarrinho = await connection.QueryAsync<Produto>(
                 $"SELECT * FROM Produto WHERE idProd = {idProduto}",
                 new { idProd = idProduto });

                foreach (var prod in produtoCarrinho)
                {
                    calculoValorTotal = calculoValorTotal + (prod.Preco * item.QuantidadeProd);
                }
               

                carrinho.Produtos.AddRange(produtoCarrinho.ToList());
                
            }
            carrinho.SubTotal = calculoValorTotal;

            return carrinho;
        }

        public async Task<bool> DeleteItemAsync(int idCarrinho, int produtoId)
        {
            using var connection = _dbContext.CreateConnection();
            connection.Open();
            using var transaction = connection.BeginTransaction();

            try
            {
                
                var affectedRows = await connection.ExecuteAsync(
                    "DELETE FROM ItensCarrinho WHERE IdProd = @produtoId AND IdCarrinho = @idCarrinho",
                    new { produtoId = produtoId, IdCarrinho = idCarrinho },
                    transaction);


                transaction.Commit();

                return affectedRows > 0;
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        public async Task<Carrinho> CriarCarrinhoAsync(CarrinhoRequest carrinho)
        {
            using var connection = _dbContext.CreateConnection();
            connection.Open();
            using var transaction = connection.BeginTransaction();

            try
            {         
            var id = await connection.QuerySingleAsync<int>(
                    @"INSERT INTO Carrinho (CPF, DataCriacao) 
                      VALUES (@cpf, @dataCriacao);
                      SELECT CAST(SCOPE_IDENTITY() AS INT);"
                ,
                new { cpf = carrinho.Cpf, dataCriacao = carrinho.DataCriacao },
                transaction);
                transaction.Commit();

                return new Carrinho(id, carrinho.Cpf, carrinho.DataCriacao);
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        public void  AdicionaItem(ItemRequest itensCarrinho , int carrinhoId)
        {
            using var connection = _dbContext.CreateConnection();
            connection.Open();
            using var transaction = connection.BeginTransaction();

            try
            {
                var id =  connection.QuerySingleAsync<int>(
                    @"INSERT INTO ItemCarrinho ( IdProd, QuantidadeProd, IdCarrinho) 
                          VALUES (@idProd, @quantidadeProd, @idCarrinho);
                          SELECT CAST(SCOPE_IDENTITY() AS INT);",
                    
                    new { idProd = itensCarrinho.IdProd,  quantidadeProd = itensCarrinho.QuantidadeProd,  idCarrinho = carrinhoId},
                    transaction);

                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }
    }
}