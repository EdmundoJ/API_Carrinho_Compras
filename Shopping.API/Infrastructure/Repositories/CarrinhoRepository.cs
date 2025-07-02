// CartRepository.cs
using Dapper;
using EdCommerce.Domain.Models;
using EdCommerce.Domain.Models;
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
                new { IdCarrinho = idCarrinho });

            if (carrinho == null)
                return null;

             var itensCar = (List<ItensCarrinho>)await connection.QueryAsync<ItensCarrinho>(
                "SELECT * FROM ItensCarrinho WHERE IdCarrinho = @idCarrinho",
                new { IdCarrinho = idCarrinho });

            foreach (var item in itensCar)
            {
                carrinho.ItensCarrinho = itensCar.ToList();
            }

            foreach (var item in itensCar)
            {
                string idProduto = item.IdProd.ToString();
                var produtoCarrinho = await connection.QueryAsync<Produto>(
                 $"SELECT * FROM Produto WHERE idProd = {idProduto}",
                 new { idProd = idProduto });

                carrinho.Produtos.AddRange(produtoCarrinho.ToList());
            }


            return carrinho;
        }

        //public async Task<Carrinho> AdicionaItemAoCarrinho(ItensCarrinho itemRequest)
        //{
        //    using var connection = _dbContext.CreateConnection();
        //    connection.Open();
        //    using var transaction = connection.BeginTransaction();

        //    try
        //    {
        //        var id = await connection.QuerySingleAsync<int>(
        //            @"INSERT INTO Carrinho (, CreatedAt) 
        //              VALUES (@PayerDocument, @CreatedAt);
        //              SELECT CAST(SCOPE_IDENTITY() AS INT);",
        //            new { ite, cartRequest.CreatedAt },
        //            transaction);

        //        transaction.Commit();

        //        return new Carrinho();//(id, cartRequest.PayerDocument, 0, cartRequest.CreatedAt);
        //    }
        //    catch
        //    {
        //        transaction.Rollback();
        //        throw;
        //    }
        //}

        //public async Task<bool> UpdateCartDiscountPercentage(Carrinho carrinho)
        //{
        //    using var connection = _dbContext.CreateConnection();
        //    connection.Open();
        //    using var transaction = connection.BeginTransaction();
        //    try
        //    {
        //        var affectedRows = await connection.ExecuteAsync(
        //            "UPDATE Cart SET DiscountPercentage = @DiscountPercentage WHERE CartId = @CartId",
        //            new { carrinho., carrinho.IdCarrinho},
        //            transaction);
        //        transaction.Commit();

        //        return affectedRows > 0;
        //    }
        //    catch
        //    {
        //        transaction.Rollback();
        //        throw;
        //    }
        //}

        public async Task<bool> DeleteItemAsync(int idCarrinho, int produtoId)
        {
            using var connection = _dbContext.CreateConnection();
            connection.Open();
            using var transaction = connection.BeginTransaction();

            try
            {
                
                var affectedRows = await connection.ExecuteAsync(
                    "DELETE FROM ItensCarrinho WHERE IdProd = @produtoId AND IdCarrinho = @idCarrinho",
                    new { IdProd = produtoId, IdCarrinho = idCarrinho },
                    transaction);

                //var affectedRows = await connection.ExecuteAsync(
                //    "DELETE FROM Cart WHERE CartId = @CartId",
                //    new { CartId = cartId },
                //    transaction);

                transaction.Commit();

                return affectedRows > 0;
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

       

        //public async Task<Product?> GetProductByIdAsync(int productId)
        //{
        //    using var connection = _dbContext.CreateConnection();
        //    return await connection.QueryFirstOrDefaultAsync<Product>(
        //        "SELECT * FROM Product WHERE ProductId = @ProductId",
        //        new { ProductId = productId });
        //}

        //public async Task AddProductAsync(Product product)
        //{
        //    using var connection = _dbContext.CreateConnection();
        //    connection.Open();
        //    using var transaction = connection.BeginTransaction();

        //    try
        //    {
        //        var existingProduct = await connection.QueryFirstOrDefaultAsync<Product>(
        //            "SELECT * FROM Product WHERE CartId = @CartId AND ProductName = @ProductName",
        //            new { product.CartId, product.ProductName },
        //            transaction);

        //        if (existingProduct != null)
        //        {
        //            throw new InvalidOperationException("This product already exists in the cart.");
        //        }

        //        await connection.ExecuteAsync(
        //            @"INSERT INTO Product (CartId, ProductName, Quantity, Price)
        //              VALUES (@CartId, @ProductName, @Quantity, @Price)",
        //            product,
        //            transaction);

        //        transaction.Commit();
        //    }
        //    catch
        //    {
        //        transaction.Rollback();
        //        throw;
        //    }
        //}

        //public async Task<bool> UpdateProductAsync(Product product)
        //{
        //    using var connection = _dbContext.CreateConnection();
        //    connection.Open();
        //    using var transaction = connection.BeginTransaction();

        //    try
        //    {
        //        var affectedRows = await connection.ExecuteAsync(
        //            @"UPDATE Product 
        //              SET ProductName = @ProductName, 
        //                  Quantity = @Quantity, 
        //                  Price = @Price
        //              WHERE ProductId = @ProductId",
        //            product,
        //            transaction);

        //        transaction.Commit();

        //        return affectedRows > 0;
        //    }
        //    catch
        //    {
        //        transaction.Rollback();
        //        throw;
        //    }
        //}

        //public async Task<bool> RemoveProductAsync(int productId)
        //{
        //    using var connection = _dbContext.CreateConnection();
        //    connection.Open();
        //    using var transaction = connection.BeginTransaction();

        //    try
        //    {
        //        var affectedRows = await connection.ExecuteAsync(
        //            "DELETE FROM Product WHERE ProductId = @ProductId",
        //            new { ProductId = productId },
        //            transaction);

        //        transaction.Commit();

        //        return affectedRows > 0;
        //    }
        //    catch
        //    {
        //        transaction.Rollback();
        //        throw;
        //    }
        //}
    }
}