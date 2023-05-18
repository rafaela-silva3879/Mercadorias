using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mercadorias.Presentation.Models
{
    public class MercadoriaCreateModel
    {

        public Guid Id { get; set; }

        public string Nome { get; set; }

        public string NumeroRegistro { get; set; }

        public string Fabricante { get; set; }

        public string Tipo { get; set; }

        public string Descricao { get; set; }
    }
}
