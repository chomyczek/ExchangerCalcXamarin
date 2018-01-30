// XamarinExchangerCalc
// Copyright(C) 2018
// Author Adam Kaszubowski

#region Usings

using Android.Content;

using ExchangerCalc.Core;
using ExchangerCalc.UI.Droid.Helpers;

using MvvmCross.Core.ViewModels;
using MvvmCross.Droid.Platform;
using MvvmCross.Platform;
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
			var dbConn = FileAccessHelper.GetLocalFilePath("exchangerCalc.db3");
			Mvx.RegisterSingleton(new Repository(dbConn));
			return new App();
		}

		/// <summary>
		/// WA for MvvmCross.Core.Platform.LogProviders.ConsoleLogProvider null exception.
		/// </summary>
		protected override MvxLogProviderType GetDefaultLogProviderType() => MvxLogProviderType.None;

		#endregion
	}
}