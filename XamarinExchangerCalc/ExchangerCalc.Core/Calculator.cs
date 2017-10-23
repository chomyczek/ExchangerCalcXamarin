using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangerCalc.Core
{
	public class Calculator: ICalculator
	{
		public double Calculate(double carbohydrate, double weight, double insulin)
		{
			return (carbohydrate / 10) * (weight / 100) * insulin;
		}
	}
}
