namespace EdCommerce.Domain.Models.Request
{
    public class ItemRequest
    {
       
        public int IdItem { get; set; } 
        public int IdProd { get; set; }
        public int QuantidadeProd { get; set; }
        public int IdCarrinho { get; set; }

        public ItemRequest(int item, int idProd, int quantidadeProd, int idCarrinho)
        {
            IdItem = item;
            IdProd = idProd;
            QuantidadeProd = quantidadeProd;
            IdCarrinho = idCarrinho;

        }
    }    
}
