using System.Data.Entity;

namespace Domain
{
    public class DataContext : DbContext
    {
        public DataContext() : base("DefaultConnection")
        {

        }

        public System.Data.Entity.DbSet<Domain.Categoria_Edad> Categoria_Edad { get; set; }

        public System.Data.Entity.DbSet<Domain.Categoria_Peso> Categoria_Peso { get; set; }
    }
}
