using Newtonsoft.Json;

namespace SoftplayerCalcTest.Model
{
  public class FutureValueResultDto
  {
    [JsonProperty(PropertyName = "valorAtualizado")]
    public decimal FutureValue { get; set; }
  }
}
