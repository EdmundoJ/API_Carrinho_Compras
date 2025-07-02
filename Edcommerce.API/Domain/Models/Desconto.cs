namespace EdCommerce.Domain.Models
{
    public class Desconto
    {   int Id { get; set; }
        int IdCarrinho { get; set; }
        decimal ValorDesconto { get; set; }
    }
}
