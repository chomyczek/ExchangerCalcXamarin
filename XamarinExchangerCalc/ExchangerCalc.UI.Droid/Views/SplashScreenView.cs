// XamarinExchangerCalc
// Copyright(C) 2017
// Author Adam Kaszubowski

#region Usings

using Android.App;

using MvvmCross.Droid.Views;

#endregion

namespace ExchangerCalc.UI.Droid.Views
{
	[Activity(Label = "Exchanger calc", MainLauncher = true, NoHistory = true, Icon = "@drawable/icon")]
	public class SplashScreenActivity : MvxSplashScreenActivity
	{
		#region Constructors and Destructors

		public SplashScreenActivity()
			: base(Resource.Layout.View_SplashScreen)
		{
		}

		#endregion
	}
}