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
            if (habitante == null)
                throw new Exception("Habitante não encontrado");
            _context.Habitantes.Remove(habitante);
            _context.SaveChanges();
        }

        public void DeletarTodosHabitantes()
        {
            var habitantes = ObterTodosHabitantes();
            if (habitantes == null)
                throw new Exception("Não há habitantes cadastrados");
            _context.Habitantes.RemoveRange(habitantes);
            _context.SaveChanges();
        }

        public List<Habitante>? ObterHabitantePorMesDeNascimento(int mes)
        {
            return _context.Habitantes
                .Where(p => p.DataNascimento.Month == mes)
                .ToList();
        }
    }
}