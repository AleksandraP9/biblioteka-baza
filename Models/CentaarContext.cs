using Microsoft.EntityFrameworkCore;

namespace ServerProj.Models
{
    public class CentaarContext : DbContext
    {
        public DbSet<Biblioteka> Biblioteke { get; set; }
        
        //public DbSet<Forma> Forme { get; set; }
        public DbSet<Polica> Police { get; set; }
        public DbSet<Knjiga> Knjige { get; set; }

        public CentaarContext(DbContextOptions options) : base(options)
        {

        }
    }
}