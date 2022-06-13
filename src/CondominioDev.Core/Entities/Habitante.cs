using System.ComponentModel.DataAnnotations;

namespace CondominioDev.Core.Entities
{
    public class Habitante : Entity
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Nome { get; private set; }
        
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Sobrenome { get; private set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string CPF { get; private set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public DateTime DataNascimento { get; private set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public decimal Renda { get; private set; }

        public void AtualizarDados(Habitante habitante)
        {
            Nome = habitante.Nome;
            Sobrenome = habitante.Sobrenome;
            CPF = habitante.CPF;
            DataNascimento = habitante.DataNascimento;
            Renda = habitante.Renda;
        }
    }
}