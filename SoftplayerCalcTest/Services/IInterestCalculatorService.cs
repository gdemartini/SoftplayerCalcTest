namespace SoftplayerCalcTest.Services
{
  public interface IInterestCalculatorService
  {
    decimal CalculateFutureValue(decimal presentValue, decimal rate, decimal periods);
  }
}
