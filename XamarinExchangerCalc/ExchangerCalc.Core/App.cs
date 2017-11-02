// XamarinExchangerCalc
// Copyright(C) 2017
// Author Adam Kaszubowski

#region Usings

using ExchangerCalc.Core.Services;

using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;

#endregion

namespace ExchangerCalc.Core
{
	public class App : MvxApplication
	{
		#region Constructors and Destructors

		public App()
		{
			Mvx.RegisterType<ICalculator, Calculator>();

			var appStart = new CustomAppStart();
			Mvx.RegisterSingleton<IMvxAppStart>(appStart);
		}

		#endregion
	}
}