// XamarinExchangerCalc
// Copyright(C) 2017
// Author Adam Kaszubowski

#region Usings

using System.Windows.Input;

using MvvmCross.Core.ViewModels;

#endregion

namespace ExchangerCalc.Core.ViewModels
{
	public class MenuViewModel : MvxViewModel
	{
		#region Public Properties

		public ICommand NavigateCalculator
		{
			get
			{
				return new MvxCommand(() => this.ShowViewModel<CalculatorViewModel>());
			}
		}

		#endregion
	}
}