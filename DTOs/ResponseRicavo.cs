using System;
using System.Collections.Generic;
using System.Text;

namespace gestione_spese_server.DTOs
{
    public class ResponseRicavo
    {
        public int idRicavo { get; set; }

        public double importo { get; set; }

        public String descrizione { get; set; }

        public DateOnly dataRicavo { get; set; }

        public int idUtente { get; set; }

        public int idTipoRicavo { get; set; }

    }
}
