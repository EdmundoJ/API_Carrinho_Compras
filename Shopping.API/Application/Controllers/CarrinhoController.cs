﻿using EdCommerce.Domain.Models;
using EdCommerce.Domain.Models.Request;
using Microsoft.AspNetCore.Mvc;
using Shopping.API.Application.Services.Interfaces;

namespace Shopping.API.Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class CarrinhoController : ControllerBase
    {
        private readonly ICarrinhoService _carrinhoService;
        private readonly ILogger<CarrinhoController> _logger;

        public CarrinhoController(ICarrinhoService carrinhoService, ILogger<CarrinhoController> logger)
        {
            _carrinhoService = carrinhoService;
            _logger = logger;
        }

        [HttpPost("/carrinhos", Name = "CriaCarrinho")]
        [ProducesResponseType(typeof(Carrinho), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CriaCarinho([FromBody] CarrinhoRequest carrinho)
        {
            var resultado = await _carrinhoService.CriaCarrinho(carrinho);
            return Created("api/carrinhos",resultado);
        }

        [HttpGet("/carrinhos/{idCarrinho}", Name = "RetornaItensTotalById")]
        [ProducesResponseType(typeof(Carrinho), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetCart(int idCarrinho)
        {
            var cart = await _carrinhoService.GetCarrinhoPorIdAsync(idCarrinho);
            if (cart == null)
            {
                _logger.LogWarning("Cart not found - ID: {carrinhoId}", idCarrinho);
                return NotFound("Cart not found");
            }
            return Ok(cart);
        }


        [HttpDelete("carrinhos/{idCarrinho}/itens{produtoId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> RemoveProdutoCarrinho(int idCarrinho, int produtoId)
        {
            await _carrinhoService.RemoveProdutoCarrinhoAsync(idCarrinho, produtoId);
            return NoContent();
        }

        [HttpPost("/carrinhos/{idCarrinho}/itens", Name = "AdicionaItem")]
        [ProducesResponseType(typeof(ItensCarrinho), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public  void  AdicionaItem( int idCarrinho, int idProd, int quantidadeProd)
        {
               _carrinhoService.AdicionaItem(idCarrinho, idProd,  quantidadeProd);
        }


    }
}
