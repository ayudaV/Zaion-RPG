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
        Task<Jogador[]> GetJogadoresByNameAsync(string key);
        Task<Jogador[]> GetJogadoresByUsernameAsync(string key);

        // Get para Personagens
        Task<Personagem[]> GetAllPersonagensAsync();
        Task<PersonagemJogador[]> GetAllPersonagensJogadorAsync();
        Task<Personagem> GetPersonagemByKeyAsync(int key);
        Task<Personagem[]> GetPersonagensByNameAsync(string key);
        Task<Personagem[]> GetPersonagensByJogadorAsync(int key);
        Task<Personagem[]> GetPersonagensByPesoAsync(double min, double max);

        // Get para Itens
        Task<Item[]> GetAllItensAsync();
        Task<Item> GetItemByKeyAsync(int key);
        Task<Item[]> GetItensByNameAsync(string key);

        // Get para Armas
        Task<Arma[]> GetAllArmasAsync();
        Task<Arma> GetArmaByKeyAsync(int key);
        Task<Arma[]> GetArmasByNameAsync(string key);

        // Get para Inventarios
        Task<Inventario[]> GetAllInventariosAsync();
        Task<Inventario> GetInventarioByKeyAsync(int key);
        Task<Inventario[]> GetInventariosByIdPersonagemAsync(int key);
        Task<Inventario[]> GetInventariosByIdItemAsync(int key);
        Task<InventarioItem[]> GetInventariosItensByKeyAsync(int key);
        Task<InventarioItem[]> GetInventariosItensByIdPersonagemAsync(int key);

        // Get para Armamentos
        Task<Armamento[]> GetAllArmamentosAsync();
        Task<Armamento> GetArmamentoByKeyAsync(int key);
        Task<Armamento[]> GetArmamentosByIdPersonagemAsync(int key);
        Task<Armamento[]> GetArmamentosByIdArmaAsync(int key);
        Task<ArmamentoArma[]> GetArmamentosArmasByKeyAsync(int key);
        Task<ArmamentoArma[]> GetArmamentosArmasByIdPersonagemAsync(int key);

    }
}