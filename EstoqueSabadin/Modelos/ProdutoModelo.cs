using EstoqueSabadin.Enum;

namespace EstoqueSabadin.Classes
{
    public class ProdutoModelo
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int QteEstoque { get; set; }
        public int QteEstoqueMinimo { get; set; }
        public decimal Valor { get; set; }
        public decimal ValorPromocional { get; set; }
        public SituacaoEnum Situacao { get; set; }

    }
}
