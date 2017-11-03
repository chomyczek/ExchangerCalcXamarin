// XamarinExchangerCalc
// Copyright(C) 2017
// Author Adam Kaszubowski

#region Usings

using System.Windows.Input;

using ExchangerCalc.Core.Enums;
using ExchangerCalc.Core.Models;
using ExchangerCalc.Core.Services;

using MvvmCross.Core.ViewModels;

#endregion

namespace ExchangerCalc.Core.ViewModels
{
	public class CalculatorViewModel : MvxViewModel
	{
		#region Fields

		private readonly ICalculator calculator;

		private CalculatedInsulin calculatedInsulin;

		private double currentInsulin;

		private Meal meal;

		#endregion

		#region Constructors and Destructors

		public CalculatorViewModel(ICalculator calculator)
		{
			this.calculator = calculator;
		}

		#endregion

		#region Public Properties

		public string CalculatedInsulinTime
			=>
				this.CalculatedInsulin.InsulinTime.Hour > 0
					? $"{this.CalculatedInsulin.InsulinTime.Hour}H {this.CalculatedInsulin.InsulinTime.Minute % 60}M"
					: $"{this.CalculatedInsulin.InsulinTime.Minute}M";

		public double CalculatedLongInsulin => this.CalculatedInsulin.LongInsulin;

		public double CalculatedStandardInsulin => this.CalculatedInsulin.StandardInsulin;

		public double Carbohydrate
		{
			get
			{
				return this.meal.Carbohydrate;
			}
			set
			{
				this.meal.Carbohydrate = value;
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

		public double Fat
		{
			get
			{
				return this.meal.Fat;
			}
			set
			{
				this.meal.Fat = value;
				this.RaisePropertyChanged(() => this.Fat);
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

		public double Protein
		{
			get
			{
				return this.meal.Protein;
			}
			set
			{
				this.meal.Protein = value;
				this.RaisePropertyChanged(() => this.Protein);
				this.Recalculate();
			}
		}

		public double Weight
		{
			get
			{
				return this.meal.Weight;
			}
			set
			{
				this.meal.Weight = value;
				this.RaisePropertyChanged(() => this.Weight);
				this.Recalculate();
			}
		}

		#endregion

		#region Properties

		private CalculatedInsulin CalculatedInsulin
		{
			get
			{
				return this.calculatedInsulin;
			}
			set
			{
				this.calculatedInsulin = value;
				this.RaisePropertyChanged(() => this.CalculatedLongInsulin);
				this.RaisePropertyChanged(() => this.CalculatedStandardInsulin);
				this.RaisePropertyChanged(() => this.CalculatedInsulinTime);
			}
		}

		#endregion

		#region Public Methods and Operators

		/// <summary>
		/// Override the start method to perform view model initialization.
		/// </summary>
		public override void Start()
		{
			this.meal = new Meal { Weight = 200, Fat = 0.5, Carbohydrate = 9.2, Protein = 0.7, UnitMeasure = Unit.Mlliliters };
			this.currentInsulin = 1.6;
			this.Recalculate();
			base.Start();
		}

		#endregion

		#region Methods

		private void Recalculate()
		{
			this.CalculatedInsulin = this.calculator.Calculate(this.meal, this.currentInsulin);
		}

		#endregion
	}
}