using System.ComponentModel.DataAnnotations;

namespace Prova_Parte01.Model.Request
{
    public class CartasViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public Endereco EnderecoCarta { get; set; }
        public int Idade { get; set; }
        public string TextoCarta { get; set; }
    }
}
