using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ExchangerCalc.Core.Models;

using SQLite;

namespace ExchangerCalc.Core
{
	public class Repository
	{
		private readonly SQLiteAsyncConnection conn;

		public Repository(string dbPath)
		{
			this.conn = new SQLiteAsyncConnection(dbPath);
			this.PrepareDb();
		}

		private void PrepareDb()
		{
			this.conn.CreateTableAsync<Meal>().Wait();
		}

		public async void CreateMeal(Meal meal)
		{
			await this.conn.InsertAsync(meal).ConfigureAwait(false);
		}

		public Task<List<Meal>> GetAllMeals()
		{
			return this.conn.Table<Meal>().ToListAsync();
		}

	}
}
