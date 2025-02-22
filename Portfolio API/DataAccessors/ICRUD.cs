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
	/// Interface for Data Accessore with updating capabilities
	/// </summary>
	/// <typeparam name="T">Type to identify entry</typeparam>
	/// <typeparam name="U">Type to change new value to</typeparam>
	public interface IUpdate<T, U>
	{
		/// <summary>
		/// Updates an entry in the db
		/// </summary>
		/// <param name="identifer"></param>
		/// <param name="newValue"></param>
		/// <returns></returns>
		Task<DAStatus> Update(T identifer, U newValue);
	}

	/// <summary>
	/// Interface for Data Accessore with deleting capabilities
	/// </summary>
	/// <typeparam name="T">Type to identify entry to delete</typeparam>
	public interface IDelete<T>
	{
		/// <summary>
		/// Deletes an entry from the db
		/// </summary>
		/// <param name="delete"></param>
		/// <returns></returns>
		Task<DAStatus> Delete(T delete);
	}


	/// <summary>
	/// Interface for Data Accessors with create, read, update, delete capabilities
	/// </summary>
	/// <typeparam name="T">Input type to distinquish entry</typeparam>
	/// <typeparam name="U">Output type to extract data</typeparam>
	/// <typeparam name="V">Input type to update data</typeparam>
	public interface ICRUD<T, U, V> : ICreate<T>, IRead<U>, IUpdate<T, V>, IDelete<T> { }
}
