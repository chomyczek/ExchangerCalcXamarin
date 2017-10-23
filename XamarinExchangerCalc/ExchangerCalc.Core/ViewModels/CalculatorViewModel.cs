// XamarinExchangerCalc
// Copyright(C) 2017
// Author Adam Kaszubowski

#region Usings

using System.Windows.Input;

using ExchangerCalc.Core.Services;

using MvvmCross.Core.ViewModels;

#endregion

namespace ExchangerCalc.Core.ViewModels
{
	public class CalculatorViewModel : MvxViewModel
	{
		#region Fields

		private readonly ICalculator calculator;

		private double calculatedInsulin;

		private double carbohydrate;

		private double currentInsulin;

		private double weight;

		#endregion

		#region Constructors and Destructors

		public CalculatorViewModel(ICalculator calculator)
		{
			this.calculator = calculator;
		}

		#endregion

		#region Public Properties

		public double CalculatedInsulin
		{
			get
			{
				return this.calculatedInsulin;
			}
			set
			{
				this.calculatedInsulin = value;
			}
		}

		public double Carbohydrate
		{
			get
			{
				return this.carbohydrate;
			}
			set
			{
				this.carbohydrate = value;
				this.RaisePropertyChanged(() => this.Carbohydrate);
				this.Recalculate();
			}
		}

		public double CurrentInsulin
		{
			get
			{
				return this.currentInsulin;
			}
			set
			{
				this.currentInsulin = value;
				this.RaisePropertyChanged(() => this.CurrentInsulin);
				this.Recalculate();
			}
		}

		/// <summary>
		/// Navigation back button
		/// </summary>
		public ICommand NavBack
		{
			get
			{
				return new MvxCommand(() => this.Close(this));
			}
		}

		public double Weight
		{
			get
			{
				return this.weight;
			}
			set
			{
				this.weight = value;
				this.RaisePropertyChanged(() => this.weight);
				this.Recalculate();
			}
		}

		#endregion

		#region Public Methods and Operators

		/// <summary>
		/// Override the start method to perform view model initialization.
		/// </summary>
		public override void Start()
		{
			this.weight = 100;
			this.carbohydrate = 10;
			this.Recalculate();
			base.Start();
		}

		#endregion

		#region Methods

		private void Recalculate()
		{
			this.CalculatedInsulin = this.calculator.Calculate(this.Carbohydrate, this.Weight, this.CurrentInsulin);
		}

		#endregion
	}
}