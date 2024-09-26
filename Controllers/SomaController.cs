using API_Simples.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace API_Simples.Controllers
{
    public class SomaController : Controller
    {
        private ApiService _apiService = new ApiService();

        [HttpGet]
        [Route("APISimples/Soma/{a},{b}")]
        [SwaggerOperation("Realizar a soma de duas Strings")]
        public IActionResult Somar(string a, string b)
        {
            try
            {
                var x = Convert.ToDouble(a);
                var y = Convert.ToDouble(b);

                // Faria dessa forma, mas para estudo de caso e geração de possível Exception, fiz como solicitado.
                //var z = double.TryParse(a, out double saida) ? saida : (double?)null;
                //if(z == null)
                //    throw new Exception("Conversão de String para Inteiro gerou erro.", ex);

                var resultado = _apiService.Soma(x, y);
                return Ok(new { Soma = resultado });
            }
            catch (Exception ex)
            {
                throw new Exception("Conversão de String para Inteiro gerou erro.", ex);
            }
        }

        [HttpGet]
        [Route("APISimples/Subtracao/{a},{b}")]
        [SwaggerOperation("Realizar a subtração de duas Strings")]
        public IActionResult Subtracao(string a, string b)
        {
            try
            {
                var x = Convert.ToDouble(a);
                var y = Convert.ToDouble(b);

                if(x < y)
                    throw new InvalidOperationException("O primeiro número não pode ser menor que o segundo!");

                var resultado = _apiService.Subtracao(x, y);
                return Ok(new { Subtracao = resultado });
            }
            catch (InvalidOperationException ex)
            {
                throw new Exception("Mensagem:", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Conversão de String para Inteiro gerou erro.", ex);
            }
        }
    }
}
