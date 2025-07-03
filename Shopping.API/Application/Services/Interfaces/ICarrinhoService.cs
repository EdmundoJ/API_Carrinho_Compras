using EdCommerce.Domain.Models;
using EdCommerce.Domain.Models.Request;

namespace Shopping.API.Application.Services.Interfaces
{
    public interface ICarrinhoService
    {
        Task<Carrinho?> GetCarrinhoPorIdAsync(int idCarrinho);
        Task<Carrinho> CriaCarrinho(CarrinhoRequest carrinho);
        void  AdicionaItem(ItemRequest itensCarrinho);
        Task<bool> RemoveProdutoCarrinhoAsync(int idCarrinho, int produtoId);
        
    }
}
