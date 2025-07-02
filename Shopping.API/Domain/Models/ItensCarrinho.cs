namespace EdCommerce.Domain.Models
{
    public class ItensCarrinho
    {
        public int IdItem { get; set; }
        public int IdProd { get; set; }
        public int QuantidadeProd { get; set; }
        public int IdCarrinho { get; set; }
    }
}
