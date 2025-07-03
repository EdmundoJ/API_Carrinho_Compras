namespace EdCommerce.Domain.Models.Request
{
    public class ItemRequest
    {
       
        public int IdItem { get; set; } 
        public int IdProd { get; set; }
        public int QuantidadeProd { get; set; }

        public ItemRequest(int item, int idProd, int quantidadeProd)
        {
            IdItem = item;
            IdProd = idProd;
            QuantidadeProd = quantidadeProd;
        }
    }    
}
