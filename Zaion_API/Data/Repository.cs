using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore;
using System.Linq;
using Zaion_API.Models;

namespace Zaion_API.Data
{
    public class Repository : IRepository
    {
        DataBaseContext context;
        public Repository(DataBaseContext contx)
        {
            this.context = contx;
        }

        public void Add<T>(T entity) where T : class
        {
            this.context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            this.context.Remove(entity);
        }
        public async Task<bool> SaveChangesAsync()
        {
            return (await this.context.SaveChangesAsync() > 0);
        }
        public void Update<T>(T entity) where T : class
        {
            this.context.Update(entity);
        }

        //Jogador
        public async Task<Jogador[]> GetAllJogadoresAsync()
        {
            IQueryable<Jogador> consultaJogadores = this.context.Jogador;
            consultaJogadores = consultaJogadores.OrderBy(a => a.IdJogador);
            return await consultaJogadores.ToArrayAsync();
        }
        public async Task<Jogador> GetJogadorByKeyAsync(int key)
        {
            IQueryable<Jogador> consultaJogadores = this.context.Jogador;
            consultaJogadores = consultaJogadores.Where(a => a.IdJogador == key);
            return await consultaJogadores.FirstOrDefaultAsync();
        }
        public async Task<Jogador[]> GetJogadoresByNameAsync(string nome)
        {
            IQueryable<Jogador> consultaJogadores = this.context.Jogador;
            consultaJogadores = consultaJogadores.Where(a => a.NomeJogador.Contains(nome));
            consultaJogadores = consultaJogadores.OrderBy(a => a.Username);
            return await consultaJogadores.ToArrayAsync();
        }
        public async Task<Jogador[]> GetJogadoresByUsernameAsync(string nome)
        {
            IQueryable<Jogador> consultaJogadores = this.context.Jogador;
            consultaJogadores = consultaJogadores.Where(a => a.Username.Contains(nome));
            consultaJogadores = consultaJogadores.OrderBy(a => a.Username);
            return await consultaJogadores.ToArrayAsync();
        }
        public async Task<Jogador> GetJogadorByUsernameSenha(string username, string senha)
        {
            IQueryable<Jogador> usuario = this.context.Jogador;
            usuario = usuario.Where(u => u.Username == username && u.Senha == senha);
            return await usuario.FirstOrDefaultAsync();
        }
        
        //Personagem
        public async Task<Personagem[]> GetAllPersonagensAsync()
        {
            IQueryable<Personagem> consultaPersonagens = this.context.Personagem;
            consultaPersonagens = consultaPersonagens.OrderBy(a => a.IdPersonagem);
            return await consultaPersonagens.ToArrayAsync();
        }
        public async Task<Personagem> GetPersonagemByKeyAsync(int key)
        {
            IQueryable<Personagem> consultaPersonagens = this.context.Personagem;
            consultaPersonagens = consultaPersonagens.Where(a => a.IdPersonagem == key);
            return await consultaPersonagens.FirstOrDefaultAsync();
        }
        public async Task<Personagem[]> GetPersonagensByNameAsync(string nome)
        {
            IQueryable<Personagem> consultaPersonagens = this.context.Personagem;
            consultaPersonagens = consultaPersonagens.Where(a => a.Nome.Contains(nome));
            consultaPersonagens = consultaPersonagens.OrderBy(a => a.Nome);
            return await consultaPersonagens.ToArrayAsync();
        }
        public async Task<Personagem[]> GetPersonagensByJogadorAsync(int key)
        {
            IQueryable<Personagem> consultaPersonagens = this.context.Personagem;
            consultaPersonagens = consultaPersonagens.Where(a => a.IdJogador == key);
            consultaPersonagens = consultaPersonagens.OrderBy(a => a.Nome);
            return await consultaPersonagens.ToArrayAsync();
        }
        public async Task<PersonagemJogador[]> GetAllPersonagensJogadorAsync()
        {
            IQueryable<PersonagemJogador> consultaJogadores = from p in this.context.Personagem
            join j in this.context.Jogador on p.IdJogador equals j.IdJogador into res
            from rs in res.DefaultIfEmpty()
            select new PersonagemJogador() { Personagem = p, Jogador = rs };
            return await consultaJogadores.ToArrayAsync();
        }
        public async Task<Personagem[]> GetPersonagensByPesoAsync(double min, double max)
        {
            IQueryable<Personagem> consultaPersonagens = this.context.Personagem;
            consultaPersonagens = consultaPersonagens.Where(a => min <= a.Peso && a.Peso <= max);
            consultaPersonagens = consultaPersonagens.OrderBy(a => a.Nome);
            return await consultaPersonagens.ToArrayAsync();
        }

