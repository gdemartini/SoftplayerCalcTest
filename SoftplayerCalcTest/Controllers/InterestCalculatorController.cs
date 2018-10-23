using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using SoftplayerCalcTest.Model;
using SoftplayerCalcTest.Services;

namespace SoftplayerCalcTest.Controllers
{
  [Route("api/calculajuros")]
  [ApiController]
  public class InterestCalculatorController : ControllerBase
  {
    public IInterestCalculatorService InterestCalculatorService { get; }

    public InterestCalculatorController(IInterestCalculatorService interestCalculatorService)
    {
      this.InterestCalculatorService = interestCalculatorService ?? throw new ArgumentNullException(nameof(interestCalculatorService));
    }

    /// <summary>
    /// Calcula o valor futuro considerando os parâmetros de entrada 'valorinicial' e 'meses', aplicando juros compostos de 1% ao mês.
    /// </summary>
    /// <returns>O valor futuro considerando os parâmetros de entrada.</returns>
    /// <response code="200">Se os parâmetros forem válidos e o cálculo efetuado corretamente.</response>
    /// <response code="400">Se os parâmetros forem inválidos.</response>
    [HttpGet]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    public ActionResult<FutureValueResultDto> Get(
      [FromQuery(Name = "valorinicial")]
      [Required(ErrorMessage = "O parâmetro valorinicial é obrigatório")]
      decimal? presentValue,

      [FromQuery(Name = "meses")]
      [Required(ErrorMessage = "O parâmetro meses é obrigatório")]
      uint? months)
    {
      try
      {
        var response = new FutureValueResultDto
        {
          FutureValue = this.InterestCalculatorService.CalculateFutureValue(presentValue.Value, Constants.InterestRate, months.Value)
        };

        return this.Ok(response);
      }
      catch(OverflowException)
      {
        return this.BadRequest(new { message = "Os parâmetros informados requerem um cálculo com precisão maior do que a suportada pelo sistema." });
      }
    }
  }
}
