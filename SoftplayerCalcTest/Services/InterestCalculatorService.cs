using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftplayerCalcTest.Services
{
  public class InterestCalculatorService : IInterestCalculatorService
  {
    public decimal CalculateFutureValue(decimal presentValue, decimal rate, decimal periods)
    {
      if (periods < 0)
        throw new ArgumentOutOfRangeException(nameof(periods), $"{nameof(periods)} must be greater than or equal to zero.");

      var result = presentValue * (decimal)Math.Pow(1 + (double)rate, (double)periods);

      return this.TruncateResult(result);
    }

    private decimal TruncateResult(decimal value)
    {
      var integralValue = Math.Truncate(value);
      return integralValue + Math.Truncate((value - integralValue) * 100) / 100;
    }
  }
}
