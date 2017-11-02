// XamarinExchangerCalc
// Copyright(C) 2017
// Author Adam Kaszubowski

#region Usings

using Android.App;

using MvvmCross.Droid.Views;

#endregion

namespace ExchangerCalc.UI.Droid.Views
{
	[Activity(Label = "Calculate meal", NoHistory = true)]
	public class CalculatorView : MvxActivity
	{
		#region Methods

		protected override void OnViewModelSet()
		{
			this.SetContentView(Resource.Layout.View_Calculator);
		}

		#endregion
	}
}