using EdCommerce.Domain.Models;
using EdCommerce.Domain.Models.Request;
using Shopping.API.Domain.Models;
using Shopping.API.Domain.Models.Request;

namespace Shopping.API.Infrastructure.Repositories.Interfaces
{
    public interface ICarrinhoRepository
    {
        Task<Carrinho?> GetCarrinhoPorIdAsync(int idCarrinho);
        Task<Carrinho> CriarCarrinhoAsync(CarrinhoRequest carrinho);
        //Task<bool> UpdateCartDiscountPercentage(Cart cart);
        Task<bool> DeleteItemAsync(int idCarrinho, int produtoId);
        //Task<Product?> GetProductByIdAsync(int productId);
        //Task AddProductAsync(Product product);
        //Task<bool> UpdateProductAsync(Product product);
        //Task<bool> RemoveProductAsync(int productId);
    }
}
