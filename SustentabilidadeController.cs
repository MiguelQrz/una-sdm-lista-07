using Microsoft.AspNetCore.Mvc;

namespace EcoTrackApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SustentabilidadeController : ControllerBase
    {
        private static readonly string[] DicasSustentaveis = new[]
        {
            "Reduza o consumo de plástico de uso único.",
            "Opte por transporte público ou bicicleta sempre que possível.",
            "Desligue aparelhos eletrônicos da tomada quando não estiverem em uso.",
            "Prefira alimentos sazonais e de produtores locais.",
            "Pratique a compostagem de resíduos orgânicos.",
            "Considere a instalação de painéis solares em sua residência.",
            "Mantenha a manutenção do seu veículo em dia para emitir menos CO2."
        };

        [HttpGet]
        public ActionResult<string> GetDica()
        {
            var random = new Random();
            int indice = random.Next(DicasSustentaveis.Length);
            
            return Ok(DicasSustentaveis[indice]);
        }

        [HttpGet("calcular-emissao")]
        public ActionResult<string> GetCalculoEmissao([FromQuery] double km)
        {
            double emissao = km * 0.12;
            return Ok($"Para {km}km rodados, a emissão estimada é de {emissao:F2}kg de CO2.");
        }
    }
}