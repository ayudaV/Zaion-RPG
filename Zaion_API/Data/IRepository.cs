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
        Task<Personagem> GetPersonagemByKeyAsync(int key);
        Task<Personagem[]> GetPersonagemByNameAsync(string key);

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

        // Get para Armamentos
        Task<Armamento[]> GetAllArmamentosAsync();
        Task<Armamento> GetArmamentoByKeyAsync(int key);
        Task<Armamento[]> GetArmamentoByIdPersonagemAsync(int key);
        Task<Armamento[]> GetArmamentoByIdArmaAsync(int key);

        /*
                // GET para Aluno
                Task<Aluno[]> GetAllAlunosAsync();
                Task<Aluno> GetAlunoByKeyAsync(string key);

                // GET para Monitor
                Task<Monitor[]> GetAllMonitoresAsync();
                Task<Monitor> GetMonitorByKeyAsync(int key);
                Task<MonitorAluno> GetMonitorByEmailAsync(string email);
                Task<MonitorAluno[]> GetMonitoresByNameAsync();

                // GET para Horario
                Task<Horario[]> GetAllHorariosAsync();
                Task<Horario> GetHorarioByKeyAsync(int key);
                Task<Horario[]> GetHorarioByDayAsync(int day);
                Task<Horario[]> GetHorarioByMonitorAsync(int idMonitor);
                Task<Horario[]> GetHorarioByDayMonitorAsync(int day, int idMonitor);

                // GET para Agendamento
                Task<Agendamento[]> GetAllAgendamentosAsync();
                Task<Agendamento> GetAgendamentoByKeyAsync(int key);
                Task<AgendaHorario[]> GetAgendamentoByEmailAsync(string email);
                Task<AgendaHorario[]> GetAgendamentoByDayAsync(int day);
                Task<AgendaAluno[]> GetAlunoAgendamentoByHorarioAsync(int idHorario);
                Task<AgendaHorario[]> GetAgendamentoByDayMonitorAsync(int day, int idMonitor);
                Task<AgendaHorario[]> GetAgendamentoByHorarioAsync(int idHorario);*/
    }
}