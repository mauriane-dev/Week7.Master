// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Week7.Master.RepositoryEF;

namespace Week7.Master.RepositoryEF.Migrations
{
    [DbContext(typeof(MasterContext))]
    partial class MasterContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Week7.Master.Core.Entities.Corso", b =>
                {
                    b.Property<string>("CorsoCodice")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Descrizione")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CorsoCodice");

                    b.ToTable("Corso");
                });

            modelBuilder.Entity("Week7.Master.Core.Entities.Docente", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Cognome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("ID");

                    b.ToTable("Docente");
                });

            modelBuilder.Entity("Week7.Master.Core.Entities.Lezione", b =>
                {
                    b.Property<int>("LezioneID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Aula")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CorsoCodice")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("DataOraInizio")
                        .HasColumnType("datetime2");

                    b.Property<int>("DocenteID")
                        .HasColumnType("int");

                    b.Property<int>("Durata")
                        .HasColumnType("int");

                    b.HasKey("LezioneID");

                    b.HasIndex("CorsoCodice");

                    b.HasIndex("DocenteID");

                    b.ToTable("Lezione");
                });

            modelBuilder.Entity("Week7.Master.Core.Entities.Studente", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Cognome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CorsoCodice")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("DataNascita")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TitoloStudio")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("CorsoCodice");

                    b.ToTable("Studente");
                });

            modelBuilder.Entity("Week7.Master.Core.Entities.Utente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Ruolo")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Utente");
                });

            modelBuilder.Entity("Week7.Master.Core.Entities.Lezione", b =>
                {
                    b.HasOne("Week7.Master.Core.Entities.Corso", "Corso")
                        .WithMany("Lezioni")
                        .HasForeignKey("CorsoCodice");

                    b.HasOne("Week7.Master.Core.Entities.Docente", "Docente")
                        .WithMany("Lezioni")
                        .HasForeignKey("DocenteID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Corso");

                    b.Navigation("Docente");
                });

            modelBuilder.Entity("Week7.Master.Core.Entities.Studente", b =>
                {
                    b.HasOne("Week7.Master.Core.Entities.Corso", "Corso")
                        .WithMany("Studenti")
                        .HasForeignKey("CorsoCodice");

                    b.Navigation("Corso");
                });

            modelBuilder.Entity("Week7.Master.Core.Entities.Corso", b =>
                {
                    b.Navigation("Lezioni");

                    b.Navigation("Studenti");
                });

            modelBuilder.Entity("Week7.Master.Core.Entities.Docente", b =>
                {
                    b.Navigation("Lezioni");
                });
#pragma warning restore 612, 618
        }
    }
}
