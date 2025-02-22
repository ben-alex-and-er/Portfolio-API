namespace DTOs.Authentication
{
	/// <summary>
	/// DTO containing a username and password
	/// </summary>
	public record LoginDTO
	{
		/// <summary>
		/// User's identifier
		/// </summary>
		public string User { get; init; }

		/// <summary>
		/// User's hashed password
		/// </summary>
		public string Password { get; init; }


		/// <summary>
		/// Constructor to be used for entity framework ONLY
		/// </summary>
		public LoginDTO() { }

		/// <summary>
		/// Constructor for <see cref="LoginDTO"/>
		/// </summary>
		/// <param name="username"></param>
		/// <param name="password"></param>
		public LoginDTO(string username, string password)
		{
			User = username;
			Password = password;
		}
	}
}
