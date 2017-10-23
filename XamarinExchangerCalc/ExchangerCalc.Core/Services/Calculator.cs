// XamarinExchangerCalc
// Copyright(C) 2017
// Author Adam Kaszubowski

namespace ExchangerCalc.Core.Services
{
	public class Calculator : ICalculator
	{
		#region Public Methods and Operators

		public double Calculate(double carbohydrate, double weight, double insulin)
		{
			return (carbohydrate / 10) * (weight / 100) * insulin;
		}

		#endregion
	}
}