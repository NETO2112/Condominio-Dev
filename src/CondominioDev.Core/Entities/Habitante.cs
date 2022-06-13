using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CondominioDev.Core.Entities
{
    public class Habitante : Entity
    {
        public Habitante(string nome, string sobrenome, string cPF, DateTime dataNascimento, decimal renda)
        {
            Nome = nome;
            Sobrenome = sobrenome;
            CPF = cPF;
            DataNascimento = dataNascimento;
            Renda = renda;
        }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Nome { get; private set; }
        
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Sobrenome { get; private set; }

        //[JsonIgnore]

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