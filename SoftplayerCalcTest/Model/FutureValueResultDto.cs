using Newtonsoft.Json;

namespace SoftplayerCalcTest.Model
{
  public class FutureValueResultDto
  {
    [JsonProperty(PropertyName = "ValorAtualizado")]
    public decimal FutureValue { get; set; }
  }
}
