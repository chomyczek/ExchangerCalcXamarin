// XamarinExchangerCalc
// Copyright(C) 2017
// Author Adam Kaszubowski

#region Usings

using Android.App;

using MvvmCross.Droid.Views;

#endregion

namespace ExchangerCalc.UI.Droid.Views
{
	[Activity(Label = "Menu")]
	public class MenuView : MvxActivity
	{
		#region Methods

		protected override void OnViewModelSet()
		{
			this.SetContentView(Resource.Layout.View_Menu);
		}

		#endregion
	}
}