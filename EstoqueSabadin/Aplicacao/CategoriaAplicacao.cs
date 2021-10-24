using EstoqueSabadin.Enum;
using EstoqueSabadin.Modelos;
using System;
using System.Collections.Generic;

namespace EstoqueSabadin.Aplicacao
{
    public class CategoriaAplicacao
    {
        private List<CategoriaModelo> _categoriaModelo = new List<CategoriaModelo>();

        public CategoriaAplicacao(List<CategoriaModelo> categoriaModelo)
        {
            _categoriaModelo = categoriaModelo;
        }

        public CategoriaAplicacao()
        {
        }

        public void Cadastrar(string nome, SituacaoEnum situacao)
        {
            _categoriaModelo.Add(new CategoriaModelo(nome, situacao));
        }

        public void Excluir(int id)
        {
            _categoriaModelo.Remove(_categoriaModelo.Find(a => id == a.Id));
        }

        public CategoriaModelo BuscarCategoriaPorId(int id)
        {
            try
            {
                return _categoriaModelo.Find(a => id == a.Id);
            }
            catch
            {
                return null;
            }
        }

        public void Editar(string nome, SituacaoEnum situacao, int id)
        {
            var categoria = BuscarCategoriaPorId(id);
            Console.WriteLine(categoria.ToString());

            if (categoria != null)
                categoria.Atualizar(nome, situacao);
        }

        public List<CategoriaModelo> ObterCategorias()
        {
            return _categoriaModelo;
        }

        public bool ExisteAlgumaCategoria()
        {
            if (_categoriaModelo.Count > 0)
                return true;

            return false;
        }

        public void ExibirListaCategorias()
        {
            if (_categoriaModelo.Count > 0)
            {
                for (var i = 0; i < _categoriaModelo.Count; i++)
                {
                    Console.WriteLine($"Categoria {i + 1}\nID: {_categoriaModelo[i].Id}, " +
                        $"Nome da categoria: {_categoriaModelo[i].Nome}, " +
                        $"Situacão: {_categoriaModelo[i].Situacao}\n");
                }
            }
            else
            {
                Console.WriteLine("Não há categorias cadastradas.");
            }
        }

    }
}
