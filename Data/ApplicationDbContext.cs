using Microsoft.EntityFrameworkCore;
using StarshipServer.Data.Models;
namespace StarshipServer.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base()
        {

        }
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Hull> Hulls => Set<Hull>();
        public DbSet<Reactor> Reactors => Set<Reactor>();
        public DbSet<Starship> Starships => Set<Starship>();
        public DbSet<Thruster> Thrusters => Set<Thruster>();
        public DbSet<Weapon> Weapons => Set<Weapon>();
    }
}
