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
        public int Id { get; set; }
        public string Nome { get; set; }
        public SituacaoEnum Situacao { get; set; }
    }
}
