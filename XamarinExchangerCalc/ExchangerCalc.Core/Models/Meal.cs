// XamarinExchangerCalc
// Copyright(C) 2018
// Author Adam Kaszubowski

#region Usings

using ExchangerCalc.Core.Enums;

using SQLite;

#endregion

namespace ExchangerCalc.Core.Models
{
	[Table(nameof(Meal))]
	public class Meal
	{
		#region Constructors and Destructors

		public Meal()
		{
			this.Carbohydrate = 0;
			this.Weight = 100;
			this.Fat = 0;
			this.Name = string.Empty;
			this.Protein = 0;
			this.UnitMeasure = Unit.Grams;
			this.IsPreDefined = false;
		}

		#endregion

		#region Public Properties

		public double Carbohydrate { get; set; }

		public double Fat { get; set; }

		[PrimaryKey, AutoIncrement]
		public int Id { get; set; }

		public bool IsPreDefined { get; set; }

		[NotNull]
		public string Name { get; set; }

		public double Protein { get; set; }

		public Unit UnitMeasure { get; set; }

		public double Weight { get; set; }

		#endregion
	}
}