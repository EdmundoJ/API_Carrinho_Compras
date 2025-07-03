namespace EdCommerce.Domain.Models.Request
{
    public class ItemRequest
    {
        public int IdProd { get; set; }
        public int QuantidadeProd { get; set; }

        public ItemRequest(int item, int idProd, int quantidadeProd)
        {
            IdProd = idProd;
            QuantidadeProd = quantidadeProd;
        }
    }    
}
