// XamarinExchangerCalc
// Copyright(C) 2017
// Author Adam Kaszubowski

#region Usings

using System;

using ExchangerCalc.Core.Enums;
using ExchangerCalc.Core.Models;

#endregion

namespace ExchangerCalc.Core.Services
{
	public class Calculator : ICalculator
	{
		#region Constants

		/// <summary>
		/// Number of grams required for 1 carbohydrate exchanger.
		/// </summary>
		private const int CarbohydrateDevider = 10;

		/// <summary>
		/// Number of kilocaolries contained in 1 gram of fat.
		/// </summary>
		private const int FatMultiplier = 9;

		/// <summary>
		/// Max number of protein and fats exchangers.
		/// </summary>
		private const int MaxProteinsAndFats = 6;

		/// <summary>
		/// Minimum number of protein and fats exchangers.
		/// </summary>
		private const double MinimalProteinsAndFats = 0.5;

		/// <summary>
		/// Number of kilocaolries required for 1 proteins and fats exchanger.
		/// </summary>
		private const int ProteinFattyDevider = 100;

		/// <summary>
		/// Number of kilocalories contained in 1 gram of protein.
		/// </summary>
		private const int ProteinMultiplier = 4;

		private const int StartTime = 2;// 3;

		#endregion

		#region Public Methods and Operators

		public CalculatedInsulin Calculate(Meal meal, double insulin)
		{
			var calculatedInsulin = new CalculatedInsulin();
			var proteinsAndFats = this.CalculateProteinsAndFats(meal);

			calculatedInsulin.StandardInsulin = this.CalculateCarbohydrateInsulin(meal, insulin);
			calculatedInsulin.LongInsulin = this.CalculateProteinsAndFatsInsulin(proteinsAndFats, insulin);
			calculatedInsulin.InsulinTime = this.CalculateInsulinTime(proteinsAndFats);

			return calculatedInsulin;
		}

		#endregion

		#region Methods

		private double CalculateCarbohydrateInsulin(Meal meal, double insulin)
		{
			var carbohydrates = (meal.Carbohydrate / CarbohydrateDevider);
			var weightMultiplier = meal.Weight / this.GetWeightDivider(meal.UnitMeasure);
			return carbohydrates * weightMultiplier * insulin;
		}

		private DateTime CalculateInsulinTime(double proteinsAndFats)
		{
			var time = new DateTime();

			if (proteinsAndFats < MinimalProteinsAndFats)
			{
				return time;
			}

			time = time.AddHours(StartTime);

			if (proteinsAndFats < 1)
			{
				return time;
			}

			// Max time shouldn't be greater then 8
			if (proteinsAndFats < MaxProteinsAndFats)
			{
				time = time.AddHours((int)proteinsAndFats);
			}
			else
			{
				return time.AddHours(MaxProteinsAndFats);
			}

			if (proteinsAndFats % 1 >0.5)
			{
				time = time.AddMinutes(30);
			}
			return time;
		}

		private double CalculateProteinsAndFats(Meal meal)
		{
			var proteinAndFatKcal = meal.Protein * ProteinMultiplier + meal.Fat * FatMultiplier;
			var weightMultiplier = meal.Weight / this.GetWeightDivider(meal.UnitMeasure);
			return proteinAndFatKcal / ProteinFattyDevider * weightMultiplier;
		}

		private double CalculateProteinsAndFatsInsulin(double proteinsAndFats, double insulin)
		{
			if (proteinsAndFats > MinimalProteinsAndFats)
			{
				return proteinsAndFats * insulin / 2;
			}
			return 0;
		}

		private double GetWeightDivider(Unit unit)
		{
			switch (unit)
			{
				case Unit.Portions:
					return 1;
				default:
					return 100;
			}
		}

		#endregion
	}
}