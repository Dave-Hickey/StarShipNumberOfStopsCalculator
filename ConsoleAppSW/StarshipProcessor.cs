using ConsoleAppSW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppSW
{
  public static class StarshipProcessor
  {
    public static async Task<List<StarshipModel>> RequestStarships(string baseUrl) 
    {
      var starships = new List<StarshipModel>();
      var nextUrl = baseUrl;

      do
      {
        await WebApiHelper.SwapiClient.GetAsync(nextUrl)
            .ContinueWith(async (starShipsSearchTask) =>
            {
              var response = await starShipsSearchTask;
              if (response.IsSuccessStatusCode)
              {
                StarshipRequestModel result = await response.Content.ReadAsAsync<StarshipRequestModel>();
                if (result != null)
                {
                  if (result.Starships.Any())
                  {
                    starships.AddRange(result.Starships.ToList());
                  }

                  nextUrl = (!string.IsNullOrEmpty(result.Next)) ? result.Next : string.Empty;
                }
              }
              else
              {                
                nextUrl = string.Empty;
                throw new Exception(response.ReasonPhrase);
              }
            });

      } while (!string.IsNullOrEmpty(nextUrl));
      WebApiHelper.SwapiClient.Dispose();
      return starships;
    }
  }
}
