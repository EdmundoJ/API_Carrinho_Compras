namespace EdCommerce.Domain.Models
{
    public class Carrinho
    {
        public Carrinho(int idCarrinho, string cpf, DateTime? dataCriacao = null )
        {
            IdCarrinho = idCarrinho;
            CPF = cpf;
            DataCriacao = dataCriacao ?? DateTime.UtcNow;
            SubTotal = 0;
        }
        public int IdCarrinho { get; set; }
        public string CPF { get; set; }
        public DateTime? DataCriacao { get; set; }

        public decimal SubTotal { get; set; }

        private List<ItensCarrinho> _itemCarrinho = new List<ItensCarrinho>();
        public List<ItensCarrinho> ItensCarrinho
        {
            get => _itemCarrinho;
            set => _itemCarrinho = value ?? new List<ItensCarrinho>();
        }

        private List<Produto> _produtos = new List<Produto>();
        public List<Produto> Produtos
        {
            get => _produtos;
            set => _produtos = value ?? new List<Produto>();
        }
       
    }
}
