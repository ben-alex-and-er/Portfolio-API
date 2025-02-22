using Database.Models;


namespace Portfolio_API.Providers.Database
{
	using Interfaces;


	/// <summary>
	/// Manager for handling <see cref="PortfolioContext"/> transactions
	/// </summary>
	public class TransactionManager : ITransactionManager
	{
		private readonly PortfolioContext context;


		/// <summary>
		/// Constructor for <see cref="TransactionManager"/>
		/// </summary>
		/// <param name="context"></param>
		public TransactionManager(PortfolioContext context)
		{
			this.context = context;
		}


		ITransaction ITransactionManager.CreateTransaction()
			=> new Transaction(context.Database.BeginTransaction());

		async Task<ITransaction> ITransactionManager.CreateTransactionAsync()
			=> new Transaction(await context.Database.BeginTransactionAsync());
	}
}
