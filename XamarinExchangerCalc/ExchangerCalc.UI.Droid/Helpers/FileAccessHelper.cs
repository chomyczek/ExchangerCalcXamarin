// XamarinExchangerCalc
// Copyright(C) 2018
// Author Adam Kaszubowski

#region Usings

using System;
using System.IO;

#endregion

namespace ExchangerCalc.UI.Droid.Helpers
{
	public class FileAccessHelper
	{
		#region Public Methods and Operators

		public static string GetLocalFilePath(string filename)
		{
			var path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			return Path.Combine(path, filename);
		}

		#endregion
	}
}