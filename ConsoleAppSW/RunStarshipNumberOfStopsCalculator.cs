using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppSW
{
  public static class RunStarshipNumberOfStopsCalculator
  {
    public static async Task Run()
    {
      string url = "https://swapi.co/api/starships/";
      int distance = GetDistance();
      WebApiHelper.InitaliseSwapiClient();
      var starShips = await StarshipProcessor.RequestStarships(url);
      CalculateNumberOfStops stopsCalculator = new CalculateNumberOfStops();
      int index = 1;
      foreach (var item in starShips.OrderBy(n => n.name))
      {
        OutputResults(index, distance, item, stopsCalculator);
        index++;
      }
      Console.WriteLine("\nPress any key to exit.");
      Console.ReadKey();
    }

    private static void OutputResults(int index, int distance, Models.StarshipModel item, CalculateNumberOfStops stopsCalculatore)
    {
      var result = stopsCalculatore.GetRequiredNumberOfStops(distance, item.MGLT, item.consumables);
      var noOfStops = result.HasValue ? result.ToString() : "Unknown";
      Console.WriteLine(index.ToString() + "): " + item.name + ": " + noOfStops) ;
    }

    private static int GetDistance()
    {
      Console.WriteLine("Please Enter a value for distance in mega lights to calculate the number of stops:");
      int distance = 0;

      while (!int.TryParse(Console.ReadLine(), out distance) || distance < 0)
      {        
        if(distance < 0)
        {
          Console.WriteLine("The distance value cannot be negative.");
        }
        else
        {
          Console.WriteLine("Please Enter a valid integer value.");
        }
      }

      return distance;
    }
  }
}
