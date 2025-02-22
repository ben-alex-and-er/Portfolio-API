namespace Portfolio_API.Configuration.Data
{
	/// <summary>
	/// Retrieves the MySQL connection string from environment variables
	/// </summary>
	public class MySQLConnection
	{
		private const string KEY = "ConnectionString";


		/// <summary>
		/// The server domain for the db connection
		/// </summary>
		public string Server { get; init; }

		/// <summary>
		/// The port for the db connection
		/// </summary>
		public int Port { get; init; } = 3306;

		/// <summary>
		/// The user for the db connection
		/// </summary>
		public string User { get; init; }

		/// <summary>
		/// The password for the db connection
		/// </summary>
		public string Password { get; init; }


		/// <summary>
		/// Constructor for <see cref="MySQLConnection"/>
		/// </summary>
		/// <param name="configuration"></param>
		public MySQLConnection(IConfiguration configuration)
		{
			configuration.Bind(KEY, this);
		}


		/// <summary>
		/// Retrieves the full connection string
		/// </summary>
		/// <returns></returns>
		public override string ToString()
			=> $"Server={Server};Port={Port};User={User};Password={Password}";
	}
}
