using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json.Linq;
using Xunit;

namespace SoftplayerCalcTest.IntegratedTests
{
  public class ShowMeTheCodeControllerTests : IClassFixture<WebApplicationFactory<Startup>>
  {
    private WebApplicationFactory<Startup> WebApplicationFactory { get; }


    public ShowMeTheCodeControllerTests(WebApplicationFactory<Startup> webApplicationFactory)
    {
      this.WebApplicationFactory = webApplicationFactory;
    }

    [Fact]
    public async Task Get_Returns_Ok()
    {
      // Arrange
      var client = this.WebApplicationFactory.CreateClient();

      // Act
      var response = await client.GetAsync("/api/showmethecode");

      //Assert
      response.StatusCode.Should().Be(HttpStatusCode.OK);
      var responseData = JObject.Parse(response.Content.ReadAsStringAsync().Result);      
      responseData.Should().NotBeNull();
      responseData["url"].Should().NotBeNull();
    }
  }
}
