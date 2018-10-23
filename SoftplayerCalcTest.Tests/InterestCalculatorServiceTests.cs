using System;
using FluentAssertions;
using SoftplayerCalcTest.Services;
using Xunit;

namespace SoftplayerCalcTest.Tests
{
  public class InterestCalculatorServiceTests
  {
    private InterestCalculatorService Service { get; } = new InterestCalculatorService();

    [Fact]
    public void CalculateFutureValue_Returns_PresentValue_If_Periods_Zero()
    {
      // Arrange

      // Act
      var result = this.Service.CalculateFutureValue(100m, .01m, 0);

      // Assert
      result.Should().Be(100m);
    }

    [Fact]
    public void CalculateFutureValue_Truncates_To_2_Decimals()
    {
      // Arrange

      // Act
      var result = this.Service.CalculateFutureValue(1.599m, .01m, 0);

      // Assert
      result.Should().Be(1.59m);
    }

    [Fact]
    public void CalculateFutureValue_Calculates_For_Positive_Values()
    {
      // Arrange

      // Act
      var result = this.Service.CalculateFutureValue(100m, .01m, 5);

      // Assert
      result.Should().Be(105.10m);
    }

    [Fact]
    public void CalculateFutureValue_Calculates_For_Negative_Rate()
    {
      // Arrange

      // Act
      var result = this.Service.CalculateFutureValue(100m, -.01m, 5);

      // Assert
      result.Should().Be(95.09m);
    }

    [Fact]
    public void CalculateFutureValue_Throws_For_Negative_Periods()
    {
      // Arrange

      // Act
      this.Invoking(_ => this.Service.CalculateFutureValue(100m, .01m, -1))
      // Assert
        .Should().Throw<ArgumentOutOfRangeException>();
    }

    [Fact]
    public void CalculateFutureValue_Throws_For_Big_Numbers()
    {
      // Arrange

      // Act
      this.Invoking(_ => this.Service.CalculateFutureValue(decimal.MaxValue, .01m, 1))
      // Assert
        .Should().Throw<OverflowException>();
    }
  }
}
