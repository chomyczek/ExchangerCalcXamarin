// XamarinExchangerCalc
// Copyright(C) 2018
// Author Adam Kaszubowski

#region Usings

using System.Collections.Generic;
using System.Threading.Tasks;

using ExchangerCalc.Core.Models;

using SQLite;

#endregion

namespace ExchangerCalc.Core
{
	public class Repository
	{
		#region Fields

		private readonly SQLiteAsyncConnection conn;

		#endregion

		#region Constructors and Destructors

		public Repository(string dbPath)
		{
			this.conn = new SQLiteAsyncConnection(dbPath);
			this.PrepareDb();
		}

		#endregion

		#region Public Methods and Operators

		/// <summary>
		/// Usage:
		/// Mvx.Resolve
		/// <Repository>
		/// ().CreateMeal(meal).Wait();
		/// Close(this);
		/// </summary>
		public async Task CreateMeal(Meal meal)
		{
			await this.conn.InsertAsync(meal).ConfigureAwait(false);
		}

		public async Task DeleteMeal(Meal meal)
		{
			await this.conn.DeleteAsync(meal).ConfigureAwait(false);
		}

		public Task<List<Meal>> GetAllMeals()
		{
			return this.conn.Table<Meal>().ToListAsync();
		}

		public async Task UpdateMeal(Meal meal)
		{
			await this.conn.UpdateAsync(meal).ConfigureAwait(false);
		}

		#endregion

		#region Methods

		private void PrepareDb()
		{
			this.conn.CreateTableAsync<Meal>().Wait();
		}

		#endregion
	}
}