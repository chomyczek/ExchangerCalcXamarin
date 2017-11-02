// XamarinExchangerCalc
// Copyright(C) 2017
// Author Adam Kaszubowski

#region Usings

using ExchangerCalc.Core.Models;

#endregion

namespace ExchangerCalc.Core.Services
{
	public interface ICalculator
	{
		#region Public Methods and Operators

		double Calculate(double carbohydrate, double weight, double insulin);

		CalculatedInsulin Calculate(Meal meal, double insulin);

		#endregion
	}
}