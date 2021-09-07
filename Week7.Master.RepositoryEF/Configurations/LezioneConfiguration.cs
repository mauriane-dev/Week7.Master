using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Week7.Master.Core.Entities;

namespace Week7.Master.RepositoryEF
{
    internal class LezioneConfiguration : IEntityTypeConfiguration<Lezione>
    {
        public void Configure(EntityTypeBuilder<Lezione> modelBuilder)
        {
            modelBuilder.ToTable("Lezione");
            modelBuilder.HasKey(l => l.LezioneID);
            modelBuilder.Property(l => l.Aula).IsRequired();
            modelBuilder.Property(l => l.DataOraInizio).IsRequired();
            modelBuilder.Property(l => l.Durata).IsRequired();

            //Relazione Corso 1 -> Lezioni n (uno a molti)
            modelBuilder.HasOne(l => l.Corso).WithMany(c => c.Lezioni).HasForeignKey(l => l.CorsoCodice);
            //Relazione Docente 1 -> Lezione n (uno a molti)
            modelBuilder.HasOne(l => l.Docente).WithMany(d => d.Lezioni).HasForeignKey(l => l.DocenteID);


        }
    }
}