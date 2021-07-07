using System.Threading.Tasks;
using System.Linq;
using Zaion_API.Models;

namespace Zaion_API.Data
{
    public interface IRepository
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entiry) where T : class;

        Task<bool> SaveChangesAsync();

        // Get para Jogador
        Task<Jogador[]> GetAllJogadoresAsync();
        Task<Jogador> GetJogadorByKeyAsync(int key);
        Task<Jogador[]> GetJogadorByNameAsync(string key);

        // Get para Personagens
        Task<Personagem[]> GetAllPersonagensAsync();
        Task<PersonagemJogador[]> GetAllPersonagensJogadorAsync();
        Task<Personagem> GetPersonagemByKeyAsync(int key);
        Task<Personagem[]> GetPersonagemByNameAsync(string key);
        Task<Personagem[]> GetPersonagemByJogadorAsync(int key);

        // Get para Itens
        Task<Item[]> GetAllItensAsync();
        Task<Item> GetItemByKeyAsync(int key);
        Task<Item[]> GetItemByNameAsync(string key);

        // Get para Armas
        Task<Arma[]> GetAllArmasAsync();
        Task<Arma> GetArmaByKeyAsync(int key);
        Task<Arma[]> GetArmaByNameAsync(string key);

        // Get para Inventarios
        Task<Inventario[]> GetAllInventariosAsync();
        Task<Inventario> GetInventarioByKeyAsync(int key);
        Task<Inventario[]> GetInventarioByIdPersonagemAsync(int key);
        Task<Inventario[]> GetInventarioByIdItemAsync(int key);
        Task<InventarioItem[]> GetInventarioItemByKeyAsync(int key);
        Task<InventarioItem[]> GetInventarioItemByIdPersonagemAsync(int key);

        // Get para Armamentos
        Task<Armamento[]> GetAllArmamentosAsync();
        Task<Armamento> GetArmamentoByKeyAsync(int key);
        Task<Armamento[]> GetArmamentoByIdPersonagemAsync(int key);
        Task<Armamento[]> GetArmamentoByIdArmaAsync(int key);
        Task<ArmamentoArma[]> GetArmamentoArmaByKeyAsync(int key);
        Task<ArmamentoArma[]> GetArmamentoArmaByIdPersonagemAsync(int key);

    }
}