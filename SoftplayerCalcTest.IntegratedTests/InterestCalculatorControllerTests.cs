using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json.Linq;
using Xunit;

namespace SoftplayerCalcTest.IntegratedTests
{
  public class InterestCalculatorControllerTests: IClassFixture<WebApplicationFactory<Startup>>
  {
    private WebApplicationFactory<Startup> WebApplicationFactory { get; }


    public InterestCalculatorControllerTests(WebApplicationFactory<Startup> webApplicationFactory)
    {
      this.WebApplicationFactory = webApplicationFactory;
    }

    [Theory]
    [InlineData(null, null)]
    [InlineData("", "")]
    [InlineData("10", null)]
    [InlineData(null, "10")]
    [InlineData("aa", "10")]
    [InlineData("10", "-1")]
    [InlineData("0", "4294967295")] // uint.MaxValue = 4294967295
    [InlineData("79228162514264337593543950336", "10")] // decimal.MaxValue = 79228162514264337593543950335M
    public async Task Get_Returns_BadRequest_For_Invalid_Input(string presentValue, string periods)
    {
      // Arrange
      var client = this.WebApplicationFactory.CreateClient();
      var parms = this.GetQueryString(presentValue, periods);

      // Act
      var response = await client.GetAsync("/api/calculajuros" + parms);

      //Assert
      response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }

    [Theory]
    [InlineData("0", "0")]
    [InlineData("0", "10")]
    [InlineData("10", "0")]
    [InlineData("10", "10")]
    [InlineData("-10", "10")]
    [InlineData("79228162514264337593543950335", "0")] // decimal.MaxValue = 79228162514264337593543950335M
    public async Task Get_Returns_Ok_For_Valid_Input(string presentValue, string periods)
    {
      // Arrange
      var client = this.WebApplicationFactory.CreateClient();
      var parms = this.GetQueryString(presentValue, periods);

      // Act
      var response = await client.GetAsync("/api/calculajuros" + parms);

      //Assert
      response.StatusCode.Should().Be(HttpStatusCode.OK);
      var responseData = JObject.Parse(response.Content.ReadAsStringAsync().Result);      
      responseData.Should().NotBeNull();
      responseData["valorAtualizado"].Should().NotBeNull();
    }

    private string GetQueryString(string presentValue, string periods)
    {
      var query = new QueryString();
      if (presentValue != null)
        query = query.Add("valorinicial", presentValue);
      if (periods != null)
        query = query.Add("meses", periods);
      return query.ToUriComponent();
    }
  }
}
