using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace gestione_spese_server.Entity
{
    public class Spesa
    {
        [Key][Required] public int idSpesa { get; set; }
        [Required][Column(TypeName = "decimal(18,2)")] public double importo { get; set; }
        [Required][Column(TypeName = "nvarchar(100)")] public String descrizione { get; set; }
        [Required][Column(TypeName = "datetime2")] public DateOnly dataSpesa { get; set; }

        public int idUtente { get; set; }

        [ForeignKey(nameof(idUtente))]
        public Utente utente { get; set; }

        public int idTipoSpesa { get; set; }

        [ForeignKey(nameof(idTipoSpesa))]
        public TipoSpesa tipoSpesa { get; set; }
    }
}
