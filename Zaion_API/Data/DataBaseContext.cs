using Microsoft.EntityFrameworkCore;
using Zaion_API.Models;

namespace Zaion_API.Data
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options) { }

        public DbSet<Jogador> Jogadores { get; set; }
        public DbSet<Personagem> Personagens { get; set; }
        public DbSet<Item> Itens { get; set; }
        public DbSet<Arma> Armas { get; set; }
        public DbSet<Inventario> Inventarios { get; set; }

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