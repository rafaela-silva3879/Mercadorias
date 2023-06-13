using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mercadorias.Domain.Entities
{
    public class Entrada
    {     
        public Guid IdEntrada { get; set; }
        public Int32 QuantidadeEntrada { get; set; }
        public DateTime DataHoraEntrada { get; set; }
        public string LocalEntrada { get; set; }

        public Guid IdMercadoria { get; set; }
        public Mercadoria Mercadoria { get; set; }
    }
}
