using Microsoft.EntityFrameworkCore;
using ProjetoMyTe.AppWeb.Models.Entities;

namespace ProjetoMyTe.AppWeb.Models.Contexts
{
    public class MyTeContext : DbContext
    {
        public MyTeContext(DbContextOptions<MyTeContext> options) : base(options) { }
        public DbSet<Colaborador> Colaboradores { get; set; }
        public DbSet<Cargo> Cargos { get; set; }
        public DbSet<RegistroHora> RegistroHoras { get; set; }
        public DbSet<Wbs> Wbss { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cargo>().ToTable("TB_CARGOS");
            modelBuilder.Entity<Colaborador>().ToTable("TB_COLABORADORES");
            modelBuilder.Entity<RegistroHora>().ToTable("TB_REGISTRO_DIAS_HORAS");
            modelBuilder.Entity<Wbs>().ToTable("TB_WBS");

            modelBuilder.Entity<Cargo>()
                .Property(p => p.NomeCargo)
                .HasColumnName("nomeCargo")
                .HasMaxLength(100);

            modelBuilder.Entity<Colaborador>()
                .Property(p => p.Id)
                .HasColumnName("cpf")
                .HasMaxLength(11);

            modelBuilder.Entity<Colaborador>()
                .Property(p => p.CargoId)
                .HasColumnName("id_cargo");
            
            modelBuilder.Entity<Colaborador>()
                .Property(p => p.Administrador)
                .HasColumnName("administrador");

            modelBuilder.Entity<Wbs>()
                .Property(p => p.Codigo)
                .HasColumnName("codigo")
                .HasMaxLength(10);

            modelBuilder.Entity<Wbs>()
                .Property(p => p.Descricao)
                .HasColumnName("descricao")
                .HasMaxLength(100);

            modelBuilder.Entity<Wbs>()
                .Property(p => p.Tipo)
                .HasColumnName("tipo");

            modelBuilder.Entity<RegistroHora>()
                .Property(p => p.Cpf)
                .HasColumnName("cpf")
                .HasMaxLength(11);

            modelBuilder.Entity<RegistroHora>()
                .Property(p => p.IdWbs)
                .HasColumnName("id_wbs");
            
            modelBuilder.Entity<RegistroHora>()
                .Property(p => p.DataRegistro)
                .HasColumnName("data_registro");

            modelBuilder.Entity<RegistroHora>()
                .Property(p => p.Dia)
                .HasColumnName("dia");

            modelBuilder.Entity<RegistroHora>()
                .Property(p => p.Horas)
                .HasColumnName("horas");
        }
    }
}
