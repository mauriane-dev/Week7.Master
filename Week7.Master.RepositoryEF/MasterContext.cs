using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week7.Master.Core.Entities;

namespace Week7.Master.RepositoryEF
{
    public class MasterContext: DbContext
    {
        //Elenco i DbSet ovvero le tabelle/entità 
        public DbSet<Corso> Corsi { get; set; }
        public DbSet<Studente> Studenti { get; set; }
        public DbSet<Lezione> Lezioni { get; set; }
        public DbSet<Docente> Docenti { get; set; }
        public DbSet<Utente> Utenti { get; set; }



        public MasterContext()
        {

        }

        public MasterContext(DbContextOptions<MasterContext> options) : base(options) { }


        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb; Database=CorsiMaster; Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Corso>(new CorsoConfiguration());
            modelBuilder.ApplyConfiguration<Studente>(new StudenteConfiguration());
            modelBuilder.ApplyConfiguration<Docente>(new DocenteConfiguration());
            modelBuilder.ApplyConfiguration<Lezione>(new LezioneConfiguration());
            modelBuilder.ApplyConfiguration<Utente>(new UtenteConfiguration());
        }
    }
}
