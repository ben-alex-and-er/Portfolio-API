using Microsoft.EntityFrameworkCore.Storage;


namespace Portfolio_API.Providers.Database
{
	using Interfaces;


	/// <summary>
	/// Represents a transaction made by <see cref="TransactionManager"/>
	/// </summary>
	public class Transaction : ITransaction
	{
		private readonly IDbContextTransaction transaction;

		private int counter = 0;


		/// <summary>
		/// Constructor for <see cref="Transaction"/>
		/// </summary>
		/// <param name="transaction"></param>
		public Transaction(IDbContextTransaction transaction)
		{
			this.transaction = transaction;
		}


		void ITransaction.Commit()
		{
			counter++;

			transaction.Commit();
		}

		async Task ITransaction.CommitAsync()
		{
			counter++;

			await transaction.CommitAsync();
		}

		void IDisposable.Dispose()
		{
			if (counter == 0)
			{
				transaction.Rollback();
			}

			transaction.Dispose();
		}
	}
}
