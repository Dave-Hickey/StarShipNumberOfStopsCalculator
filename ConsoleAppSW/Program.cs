using ConsoleAppSW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppSW
{
  class Program
  {
    static async Task Main(string[] args)
    {
      await RunStarshipNuberOfStopsCalculator.Run();
    }   
  }
}
