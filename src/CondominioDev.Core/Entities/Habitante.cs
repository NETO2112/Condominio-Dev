namespace CondominioDev.Core.Entities
{
    public class Habitante : Entity
    {
        public string Nome { get; private set; }
        public string Sobrenome { get; private set; }
        public string CPF { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public decimal Renda { get; private set; }

    }
}