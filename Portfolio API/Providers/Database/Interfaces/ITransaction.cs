namespace Portfolio_API.Providers.Database.Interfaces
{
	/// <summary>
	/// Interface for <see cref="Transaction"/>
	/// </summary>
	public interface ITransaction : IDisposable
	{
		/// <summary>
		/// Commits all changes made to the database in the current transaction.
		/// </summary>
		void Commit();

		/// <summary>
		/// Commits all changes made to the database in the current transaction asynchronously.
		/// </summary>
		Task CommitAsync();
	}
}
