using EdCommerce.Domain.Models;
using Shopping.API.Domain.Models;
using Shopping.API.Domain.Models.Request;

namespace Shopping.API.Application.Services.Interfaces
{
    public interface ICarrinhoService
    {
        Task<Carrinho?> GetCarrinhoPorIdAsync(int idCarrinho);
        // Task<int> CriaCarrinho();
        //Task<Cart> CreateCartAsync(CartRequest shoppingCartRequest);
        Task<bool> RemoveProdutoCarrinhoAsync(int idCarrinho, int produtoId);
        //Task<Product?> GetProductByIdAsync(int id);
        //Task<decimal> GetCartTotalAsync(int cartId);
        //Task<Product> AddProductToCartAsync(int cartId, Product product);
        //Task<bool> UpdateProductInCartAsync(int productId, Product product);
        //Task<bool> RemoveProductFromCartAsync(int productId);
        //Task<bool> ApplyDiscountAsync(int cartId, decimal discountPercentage);
    }
}
