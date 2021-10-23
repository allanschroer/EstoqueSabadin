using EstoqueSabadin.Classes;
using EstoqueSabadin.Enum;
using System.Collections.Generic;

namespace EstoqueSabadin.Aplicacao
{
    public class ProdutoAplicacao
    {
        private List<ProdutoModelo> _produtoModelo;

        public ProdutoAplicacao(List<ProdutoModelo> produtoModelo)
        {
            _produtoModelo = produtoModelo;
        }


        public void Cadastrar(string nome, int qtdEstoque, decimal valor, SituacaoEnum situacao)
        {
            _produtoModelo.Add(new ProdutoModelo(nome, qtdEstoque, valor, situacao));
        }

        public void AdicionarEstoque(int quantidade, int id)
        {
            var produto = ObterProdutoId(id);
        }

        private ProdutoModelo ObterProdutoId(int id)
        {
            return _produtoModelo.Find(a => a.Id == id);
        }
    }
}
