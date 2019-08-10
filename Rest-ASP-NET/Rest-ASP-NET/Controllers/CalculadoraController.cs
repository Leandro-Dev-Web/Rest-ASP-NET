using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Rest_ASP_NET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculadoraController : ControllerBase
    {

        // GET api/values/5
        [HttpGet("{primeiroNumero}/{segundoNumero}")]
        public ActionResult<string> Soma(string primeiroNumero, string segundoNumero )
        {
            if ( IsNumeric( primeiroNumero)&& IsNumeric(primeiroNumero))
            {
                var soma = ConvertToDecimal(primeiroNumero) + ConvertToDecimal(segundoNumero);

                return Ok(soma.ToString());
            }
            return BadRequest("Digito Inválido, Digite um Número! ");
        }

        private decimal ConvertToDecimal(string strNumero)
        {
            decimal valorDecimal;
            if( decimal.TryParse(strNumero, out valorDecimal))
            {
                return valorDecimal;
            }
            return 0;
        }

        private bool IsNumeric(string strNumero)
        {
            double numero;
            bool isNumber = double.TryParse(strNumero, NumberStyles.Any, NumberFormatInfo.InvariantInfo, out numero);
            return isNumber;

        }
    }
}
