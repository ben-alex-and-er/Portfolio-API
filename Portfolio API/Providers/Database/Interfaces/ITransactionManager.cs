using Database.Models;


namespace Portfolio_API.Providers.Database.Interfaces
{
	/// <summary>
	/// Interface for <see cref="TransactionManager"/>
	/// </summary>
	public interface ITransactionManager
	{
		/// <summary>
		/// Begins a new transaction for <see cref="PortfolioContext"/>
		/// </summary>
		/// <returns></returns>
		ITransaction CreateTransaction();

		/// <summary>
		/// Begins a new transaction for <see cref="PortfolioContext"/> asynchronously
		/// </summary>
		/// <returns></returns>
		Task<ITransaction> CreateTransactionAsync();
	}
}
