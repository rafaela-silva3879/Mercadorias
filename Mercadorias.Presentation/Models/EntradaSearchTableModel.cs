using Mercadorias.Domain.Entities;
using System.Collections.Generic;
using System;

namespace Mercadorias.Presentation.Models
{
    public class EntradaSearchTableModel
    {
        public class SaidaSearchTableModel
        {
            public List<Mercadoria> Mercadorias { get; set; }
            public int Quantidade { get; set; }
            public DateTime DataHora { get; set; }
            public string Local { get; set; }
            public string numeroRegistro { get; set; }
            public string Fabricante { get; set; }
            public string Tipo { get; set; }

        }
    }
}
