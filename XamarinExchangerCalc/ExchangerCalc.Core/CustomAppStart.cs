// XamarinExchangerCalc
// Copyright(C) 2017
// Author Adam Kaszubowski

#region Usings

using ExchangerCalc.Core.ViewModels;

using MvvmCross.Core.ViewModels;

#endregion

namespace ExchangerCalc.Core
{
	public class CustomAppStart : MvxNavigatingObject, IMvxAppStart
	{
		#region Public Methods and Operators

		public void Start(object hint = null)
		{
			this.ShowViewModel<CalculatorViewModel>();
		}

		#endregion
	}
}