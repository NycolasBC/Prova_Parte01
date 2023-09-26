using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Prova_Parte01.Model.Request;
using System;
using WebApplicationList01.Controllers;

namespace MegaSena.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartasController : PrincipalController
    {
        #region Propriedades e construtor

        private readonly string _cartasCaminhoArquivo;

        public CartasController()
        {
            _cartasCaminhoArquivo = Path.Combine(Directory.GetCurrentDirectory(), "Data", "cartas.json");
        }

        #endregion

        #region Métodods Arquivo

        private List<CartasViewModel> LerCartaArquivo()
        {
            if (!System.IO.File.Exists(_cartasCaminhoArquivo))
            {
                return new List<CartasViewModel>();
            }

            string json = System.IO.File.ReadAllText(_cartasCaminhoArquivo);
            return JsonConvert.DeserializeObject<List<CartasViewModel>>(json);
        }

        private int ObterProximoCodigoDisponivel()
        {
            List<CartasViewModel> cartas = LerCartaArquivo();
            if (cartas.Any())
            {
                return cartas.Max(j => j.Id) + 1;
            }
            else
            {
                return 1;
            }
        }

        private void EscreverNoArquivo(List<CartasViewModel> cartas)
        {
            string json = JsonConvert.SerializeObject(cartas);
            System.IO.File.WriteAllText(_cartasCaminhoArquivo, json);
        }

        #endregion

        #region Metodos CRUD

        [HttpGet]
        public IActionResult Get()
        {
            List<CartasViewModel> cartas = LerCartaArquivo();
            return Ok(cartas);
        }

        [HttpPost]
        public IActionResult Post([FromBody] NovasCartasViewModel novasCartas)
        {
            if (!ModelState.IsValid)
            {
                return ApiBadRequestResponse(ModelState);
            }

            List<CartasViewModel> cartas = LerCartaArquivo();

            int proximoCodigo = ObterProximoCodigoDisponivel();

            CartasViewModel novaCarta = new CartasViewModel()
            {
                Id = proximoCodigo,
                Nome = novasCartas.Nome,
                EnderecoCarta = novasCartas.EnderecoCarta,
                Idade = novasCartas.Idade,
                TextoCarta  = novasCartas.TextoCarta
            };

            cartas.Add(novaCarta);
            EscreverNoArquivo(cartas);

            return ApiResponse(cartas, "Carta registrada com sucesso.");
        }

        #endregion
    }
}
