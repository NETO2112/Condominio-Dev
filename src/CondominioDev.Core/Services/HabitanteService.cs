using CondominioDev.Core.Data.Context;
using CondominioDev.Core.Entities;
using CondominioDev.Core.Interfaces;

namespace CondominioDev.Core.Services
{
    public class HabitanteService : IHabitanteService
    {
        private readonly DataContext _context;
        public HabitanteService(DataContext context)
        {
            _context = context;
        }
        public List<Habitante> ObterTodosHabitantes()
        {
            return _context.Habitantes.ToList();
        }

        public List<Habitante>? ObterHabitantePorNome(string nome)
        {
            return _context.Habitantes
                .Where(p => p.Nome.Contains(nome))
                .ToList();
        }

        public Habitante? ObterHabitantePorId(int id)
        {
            return _context.Habitantes
                .Find(id);
        }

        public int CadastrarHabitante(Habitante habitante)
        {
            var ValidacaoCPF = _context.Habitantes
                .Any(p => p.CPF == habitante.CPF);
            if (ValidacaoCPF)
                return -1;
            _context.Habitantes.Add(habitante);
            _context.SaveChanges();
            return habitante.Id;
        }

        public void AtualizarHabitante(Habitante habitanteOriginal, Habitante habitanteAtualizado)
        {
            habitanteOriginal.AtualizarDados(habitanteAtualizado);
            _context.SaveChanges();
        }


        public void DeletarHabitante(int id)
        {
            var habitante = ObterHabitantePorId(id);
            _context.Habitantes.Remove(habitante);
            _context.SaveChanges();
        }

        public void DeletarTodosHabitantes()
        {
            var habitantes = ObterTodosHabitantes();
            _context.Habitantes.RemoveRange(habitantes);
            _context.SaveChanges();
        }

        public List<Habitante>? ObterHabitantePorMesDeNascimento(int mes)
        {
            return _context.Habitantes
                .Where(p => p.DataNascimento.Month == mes)
                .ToList();
        }

        public List<Habitante>? ObterHabitanteComIdadeMaiorQue(int idade)
        {
            return _context.Habitantes
                .Where(p => -p.DataNascimento.Year + DateTime.Now.Year > idade)
                .ToList();
        }

        public decimal ObterRendaTotal()
        {
            return _context.Habitantes
                .Sum(p => p.Renda);
        }

        public Habitante ObterHabitanteComMaiorRenda()
        {
            return _context.Habitantes
                .OrderByDescending(p => p.Renda)
                .FirstOrDefault();
        }
    }
}