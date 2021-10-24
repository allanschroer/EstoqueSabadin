using EstoqueSabadin.Classes;
using EstoqueSabadin.Enum;
using EstoqueSabadin.Modelos;
using System;
using System.Collections.Generic;

namespace EstoqueSabadin.Aplicacao
{
    public class ProdutoAplicacao
    {
        private List<ProdutoModelo> _produtoModelo = new List<ProdutoModelo>();

        public ProdutoAplicacao(List<ProdutoModelo> produtoModelo)
        {
            _produtoModelo = produtoModelo;
        }

        public ProdutoAplicacao()
        {
        }

        public void Cadastrar(string nome, int qtdEstoque, decimal valor, SituacaoEnum situacao, CategoriaModelo categoria)
        {
            _produtoModelo.Add(new ProdutoModelo(nome, qtdEstoque, valor, situacao, categoria));
        }

        public void AdicionarEstoque(int quantidade, int id)
        {
            var produto = ObterProdutoId(id);
        }

        public void AtualizarProduto(int id, string nome, decimal valor, SituacaoEnum situacao, CategoriaModelo categoria)
        {
            var produto = ObterProdutoId(id);

            produto.Atualizar(nome, valor, situacao, categoria);
        }

        public ProdutoModelo ObterProdutoId(int id)
        {
            return _produtoModelo.Find(a => a.Id == id);
        }

        internal void ExibirProdutos()
        {
            if(_produtoModelo.Count > 0)
            {
                for (var i = 0; i < _produtoModelo.Count; i++)
                {
                    Console.WriteLine($"Produto {i + 1}:\n" +
                        $"Nome: {_produtoModelo[i].Nome}\n" +
                        $"Quantidade em estoque: {_produtoModelo[i].QteEstoque}\n" +
                        $"Valor de venda: {_produtoModelo[i].Valor}");
                }
            }
            else
            {
                Console.WriteLine("Não existem produtos cadastrados.");
            }
        }

        public bool PossiuAlgumCadastro()
        {
            if (_produtoModelo.Count > 0)
                return true;

            return false;
        }
    }
}
