// XamarinExchangerCalc
// Copyright(C) 2017
// Author Adam Kaszubowski

#region Usings

using Android.Content;

using ExchangerCalc.Core;

using MvvmCross.Core.ViewModels;
using MvvmCross.Droid.Platform;
using MvvmCross.Platform.Logging;

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

		/// <summary>
		/// WA for MvvmCross.Core.Platform.LogProviders.ConsoleLogProvider null exception.
		/// </summary>
		protected override MvxLogProviderType GetDefaultLogProviderType() => MvxLogProviderType.None;

		#endregion
	}
}