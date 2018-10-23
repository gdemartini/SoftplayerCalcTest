using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using SoftplayerCalcTest.Controllers;
using SoftplayerCalcTest.Model;
using SoftplayerCalcTest.Services;
using Xunit;

namespace SoftplayerCalcTest.Tests
{
  public class InterestCalculatorControllerTests
  {
    private InterestCalculatorController Controller { get; }
    private Mock<IInterestCalculatorService> InterestCalculatorServiceMock { get; }

    public InterestCalculatorControllerTests()
    {
      this.InterestCalculatorServiceMock = new Mock<IInterestCalculatorService>();
      this.Controller = new InterestCalculatorController(this.InterestCalculatorServiceMock.Object);
    }

    [Fact]
    public void Get_Returns_Value_Calculated_By_Service()
    {
      // Arrange
      this.InterestCalculatorServiceMock.Setup(svc => svc.CalculateFutureValue(It.IsAny<decimal>(), It.IsAny<decimal>(), It.IsAny<decimal>()))
        .Returns(10m);

      // Act
      var actionResult = this.Controller.Get(1m, 1);

      // Assert
      actionResult.Should().NotBeNull();
      actionResult.Result.Should().BeOfType<OkObjectResult>();
      actionResult.Result.As<OkObjectResult>().Value.Should().NotBeNull().And.BeOfType<FutureValueResultDto>();
      actionResult.Result.As<OkObjectResult>().Value.As<FutureValueResultDto>().FutureValue.Should().Be(10m);
    }
  }
}
