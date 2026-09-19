using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace gestione_spese_server.Entity
{
    public class Utente
    {
        [Key][Required] public int idUtente { get; set; }

        [Required][Column(TypeName = "nvarchar(50)")] public String nome { get; set; }

        [Required][Column(TypeName = "nvarchar(50)")] public String cognome { get; set; }

        [Required][Column(TypeName = "datetime2")] public DateOnly dataNascita { get; set; }

    }
}
