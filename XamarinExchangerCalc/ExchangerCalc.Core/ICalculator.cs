// XamarinExchangerCalc
// Copyright(C) 2017
// Author Adam Kaszubowski

namespace ExchangerCalc.Core
{
	public interface ICalculator
	{
		#region Public Methods and Operators

		double Calculate(double carbohydrate,double weight, double insulin);

		#endregion
	}
}