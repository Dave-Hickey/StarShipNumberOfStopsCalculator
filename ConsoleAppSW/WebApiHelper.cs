using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppSW
{
  public static class WebApiHelper
  {
    public static HttpClient SwapiClient { get; set; }

    public static void InitaliseSwapiClient()
    {
      SwapiClient = new HttpClient();
      SwapiClient.DefaultRequestHeaders.Accept.Clear();
      SwapiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    }
  }
}
