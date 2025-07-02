using EdCommerce.Domain.Models;
using Shopping.API.Domain.Models;
using Shopping.API.Domain.Models.Request;

namespace Shopping.API.Infrastructure.Repositories.Interfaces
{
    public interface ICarrinhoRepository
    {
        Task<Carrinho?> GetCarrinhoPorIdAsync(int idCarrinho);
        //Task<Cart> CreateAsync(CartRequest cartRequest);
        //Task<bool> UpdateCartDiscountPercentage(Cart cart);
        //Task<bool> DeleteAsync(int cartId);
        //Task<Product?> GetProductByIdAsync(int productId);
        //Task AddProductAsync(Product product);
        //Task<bool> UpdateProductAsync(Product product);
        //Task<bool> RemoveProductAsync(int productId);
    }
}
