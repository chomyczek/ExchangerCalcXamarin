﻿// XamarinExchangerCalc
// Copyright(C) 2017
// Author Adam Kaszubowski

#region Usings

using System;

using ExchangerCalc.Core.Enums;
using ExchangerCalc.Core.Models;
using ExchangerCalc.Core.Services;

using Xunit;

#endregion

namespace ExchangerCalc.Tests
{
	public class CalculatorTests
	{
		#region Public Methods and Operators

		[Fact]
		public void Corect_time_for_normal_data()
		{
			var meal = new Meal { UnitMeasure = Unit.Grams, Carbohydrate = 0, Protein = 25, Fat = 11, Weight = 76 };
			var insulin = 1.5;
			var calc = new Calculator();
			var expected = new DateTime().AddHours(3);

			var calculated = calc.Calculate(meal, insulin);

			Assert.Equal(expected, calculated.InsulinTime);
		}

		[Fact]
		public void Corect_time_for_normal_data_v2()
		{
			var meal = new Meal { UnitMeasure = Unit.Grams, Carbohydrate = 0, Protein = 20, Fat = 20, Weight = 100 };
			var insulin = 1.5;
			var calc = new Calculator();
			var expected = new DateTime().AddHours(5);

			var calculated = calc.Calculate(meal, insulin);

			Assert.Equal(expected, calculated.InsulinTime);
		}

		[Fact]
		public void Corect_time_for_small_data()
		{
			var meal = new Meal { UnitMeasure = Unit.Grams, Carbohydrate = 0, Protein = 10, Fat = 10, Weight = 50 };
			var insulin = 1.5;
			var calc = new Calculator();
			var expected = new DateTime().AddHours(2);

			var calculated = calc.Calculate(meal, insulin);

			Assert.Equal(expected, calculated.InsulinTime);
		}

		[Fact]
		public void Corect_time_for_very_small_data()
		{
			var meal = new Meal { UnitMeasure = Unit.Grams, Carbohydrate = 0, Protein = 1, Fat = 1, Weight = 1 };
			var insulin = 1.5;
			var calc = new Calculator();
			var expected = new DateTime();

			var calculated = calc.Calculate(meal, insulin);

			Assert.Equal(expected, calculated.InsulinTime);
		}

		[Fact]
		public void Corect_time_with_half_hour_for_normal_data()
		{
			var meal = new Meal { UnitMeasure = Unit.Grams, Carbohydrate = 0, Protein = 25, Fat = 11, Weight = 111 };
			var insulin = 1.5;
			var calc = new Calculator();
			var expected = new DateTime().AddHours(3).AddMinutes(30);

			var calculated = calc.Calculate(meal, insulin);

			Assert.Equal(expected, calculated.InsulinTime);
		}

		[Fact]
		public void Corect_time_with_half_hour_for_normal_data_v2()
		{
			var meal = new Meal { UnitMeasure = Unit.Grams, Carbohydrate = 0, Protein = 25, Fat = 25, Weight = 100 };
			var insulin = 1.5;
			var calc = new Calculator();
			var expected = new DateTime().AddHours(5).AddMinutes(30);

			var calculated = calc.Calculate(meal, insulin);

			Assert.Equal(expected, calculated.InsulinTime);
		}

		[Fact]
		public void Correct_long_timed_insulin_for_default_input()
		{
			var meal = new Meal();
			var insulin = default(double);
			var calc = new Calculator();
			var expected = 0;

			var calculated = calc.Calculate(meal, insulin);

			Assert.Equal(expected, calculated.LongInsulin);
		}

		[Fact]
		public void Correct_standard_insulin_for_default_input()
		{
			var meal = new Meal();
			var insulin = default(double);
			var calc = new Calculator();
			var expected = 0;

			var calculated = calc.Calculate(meal, insulin);

			Assert.Equal(expected, calculated.StandardInsulin);
		}

		[Fact]
		public void Correct_time_for_big_data()
		{
			var meal = new Meal { UnitMeasure = Unit.Portions, Carbohydrate = 0, Protein = 100, Fat = 100, Weight = 100 };
			var insulin = 1.5;
			var calc = new Calculator();
			var expected = new DateTime().AddHours(8);

			var calculated = calc.Calculate(meal, insulin);

			Assert.Equal(expected, calculated.InsulinTime);
		}

		[Fact]
		public void Correct_time_for_default_input()
		{
			var meal = new Meal();
			var insulin = default(double);
			var calc = new Calculator();
			var expected = new DateTime();

			var calculated = calc.Calculate(meal, insulin);

			Assert.Equal(expected, calculated.InsulinTime);
		}

		#endregion
	}
}