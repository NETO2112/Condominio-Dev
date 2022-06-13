using CondominioDev.Core.Entities;

namespace CondominioDev.Core.Interfaces
{
    public interface IHabitanteService
    {
        public List<Habitante> ObterTodosHabitantes();

        public List<Habitante>? ObterHabitantePorNome(string nome);

        public Habitante? ObterHabitantePorId(int id);
        
        public int CadastrarHabitante(Habitante habitante);

        public void AtualizarHabitante(Habitante habitante);

        public void DeletarHabitante(int id);

        public void DeletarTodosHabitantes();
    }
}