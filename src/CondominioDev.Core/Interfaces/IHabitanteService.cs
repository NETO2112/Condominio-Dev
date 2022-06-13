using CondominioDev.Core.Entities;

namespace CondominioDev.Core.Interfaces
{
    public interface IHabitanteService
    {
        public List<Habitante> ObterTodosHabitantes();

        public List<Habitante>? ObterHabitantePorNome(string nome);

        public Habitante? ObterHabitantePorId(int id);
        
        public int CadastrarHabitante(Habitante habitante);

        public void AtualizarHabitante(Habitante habitanteOriginal, Habitante habitanteAtualizado);

        public void DeletarHabitante(int id);

        public void DeletarTodosHabitantes();

        public List<Habitante>? ObterHabitantePorMesDeNascimento(int mes);

        public List<Habitante>? ObterHabitanteComIdadeMaiorQue(int idade);
        
        public decimal ObterRendaTotal();

        public Habitante ObterHabitanteComMaiorRenda();
    }
}