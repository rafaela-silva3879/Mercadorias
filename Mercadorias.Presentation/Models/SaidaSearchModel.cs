using System.Collections.Generic;
using System;

namespace Mercadorias.Presentation.Models
{
    public class SaidaSearchModel
    {
        public string DataMin { get; set; }

        public string DataMax { get; set; }


        public string NomeMercadoria { get; set; }
        public MercadoriaCreateModel m { get; set; }
        public List<MercadoriaCreateModel> Mercadorias { get; set; }
        public int Quantidade { get; set; }
        public string DataHora { get; set; }
        public string Local { get; set; }
        public Guid Id { get; set; }
        public int quantidadeRestante { get; set; }
        public string NumeroRegistro { get; set; }

    }
}
