using System.Collections.Generic;
using System;

namespace Mercadorias.Presentation.Models
{
    public class RelatorioMensalModel
    {
        public int Mes { get; set; }

        public int Ano { get; set; }

        public string IdMercadoria { get; set; }

        public string NomeMercadoria { get; set; }

        public string NumeroRegistro { get; set; }

        public int QuantidadeEntrada { get; set; }

        public int QuantidadeSaida { get; set; }

        public int QuantidadeRestante { get; set; }
    }
}
