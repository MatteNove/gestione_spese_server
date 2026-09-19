using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace gestione_spese_server.Entity
{
    public class TipoSpesa
    {
        [Key][Required] public int idTipoSpesa { get; set; }
        [Required][Column(TypeName = "nvarchar(50)")] public String nome { get; set; }
    }
}
