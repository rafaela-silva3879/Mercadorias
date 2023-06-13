using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mercadorias.Domain.Entities
{
    public class Saida
    {
        public Guid IdSaida { get; set; }
        public Int32 QuantidadeSaida { get; set; }
        public DateTime DataHoraSaida { get; set; }
        public string LocalSaida { get; set; }

        public Guid IdMercadoria { get; set; }
        public Mercadoria Mercadoria { get; set; }
    }
}
