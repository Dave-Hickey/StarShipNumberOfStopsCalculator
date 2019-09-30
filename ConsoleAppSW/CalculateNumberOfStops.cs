using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppSW
{
  public class CalculateNumberOfStops
  {
    public int? GetRequiredNumberOfStops(int distance, string mglt, string consumables)
    {
      if (mglt.Equals("unknown") || string.IsNullOrEmpty(mglt) || string.IsNullOrEmpty(consumables))
      {
        return null;
      }

      var duration = distance / int.Parse(mglt);
      var calculateResupplies = new CalculateResupplyCost().GetResupplyCostInHours(consumables);
      if (!calculateResupplies.HasValue)
      {
        return null;
      }
      else
      {
        return duration / calculateResupplies;
      }
    }
  }
}
