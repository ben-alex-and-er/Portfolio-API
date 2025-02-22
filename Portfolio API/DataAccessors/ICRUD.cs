using DTOs.Generic.Enums;


namespace Portfolio_API.DataAccessors
{
	/// <summary>
	/// Interface for Data Accessors with creating capabilities
	/// </summary>
	/// <typeparam name="T">Input type to create from</typeparam>
	public interface ICreate<T>
	{
		/// <summary>
		/// Adds a new entry to the db
		/// </summary>
		/// <param name="create"></param>
		/// <returns></returns>
		Task<DAStatus> Create(T create);
	}

	/// <summary>
	/// Interface for Data Accessors with reading capabilities
	/// </summary>
	/// <typeparam name="T">Output type to extract</typeparam>
	public interface IRead<T>
	{
		/// <summary>
		/// Retrieves a collection of data from the db
		/// </summary>
		/// <returns></returns>
		IQueryable<T> Read();
	}


	/// <summary>
	/// Interface for Data Accessors with create, read, update, delete capabilities
	/// </summary>
	/// <typeparam name="T">Input type to distinquish entry</typeparam>
	/// <typeparam name="U">Output type to extract data</typeparam>
	public interface ICRUD<T, U> : ICreate<T>, IRead<U>
	{
	}
}
