using Shopping.API.Infrastructure.Repositories.Interfaces;
using Shopping.API.Application.Services.Interfaces;
using EdCommerce.Domain.Models;
using EdCommerce.Domain.Models.Request;

namespace Shopping.API.Application.Services
{
    public class CarrinhoService : ICarrinhoService
    {
        private readonly ICarrinhoRepository _carrinhoRepository;
        //private readonly ICacheService _cacheService;
        private readonly ILogger<CarrinhoService> _logger;

        public CarrinhoService(
            ICarrinhoRepository carrinhoRepository,
           // ICacheService cacheService,
            ILogger<CarrinhoService> logger)
        {
            _carrinhoRepository = carrinhoRepository;
           // _cacheService = cacheService;
            _logger = logger;
        }
       

        public void  AdicionaItem(ItemRequest itensCarrinho, int carrinhoId)
        {
             _carrinhoRepository.AdicionaItem(itensCarrinho, carrinhoId);
        }

        public Task<Carrinho> CriaCarrinho(CarrinhoRequest carrinho)
        {
            return _carrinhoRepository.CriarCarrinhoAsync(carrinho);
        }

        public async Task<Carrinho?> GetCarrinhoPorIdAsync(int idCarrinho)
        {
            if (idCarrinho <= 0)
                throw new ArgumentException("Carrinho não encontrado.");

            var carrinho = await _carrinhoRepository.GetCarrinhoPorIdAsync(idCarrinho);

            if (carrinho == null)
                return null;

            return carrinho;
        }

        public async Task<bool> RemoveProdutoCarrinhoAsync(int idCarrinho, int produtoId)
        {
            if (produtoId <= 0 || idCarrinho <=0)
                throw new ArgumentException("Id de Produto ou id Carrinho inválido.");

            return await _carrinhoRepository.DeleteItemAsync(idCarrinho, produtoId);
        }
       
    }
}