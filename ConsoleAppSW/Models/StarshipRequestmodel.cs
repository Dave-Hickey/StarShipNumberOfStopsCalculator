using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppSW.Models
{
  public class StarshipRequestModel
  {
    [JsonProperty("count")]
    public int Count { get; set; }
    [JsonProperty("next")]
    public string Next { get; set; }
    [JsonProperty("previous")]
    public string Previous { get; set; }
    [JsonProperty("results")]
    public IList<StarshipModel> Starships { get; set; }
  }
}
