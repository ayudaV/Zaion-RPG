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
        public async Task<Jogador[]> GetJogadorByNameAsync(string nome)
        {
            IQueryable<Jogador> consultaJogadores = this.context.Jogador;
            consultaJogadores = consultaJogadores.Where(a => a.NomeJogador.Contains(nome));
            consultaJogadores = consultaJogadores.OrderBy(a => a.Username);
            return await consultaJogadores.ToArrayAsync();
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
        public async Task<Personagem[]> GetPersonagemByNameAsync(string nome)
        {
            IQueryable<Personagem> consultaPersonagens = this.context.Personagem;
            consultaPersonagens = consultaPersonagens.Where(a => a.Nome.Contains(nome));
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
        public async Task<Item[]> GetItemByNameAsync(string nome)
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
        public async Task<Arma[]> GetArmaByNameAsync(string nome)
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
        public async Task<Inventario[]> GetInventarioByIdPersonagemAsync(int key)
        {
            IQueryable<Inventario> consultaInventarios = this.context.Inventario;
            consultaInventarios = consultaInventarios.Where(a => a.IdPersonagem == key);
            return await consultaInventarios.ToArrayAsync();
        }
        public async Task<Inventario[]> GetInventarioByIdItemAsync(int key)
        {
            IQueryable<Inventario> consultaInventarios = this.context.Inventario;
            consultaInventarios = consultaInventarios.Where(a => a.IdItem == key);
            return await consultaInventarios.ToArrayAsync();
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
        public async Task<Armamento[]> GetArmamentoByIdPersonagemAsync(int key)
        {
            IQueryable<Armamento> consultaArmamentos = this.context.Armamento;
            consultaArmamentos = consultaArmamentos.Where(a => a.IdPersonagem == key);
            return await consultaArmamentos.ToArrayAsync();
        }
        public async Task<Armamento[]> GetArmamentoByIdArmaAsync(int key)
        {
            IQueryable<Armamento> consultaArmamentos = this.context.Armamento;
            consultaArmamentos = consultaArmamentos.Where(a => a.IdArma == key);
            return await consultaArmamentos.ToArrayAsync();
        }
        /*

        //Agendamento
        public async Task<Agendamento[]> GetAllAgendamentosAsync()
        {
            IQueryable<Agendamento> consultaAgendamentos = this.context.Agendamento;
            consultaAgendamentos = consultaAgendamentos.OrderBy(a => a.IdAgendamento);
            return await consultaAgendamentos.ToArrayAsync();
        }
        public async Task<Agendamento> GetAgendamentoByKeyAsync(int key)
        {
            IQueryable<Agendamento> consultaAgendamentos = this.context.Agendamento;
            consultaAgendamentos = consultaAgendamentos.Where(a => a.IdAgendamento == key);
            return await consultaAgendamentos.FirstOrDefaultAsync();
        }
        public async Task<AgendaHorario[]> GetAgendamentoByEmailAsync(string email)
        {
            IQueryable<AgendaHorario> consultaAgendamentos = from a in this.context.Agendamento
            join h in this.context.Horario on a.IdHorario equals h.IdHorario into loj
            from rs in loj.DefaultIfEmpty()
            where
                a.Email == email
            select new AgendaHorario() { Agendamento = a, Horario = rs };
            return await consultaAgendamentos.ToArrayAsync();
        }

        public async Task<AgendaHorario[]> GetAgendamentoByDayAsync(int day) {
            IQueryable<AgendaHorario> consultaAgendamentos = from a in this.context.Agendamento
            join h in this.context.Horario on a.IdHorario equals h.IdHorario into loj
            from rs in loj.DefaultIfEmpty()
            where
                rs.DiaDaSemana == day
            select new AgendaHorario() { Agendamento = a, Horario = rs };
            return await consultaAgendamentos.ToArrayAsync();
        }
        public async Task<AgendaAluno[]> GetAlunoAgendamentoByHorarioAsync(int idHorario) {
            IQueryable<AgendaAluno> consultaAgendamentos = from a in this.context.Aluno
            join ag in this.context.Agendamento on a.Email equals ag.Email into loj
            from rs in loj.DefaultIfEmpty()
            where
                rs.IdHorario == idHorario
            select new AgendaAluno() { Agendamento = rs, Aluno = a };
            return await consultaAgendamentos.ToArrayAsync();
        }
        public async Task<AgendaHorario[]> GetAgendamentoByDayMonitorAsync(int day, int idMonitor) {
            IQueryable<AgendaHorario> consultaAgendamentos = from a in this.context.Agendamento
            join h in this.context.Horario on a.IdHorario equals h.IdHorario into loj
            from rs in loj.DefaultIfEmpty()
            where
                rs.DiaDaSemana == day && rs.IdMonitor == idMonitor
            select new AgendaHorario() { Agendamento = a, Horario = rs };
            return await consultaAgendamentos.ToArrayAsync();
        }
        public async Task<AgendaHorario[]> GetAgendamentoByHorarioAsync(int idHorario)
        {
            IQueryable<AgendaHorario> consultaAgendamentos = from a in this.context.Agendamento
            join h in this.context.Horario on a.IdHorario equals h.IdHorario into loj
            from rs in loj.DefaultIfEmpty()
            where
                a.IdHorario == idHorario
            select new AgendaHorario() { Agendamento = a, Horario = rs };
            return await consultaAgendamentos.ToArrayAsync();
        }

        //Monitor
        public async Task<Monitor[]> GetAllMonitoresAsync()
        {
            IQueryable<Monitor> consultaMonitores = this.context.Monitor;
            consultaMonitores = consultaMonitores.OrderBy(a => a.IdMonitor);
            return await consultaMonitores.ToArrayAsync();
        }
        public async Task<Monitor> GetMonitorByKeyAsync(int key)
        {
            IQueryable<Monitor> consultaMonitores = this.context.Monitor;
            consultaMonitores = consultaMonitores.Where(a => a.IdMonitor == key);
            return await consultaMonitores.FirstOrDefaultAsync();
        }
        public async Task<MonitorAluno> GetMonitorByEmailAsync(string email)
        {
            IQueryable<MonitorAluno> consultaMonitores = from m in this.context.Monitor
            join a in this.context.Aluno on m.Email equals a.Email into loj
            from rs in loj.DefaultIfEmpty()
            where
                m.Email == email

            select new MonitorAluno() { Monitor = m, Aluno = rs };
            return await consultaMonitores.FirstAsync();
        }
        public async Task<MonitorAluno[]> GetMonitoresByNameAsync()
        {
            IQueryable<MonitorAluno> consultaMonitores = from m in this.context.Monitor
            join a in this.context.Aluno on m.Email equals a.Email into loj
            from rs in loj.DefaultIfEmpty()

            select new MonitorAluno() { Monitor = m, Aluno = rs };
            return await consultaMonitores.ToArrayAsync();
        }
        
        //Horario
        public async Task<Horario[]> GetAllHorariosAsync()
        {
            IQueryable<Horario> consultaHorarios = this.context.Horario;
            consultaHorarios = consultaHorarios.OrderBy(a => a.DiaDaSemana);
            return await consultaHorarios.ToArrayAsync();
        }
        public async Task<Horario> GetHorarioByKeyAsync(int key)
        {
            IQueryable<Horario> consultaHorarios = this.context.Horario;
            consultaHorarios = consultaHorarios.Where(a => a.IdHorario == key);
            return await consultaHorarios.FirstOrDefaultAsync();
        }
        public async Task<Horario[]> GetHorarioByDayAsync(int day)
        {
            IQueryable<Horario> consultaHorarios = this.context.Horario;
            consultaHorarios = consultaHorarios.Where(a => a.DiaDaSemana == day);
            return await consultaHorarios.ToArrayAsync();
        }
        public async Task<Horario[]> GetHorarioByMonitorAsync(int idMonitor)
        {
            IQueryable<Horario> consultaHorarios = this.context.Horario;
            consultaHorarios = consultaHorarios.Where(a => a.IdMonitor == idMonitor);
            return await consultaHorarios.ToArrayAsync();
        }
        public async Task<Horario[]> GetHorarioByDayMonitorAsync(int day, int idMonitor)
        {
            IQueryable<Horario> consultaHorarios = this.context.Horario;
            consultaHorarios = consultaHorarios.Where(a => a.DiaDaSemana == day && a.IdMonitor == idMonitor);
            return await consultaHorarios.ToArrayAsync();
        }*/
    }
}