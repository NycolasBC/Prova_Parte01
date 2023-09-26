using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Prova_Parte01.Model.Request
{
    public class NovasCartasViewModel
    {
        [JsonIgnore]
        public int Id { get; set; }

        [Required(ErrorMessage = "É necessário ter um nome.")]
        [MinLength(3, ErrorMessage = "É necessário ter no minimo 3 caracteres."), MaxLength(255, ErrorMessage = "Limite máximo de 255 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "É necessário informa um endereço.")]
        public Endereco EnderecoCarta { get; set; }

        [Required(ErrorMessage = "É necessário escrever uma carta.")]
        [Range(1, 14, ErrorMessage = "Informe uma idade de 1 a 14 anos.")]
        public int Idade { get; set; }

        [Required(ErrorMessage = "É necessário escrever uma carta.")]
        [MaxLength(500, ErrorMessage = "Limite máximo de 500 caracteres.")]
        public string TextoCarta { get; set; }
    }

    public class Endereco
    {
        public string Rua { get; set; }
        public int Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
    }
}
