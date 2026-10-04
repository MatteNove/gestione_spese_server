using System;
using System.Collections.Generic;
using System.Text;

namespace gestione_spese_server.DTOs
{

    internal class ResponseSpesa
    {
        public int idSpesa { get; set; }

        public double importo { get; set; }

        public String descrizione { get; set; }

        public DateOnly dataSpesa { get; set; }

        public int idUtente { get; set; }

        public int idTipoSpesa { get; set; }
    }
}
