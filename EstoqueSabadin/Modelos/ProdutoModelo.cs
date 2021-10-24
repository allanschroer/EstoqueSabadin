using EstoqueSabadin.Enum;
using EstoqueSabadin.Modelos;

namespace EstoqueSabadin.Classes
{
    public class ProdutoModelo
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public int QteEstoque { get; private set; }
        public int QteEstoqueMinimo { get; private set; }
        public decimal Valor { get; private set; }
        public decimal ValorPromocional { get; private set; }
        public SituacaoEnum Situacao { get; private set; }
        public virtual CategoriaModelo Categoria { get; private set; }

        public ProdutoModelo(string nome, int qteEstoque, decimal valor, SituacaoEnum situacao, CategoriaModelo categoria)
        {
            Id = Id++;
            Nome = nome;
            QteEstoque = qteEstoque;
            Valor = valor;
            Situacao = situacao;
            Categoria = categoria;
        }

        public void Atualizar(string nome, decimal valor, SituacaoEnum situacao, CategoriaModelo categoria)
        {
            Nome = nome;
            Valor = valor;
            Situacao = situacao;
            Categoria = categoria;
        }
    }
}
