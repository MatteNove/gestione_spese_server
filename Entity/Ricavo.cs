using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gestione_spese_server.Entity
{
    public class Ricavo
    {
        
        [Key] [Required] public int idRicavi { get; set; }

        [Required] [Column(TypeName = "decimal(18,2)")] public double importo { get; set; }

        [Required][Column(TypeName = "nvarchar(100)")]  public String descrizione { get; set; }

        [Required] [Column(TypeName = "datetime2")] public  DateOnly dataRicavo { get; set; }

        public int idUtente { get; set;}

        [ForeignKey(nameof(idUtente))]
        public Utente utente { get; set; }

        public int idTipoRicavo { get; set; }

        [ForeignKey(nameof(idTipoRicavo))]
        public TipoRicavo tipoRicavo { get; set; }

    }
}
