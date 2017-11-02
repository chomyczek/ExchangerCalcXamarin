// XamarinExchangerCalc
// Copyright(C) 2017
// Author Adam Kaszubowski

#region Usings

using Android.Content;

using ExchangerCalc.Core;

using MvvmCross.Core.ViewModels;
using MvvmCross.Droid.Platform;

#endregion

namespace ExchangerCalc.UI.Droid
{
	public class Setup : MvxAndroidSetup
	{
		#region Constructors and Destructors

		public Setup(Context applicationContext)
			: base(applicationContext)
		{
		}

		#endregion

		#region Methods

		protected override IMvxApplication CreateApp()
		{
			return new App();
		}

		#endregion
	}
}