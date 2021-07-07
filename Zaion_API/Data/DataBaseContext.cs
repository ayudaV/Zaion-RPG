using Microsoft.EntityFrameworkCore;
using Zaion_API.Models;

namespace Zaion_API.Data
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options) { }

        public DbSet<Jogador> Jogador { get; set; }
        public DbSet<Personagem> Personagem { get; set; }
        public DbSet<Item> Item { get; set; }
        public DbSet<Arma> Arma { get; set; }
        public DbSet<Inventario> Inventario { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<JogadorPersonagem>().HasNoKey();
            modelBuilder.Entity<PersonagemInventario>().HasNoKey();
            modelBuilder.Entity<PersonagemArmamento>().HasNoKey();
            modelBuilder.Entity<InventarioItem>().HasNoKey();
            modelBuilder.Entity<ArmamentoArma>().HasNoKey();
        }
    }
}