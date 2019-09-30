using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppSW
{
  public class CalculateResupplyCost
  {
    const int DAY = 24;
    const int WEEK = 24 * 7;
    const int MONTH = 730; // (365 / 12 * 24)
    const int YEAR = 8765; // 24 * 365.2422;

    private readonly List<List<string>> TimePeriods = new List<List<string>>
      {
      // values from the api can be singular or plural
        new List<string>{ "hour", "hours" },
        new List<string>{ "day", "days" },
        new List<string>{ "week", "weeks" },
        new List<string> { "month", "months" },
        new List<string> { "year", "years" }
      };

    public int? GetResupplyCostInHours(string consumables)
    {
      if (consumables.Equals("unknown") || string.IsNullOrEmpty(consumables))
      {
        return null;
      }

      var consumable = consumables.Split(' ');

      if (TimePeriods[0].Contains(consumable[1].ToLower()))
      {
        return int.Parse(consumable[0]);
      }
      if (TimePeriods[1].Contains(consumable[1].ToLower()))
      {
        return int.Parse(consumable[0]) * DAY;
      }
      if (TimePeriods[2].Contains(consumable[1].ToLower()))
      {
        return int.Parse(consumable[0]) * WEEK;
      }
      if (TimePeriods[3].Contains(consumable[1].ToLower()))
      {
        return int.Parse(consumable[0]) * MONTH;
      }
      if (TimePeriods[4].Contains(consumable[1].ToLower()))
      {
        return int.Parse(consumable[0]) * YEAR;
      }
      
      return null;
    }
  }
}
