using Shopping.API.Infrastructure.Repositories.Interfaces;
using Shopping.API.Domain.Models;
using Shopping.API.Domain.Models.Request;
using Shopping.API.Application.Services.Interfaces;
using EdCommerce.Domain.Models;

namespace Shopping.API.Application.Services
{
    public class CarrinhoService : ICarrinhoService
    {
        private readonly ICarrinhoRepository _carrinhoRepository;
        private readonly ICacheService _cacheService;
        private readonly ILogger<CarrinhoService> _logger;

        public CarrinhoService(
            ICarrinhoRepository carrinhoRepository,
            ICacheService cacheService,
            ILogger<CarrinhoService> logger)
        {
            _carrinhoRepository = carrinhoRepository;
            _cacheService = cacheService;
            _logger = logger;
        }

        public async Task<Carrinho?> GetCarrinhoPorIdAsync(int idCarrinho)
        {
            if (idCarrinho <= 0)
                throw new ArgumentException("Carrinho não encontrado.");

            var carrinho = await _carrinhoRepository.GetCarrinhoPorIdAsync(idCarrinho);

            if (carrinho == null)
                return null;

            //if (carrinho.Amount <= 0)
            //{
            //    carrinho.Amount = await GetCartTotalAsync(id);
            //}

            return carrinho;
        }

       

        //public async Task<Cart> CreateCartAsync(CartRequest cartRequest)
        //{
        //    if (cartRequest == null || string.IsNullOrWhiteSpace(cartRequest.PayerDocument))
        //        throw new ArgumentException("cartRequest cannot be null and PayerDocument is required.");

        //    return await _carrinhoRepository.CreateAsync(cartRequest);
        //}

        //public async Task<bool> DeleteCartAsync(int id)
        //{
        //    if (id <= 0)
        //        throw new ArgumentException("Invalid cart ID.");

        //    var existingCart = await _carrinhoRepository.GetByIdAsync(id);
        //    if (existingCart == null)
        //        return false;

        //    return await _carrinhoRepository.DeleteAsync(id);
        //}

        //public async Task<Product?> GetProductByIdAsync(int id)
        //{
        //    if (id <= 0)
        //        throw new ArgumentException("Invalid product ID.");

        //    return await _carrinhoRepository.GetProductByIdAsync(id);
        //}

        //public async Task<decimal> GetCartTotalAsync(int cartId)
        //{
        //    var cachedTotal = await _cacheService.GetCachedCartTotalAsync(cartId);
        //    if (cachedTotal.HasValue)
        //    {
        //        _logger.LogInformation("Retrieved cart {CartId} total from cache", cartId);
        //        return cachedTotal.Value;
        //    }

        //    var carrinho = await _carrinhoRepository.GetByIdAsync(cartId);
        //    if (carrinho == null)
        //    {
        //        throw new KeyNotFoundException($"Cart with ID {cartId} not found");
        //    }

        //    if (carrinho.Produtos.Count() <= 0)
        //        return 0;

        //    var total = carrinho.Produtos.Sum(p => p.Preco * p.Quantidade) * (1 - carrinho.DiscountPercentage / 100);

        //    await _cacheService.CacheCartTotalAsync(cartId, total);
        //    _logger.LogInformation("Calculated and cached cart {CartId} total", cartId);

        //    return total;
        //}

        //public async Task<Product> AddProductToCartAsync(int cartId, Product product)
        //{
        //    if (cartId <= 0 || product == null)
        //        throw new ArgumentException("Invalid cart ID or product cannot be null.");

        //    product.CartId = cartId;
        //    await _carrinhoRepository.AddProductAsync(product);
        //    await _cacheService.InvalidateCartTotalCacheAsync(cartId);
        //    return product;
        //}

        //public async Task<bool> UpdateProductInCartAsync(int productId, Product product)
        //{
        //    if (product == null || productId <= 0 || product.CartId <= 0)
        //        throw new ArgumentException("Invalid product ID, cart ID, or product cannot be null.");

        //    var existingProduct = await _carrinhoRepository.GetProductByIdAsync(productId);
        //    if (existingProduct == null)
        //        return false;

        //    if (existingProduct.CartId != product.CartId)
        //        throw new InvalidOperationException("Product does not belong to the specified cart.");

        //    await _cacheService.InvalidateCartTotalCacheAsync(product.CartId);
        //    return await _carrinhoRepository.UpdateProductAsync(product);
        //}

        //public async Task<bool> RemoveProductFromCartAsync(int productId)
        //{
        //    if (productId <= 0)
        //        throw new ArgumentException("Invalid product ID.");

        //    var existingProduct = await _carrinhoRepository.GetProductByIdAsync(productId);
        //    if (existingProduct == null)
        //        return false;

        //    await _cacheService.InvalidateCartTotalCacheAsync(existingProduct.CartId);
        //    return await _carrinhoRepository.RemoveProductAsync(productId);
        //}

        //public async Task<bool> ApplyDiscountAsync(int cartId, decimal discountPercentage)
        //{
        //    if (discountPercentage < 0 || discountPercentage > 50)
        //        throw new ArgumentException("Discount percentage must be between 0 and 50.");
        //    var cart = await _carrinhoRepository.GetByIdAsync(cartId);
        //    if (cart == null) throw new ArgumentException($"Cart with ID {cartId} not found");

        //    cart.DiscountPercentage = discountPercentage;
        //    await _cacheService.InvalidateCartTotalCacheAsync(cartId);

        //    return await _carrinhoRepository.UpdateCartDiscountPercentage(cart);
        //}
    }
}