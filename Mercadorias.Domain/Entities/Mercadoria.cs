using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mercadorias.Domain.Entities
{
    public class Mercadoria
    { 
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string NumeroRegistro { get; set; }
        public string Fabricante { get; set; }
        public string Tipo { get; set; }
        public string Descricao { get; set; }

        public List<Entrada> Entradas { get; set; }
        public List<Saida> Saidas { get; set; }
    }
}
