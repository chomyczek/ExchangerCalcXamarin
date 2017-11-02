// XamarinExchangerCalc
// Copyright(C) 2017
// Author Adam Kaszubowski

#region Usings

using System;

#endregion

namespace ExchangerCalc.Core.Models
{
	public class CalculatedInsulin
	{
		#region Constructors and Destructors

		public CalculatedInsulin()
		{
			this.InsulinTime = new DateTime();
		}

		#endregion

		#region Public Properties

		public DateTime InsulinTime { get; set; }

		public double LongInsulin { get; set; }

		public double StandardInsulin { get; set; }

		#endregion
	}
}