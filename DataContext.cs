using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace gestione_spese_server
{
    public class DataContext : DbContext
    {
        public DataContext()
        {
            this.Database.EnsureCreated(); //Metodo che crea il database se non esiste
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=C:\Users\hp\Desktop\Progetto\GESTIONE_SPESE\DB\gestione_spese.db");
        }

        public DbSet<Entity.Utente> Utente { get; set; }
        public DbSet<Entity.Spesa> Spesa { get; set; }
        public DbSet<Entity.Ricavo> Ricavo { get; set; }
        public DbSet<Entity.TipoRicavo> TipoRicavo { get; set; }
        public DbSet<Entity.TipoSpesa> TipoSpesa { get; set; }


    }
}
