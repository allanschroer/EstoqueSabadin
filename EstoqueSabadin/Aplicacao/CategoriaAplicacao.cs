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

        public void Cadastrar(int id, string nome, SituacaoEnum situacao)
        {
            _categoriaModelo.Add(new CategoriaModelo
            {
                Id = id,
                Nome = nome,
                Situacao = situacao
            });
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

        public void Editar(CategoriaModelo categoriaModelo, int id)
        {
            var categoria = BuscarCategoriaPorId(id);
            if(categoria != null)
            {
                categoria.Nome = categoriaModelo.Nome;
                categoria.Situacao = categoriaModelo.Situacao;
            }
        }

        public List<CategoriaModelo> ObterCategorias()
        {
            return _categoriaModelo;
        }

        public void ExibirListaCategorias()
        {
            if(_categoriaModelo.Count > 0)
            {
                for (var i = 0; i < _categoriaModelo.Count; i++)
                {
                    Console.WriteLine($"Categoria {i+1}\nID: {_categoriaModelo[i].Id}, " +
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
