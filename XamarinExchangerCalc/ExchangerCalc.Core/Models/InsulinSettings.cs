// XamarinExchangerCalc
// Copyright(C) 2017
// Author Adam Kaszubowski

#region Usings

using System;
using System.Collections.Generic;

#endregion

namespace ExchangerCalc.Core.Models
{
	public class InsulinSettings
	{
		#region Public Properties

		public List<double> InsulinAmount { get; set; }

		public List<DateTime> MealTimes { get; set; }

		#endregion
	}
}