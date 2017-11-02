// XamarinExchangerCalc
// Copyright(C) 2017
// Author Adam Kaszubowski

#region Usings

using ExchangerCalc.Core.Enums;

#endregion

namespace ExchangerCalc.Core.Models
{
	public class Meal
	{
		#region Public Properties

		public double Carbohydrate { get; set; }

		public double DefaultMeasure { get; set; }

		public double Fat { get; set; }

		public string Name { get; set; }

		public double Protein { get; set; }

		public Unit UnitMeasure { get; set; }

		#endregion
	}
}