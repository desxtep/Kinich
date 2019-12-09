using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Domain
{
    public class DataContext : DbContext
    {
        public DataContext() : base("DefaultConnection")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }

        public System.Data.Entity.DbSet<Domain.Categoria_Edad> Categoria_Edad { get; set; }

        public System.Data.Entity.DbSet<Domain.Categoria_Peso> Categoria_Peso { get; set; }

        public System.Data.Entity.DbSet<Domain.Usuario> Usuarios { get; set; }

        public System.Data.Entity.DbSet<Domain.Torneo> Torneos { get; set; }

        public System.Data.Entity.DbSet<Domain.Juez_Torneo> Juez_Torneo { get; set; }

        public System.Data.Entity.DbSet<Domain.Combate> Combates { get; set; }

        public System.Data.Entity.DbSet<Domain.Participante_Combate> Participante_Combate { get; set; }

        public System.Data.Entity.DbSet<Domain.Participante_Forma> Participante_Forma { get; set; }

        public System.Data.Entity.DbSet<Domain.Calificacion> Calificacions { get; set; }
    }
}
