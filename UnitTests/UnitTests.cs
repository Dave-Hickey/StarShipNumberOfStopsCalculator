using System;
using ConsoleAppSW;
using ConsoleAppSW.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;

namespace UnitTests
{
  [TestClass]
  public class UnitTests
  {
    readonly string StarshipJson = @"{
			'name': 'Millennium Falcon',
			'model': 'YT-1300 light freighter',
			'manufacturer': 'Corellian Engineering Corporation',
			'cost_in_credits': '100000',
			'length': '34.37',
			'max_atmosphering_speed': '1050',
			'crew': '4',
			'passengers': '6',
			'cargo_capacity': '100000',
			'consumables': '2 months',
			'hyperdrive_rating': '0.5',
			'MGLT': '75',
			'starship_class': 'Light freighter',
			'pilots': [],
			'films': [],
			'created': '2014-12-10T16:59:45.094000Z',
			'edited': '2014-12-22T17:35:44.464156Z',
			'url': ''
		}";

    [TestMethod]
    public void ShouldReturnTheCorrectNumberOfStops()
    {
      JObject json = JObject.Parse(StarshipJson);
      StarshipModel starship = json.ToObject<StarshipModel>();
      CalculateNumberOfStops stopsCalculator = new CalculateNumberOfStops();
      var numberOfStops = stopsCalculator.GetRequiredNumberOfStops(1000000, starship.MGLT, starship.consumables);
      var invalidMGLTInput = stopsCalculator.GetRequiredNumberOfStops(1, string.Empty, starship.consumables);
      var invalidConsumablesInput = stopsCalculator.GetRequiredNumberOfStops(1, starship.MGLT, string.Empty);
      Assert.IsNotNull(numberOfStops);
      Assert.AreEqual(9, numberOfStops);
      Assert.IsNull(invalidMGLTInput);
      Assert.IsNull(invalidConsumablesInput);
    }

    [TestMethod]
    public void ShouldReturnCorrectCalculationForConsumables()
    {
      string hourConsumable = "1 hour";
      string hoursConsumable = "2 Hours";
      string dayConsumable = "1 day";
      string daysConsumable = "2 days";
      string monthConsumable = "1 month";
      string monthsConsumable = "5 Months";
      string yearConsumable = "1 year";
      string yearsConsumable = "5 years";
      string emptyConsumable = string.Empty;

      CalculateResupplyCost resupplyCost = new CalculateResupplyCost();

      var hour = resupplyCost.GetResupplyCostInHours(hourConsumable);
      Assert.IsNotNull(hour);
      Assert.AreEqual(1, hour);

      var hours = resupplyCost.GetResupplyCostInHours(hoursConsumable);
      Assert.IsNotNull(hours);
      Assert.AreEqual(2, hours);

      var day = resupplyCost.GetResupplyCostInHours(dayConsumable);
      Assert.IsNotNull(day);
      Assert.AreEqual(24, day);

      var days = resupplyCost.GetResupplyCostInHours(daysConsumable);
      Assert.IsNotNull(days);
      Assert.AreEqual(48, days);

      var month = resupplyCost.GetResupplyCostInHours(monthConsumable);
      Assert.IsNotNull(month);
      Assert.AreEqual(730, month);

      var months = resupplyCost.GetResupplyCostInHours(monthsConsumable);
      Assert.IsNotNull(months);
      Assert.AreEqual(3650, months);

      var year = resupplyCost.GetResupplyCostInHours(yearConsumable);
      Assert.IsNotNull(year);
      Assert.AreEqual(8765, year);

      var years = resupplyCost.GetResupplyCostInHours(yearsConsumable);
      Assert.IsNotNull(years);
      Assert.AreEqual(43825, years);

      var empty = resupplyCost.GetResupplyCostInHours(emptyConsumable);
      Assert.IsNull(empty);
    }
  }
}
