using Microsoft.AspNetCore.Mvc;
using SoftplayerCalcTest.Model;

namespace SoftplayerCalcTest.Controllers
{
  [Route("api/showmethecode")]
  [ApiController]
  public class ShowMeTheCodeController : ControllerBase
  {
    /// <summary>
    /// Retorna a URL onde encontra-se o código fonte da aplicação.
    /// </summary>
    /// <returns>a URL onde encontra-se o código fonte da aplicação.</returns>
    [HttpGet]
    [ProducesResponseType(200)]
    public ActionResult<ShowMeTheCodeResultDto> Get()
    {
      return this.Ok(new ShowMeTheCodeResultDto
      {
        Url = "https://github.com/gdemartini/SoftplayerCalcTest"
      });
    }
  }
}
