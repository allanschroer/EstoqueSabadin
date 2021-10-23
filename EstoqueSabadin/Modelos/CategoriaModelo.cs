using EstoqueSabadin.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstoqueSabadin.Modelos
{
    public class CategoriaModelo
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public SituacaoEnum Situacao { get; private set; }

        public CategoriaModelo(string nome, SituacaoEnum situacao)
        {
            Id = Id++;
            Nome = nome;
            Situacao = situacao;
        }

        public void Atualizar(string nome, SituacaoEnum situacao)
        {
            Nome = nome;
            Situacao = situacao;

            Console.WriteLine("Atializado com suesso.");
        }
    }
}
