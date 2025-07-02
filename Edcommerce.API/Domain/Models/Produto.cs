namespace EdCommerce.Domain.Models
{
    public class Produto
    {
       public int idProd { get; set; }
       public string? Nome { get; set; }
       public decimal Preco { get; set; }
       public int QuantidadeProd { get; set; }
    }
}
