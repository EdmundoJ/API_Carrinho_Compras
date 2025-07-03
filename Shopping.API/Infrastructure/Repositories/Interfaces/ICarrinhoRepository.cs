using EdCommerce.Domain.Models;
using EdCommerce.Domain.Models.Request;

namespace Shopping.API.Infrastructure.Repositories.Interfaces
{
    public interface ICarrinhoRepository
    {
        Task<Carrinho?> GetCarrinhoPorIdAsync(int idCarrinho);
        Task<Carrinho> CriarCarrinhoAsync(CarrinhoRequest carrinho);
        void AdicionaItem(int idCarrinho, int idProd, int quantidadeProd);
        Task<bool> DeleteItemAsync(int idCarrinho, int produtoId);
    }
}
