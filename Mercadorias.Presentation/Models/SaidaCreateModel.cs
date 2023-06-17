using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mercadorias.Presentation.Models
{
    public class SaidaCreateModel
    {
        //quantidade, a data e hora, o local
        public int QuantidadeSaida { get; set; }

        public DateTime DataHoraSaida { get; set; }

        public string Descricao { get; set; }

        public string LocalSaida { get; set; }

        public string NomeFabricante { get; set; }

        public string NumeroRegistro { get; set; }

        public int IdMercadoria { get; set; }
    }
}
