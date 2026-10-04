using System;
using System.Collections.Generic;
using System.Text;

namespace gestione_spese_server.DTOs
{
    internal class RequestSpesa
    {
        public double importo { get; set; }

        public String descrizione { get; set; }

        public DateOnly dataSpesa { get; set; }

        public int UtenteId { get; set; }

        public int idTipoSpesa { get; set; }
    }
}