        //Item
        public async Task<Item[]> GetAllItensAsync()
        {
            IQueryable<Item> consultaItens = this.context.Item;
            consultaItens = consultaItens.OrderBy(a => a.IdItem);
            return await consultaItens.ToArrayAsync();
        }
        public async Task<Item> GetItemByKeyAsync(int key)
        {
            IQueryable<Item> consultaItens = this.context.Item;
            consultaItens = consultaItens.Where(a => a.IdItem == key);
            return await consultaItens.FirstOrDefaultAsync();
        }
        public async Task<Item[]> GetItensByNameAsync(string nome)
        {
            IQueryable<Item> consultaItens = this.context.Item;
            consultaItens = consultaItens.Where(a => a.Nome.Contains(nome));
            consultaItens = consultaItens.OrderBy(a => a.Nome);
            return await consultaItens.ToArrayAsync();
        }

        //Arma
        public async Task<Arma[]> GetAllArmasAsync()
        {
            IQueryable<Arma> consultaArmas = this.context.Arma;
            consultaArmas = consultaArmas.OrderBy(a => a.IdArma);
            return await consultaArmas.ToArrayAsync();
        }
        public async Task<Arma> GetArmaByKeyAsync(int key)
        {
            IQueryable<Arma> consultaArmas = this.context.Arma;
            consultaArmas = consultaArmas.Where(a => a.IdArma == key);
            return await consultaArmas.FirstOrDefaultAsync();
        }
        public async Task<Arma[]> GetArmasByNameAsync(string nome)
        {
            IQueryable<Arma> consultaArmas = this.context.Arma;
            consultaArmas = consultaArmas.Where(a => a.Nome.Contains(nome));
            consultaArmas = consultaArmas.OrderBy(a => a.Nome);
            return await consultaArmas.ToArrayAsync();
        }

