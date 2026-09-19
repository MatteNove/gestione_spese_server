using System;
using System.Collections.Generic;
using System.Text;

namespace gestione_spese_server.DTOs
{
    public class RequestUtente
    {
        public String nome { get; set; }

        public String cognome { get; set; }

        public DateOnly dataNascita { get; set; }
    }
}
