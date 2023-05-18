using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mercadorias.Presentation.Models
{
    public class EntradaCreateModel
    {
        //quantidade, a data e hora, o local
        public int QuantidadeEntrada { get; set; }

        public DateTime DataHoraEntrada { get; set; }

        public string Descricao { get; set; }

        public string LocalEntrada { get; set; }

        public Guid Mercadoria { get; set; }

        public int IdMercadoria { get; set; }
    }
}