        //Inventario
        public async Task<Inventario[]> GetAllInventariosAsync()
        {
            IQueryable<Inventario> consultaInventarios = this.context.Inventario;
            consultaInventarios = consultaInventarios.OrderBy(a => a.IdInventario);
            return await consultaInventarios.ToArrayAsync();
        }
        public async Task<Inventario> GetInventarioByKeyAsync(int key)
        {
            IQueryable<Inventario> consultaInventarios = this.context.Inventario;
            consultaInventarios = consultaInventarios.Where(a => a.IdInventario == key);
            return await consultaInventarios.FirstOrDefaultAsync();
        }
        public async Task<Inventario[]> GetInventariosByIdPersonagemAsync(int key)
        {
            IQueryable<Inventario> consultaInventarios = this.context.Inventario;
            consultaInventarios = consultaInventarios.Where(a => a.IdPersonagem == key);
            return await consultaInventarios.ToArrayAsync();
        }
        public async Task<Inventario[]> GetInventariosByIdItemAsync(int key)
        {
            IQueryable<Inventario> consultaInventarios = this.context.Inventario;
            consultaInventarios = consultaInventarios.Where(a => a.IdItem == key);
            return await consultaInventarios.ToArrayAsync();
        }
        public async Task<InventarioItem[]> GetInventariosItensByKeyAsync(int key)
        {
            IQueryable<InventarioItem> consultaInventarios = from inv in this.context.Inventario
                join item in this.context.Item on inv.IdItem equals item.IdItem into res
                from rs in res.DefaultIfEmpty()
                where
                    inv.IdInventario == key
                select new InventarioItem() { Inventario = inv, Item = rs };
            return await consultaInventarios.ToArrayAsync();
        }
        public async Task<InventarioItem[]> GetInventariosItensByIdPersonagemAsync(int key)
        {
            IQueryable<InventarioItem> consultaInventarios = from inv in this.context.Inventario
                join item in this.context.Item on inv.IdItem equals item.IdItem into res
                from rs in res.DefaultIfEmpty()
                where
                    inv.IdPersonagem == key
                select new InventarioItem() { Inventario = inv, Item = rs };
            return await consultaInventarios.ToArrayAsync();
        }
        public async Task<InventarioPersonagem[]> GetInventariosPersonagensByIdItemAsync(int key)
        {
            IQueryable<InventarioPersonagem> consultaArmamentos = from inv in this.context.Inventario
                join p in this.context.Personagem on inv.IdPersonagem equals p.IdJogador into res
                from rs in res.DefaultIfEmpty()
                where
                    inv.IdItem == key
                select new InventarioPersonagem() { Inventario = inv, Personagem = rs };
            return await consultaArmamentos.ToArrayAsync();
        }
        //Armamento
        public async Task<Armamento[]> GetAllArmamentosAsync()
        {
            IQueryable<Armamento> consultaArmamentos = this.context.Armamento;
            consultaArmamentos = consultaArmamentos.OrderBy(a => a.IdArmamento);
            return await consultaArmamentos.ToArrayAsync();
        }
        public async Task<Armamento> GetArmamentoByKeyAsync(int key)
        {
            IQueryable<Armamento> consultaArmamentos = this.context.Armamento;
            consultaArmamentos = consultaArmamentos.Where(a => a.IdArmamento == key);
            return await consultaArmamentos.FirstOrDefaultAsync();
        }
        public async Task<Armamento[]> GetArmamentosByIdPersonagemAsync(int key)
        {
            IQueryable<Armamento> consultaArmamentos = this.context.Armamento;
            consultaArmamentos = consultaArmamentos.Where(a => a.IdPersonagem == key);
            return await consultaArmamentos.ToArrayAsync();
        }
        public async Task<Armamento[]> GetArmamentosByIdArmaAsync(int key)
        {
            IQueryable<Armamento> consultaArmamentos = this.context.Armamento;
            consultaArmamentos = consultaArmamentos.Where(a => a.IdArma == key);
            return await consultaArmamentos.ToArrayAsync();
        }
        public async Task<ArmamentoArma[]> GetArmamentosArmasByKeyAsync(int key)
        {
            IQueryable<ArmamentoArma> consultaArmamentos = from amt in this.context.Armamento
                join arma in this.context.Arma on amt.IdArma equals arma.IdArma into res
                from rs in res.DefaultIfEmpty()
                where
                    amt.IdArmamento == key
                select new ArmamentoArma() { Armamento = amt, Arma = rs };
            return await consultaArmamentos.ToArrayAsync();
        }
        public async Task<ArmamentoArma[]> GetArmamentosArmasByIdPersonagemAsync(int key)
        {
            IQueryable<ArmamentoArma> consultaArmamentos = from amt in this.context.Armamento
                join arma in this.context.Arma on amt.IdArma equals arma.IdArma into res
                from rs in res.DefaultIfEmpty()
                where
                    amt.IdPersonagem == key
                select new ArmamentoArma() { Armamento = amt, Arma = rs };
            return await consultaArmamentos.ToArrayAsync();
        }
        public async Task<ArmamentoPersonagem[]> GetArmamentosPersonagemsByIdArmaAsync(int key)
        {
            IQueryable<ArmamentoPersonagem> consultaArmamentos = from amt in this.context.Armamento
                join p in this.context.Personagem on amt.IdPersonagem equals p.IdJogador into res
                from rs in res.DefaultIfEmpty()
                where
                    amt.IdArma == key
                select new ArmamentoPersonagem() { Armamento = amt, Personagem = rs };
            return await consultaArmamentos.ToArrayAsync();
        }
    }
}