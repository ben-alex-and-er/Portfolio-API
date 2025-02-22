namespace DTOs.Authentication
{
	/// <summary>
	/// DTO containing a username and password
	/// </summary>
	public class UserPasswordDTO
	{
		/// <summary>
		/// User's identifier
		/// </summary>
		public string User { get; init; }

		/// <summary>
		/// User's password
		/// </summary>
		public string Password { get; init; }


		/// <summary>
		/// Constructor to be used for entity framework ONLY
		/// </summary>
		public UserPasswordDTO() { }

		/// <summary>
		/// Constructor for <see cref="UserPasswordDTO"/>
		/// </summary>
		/// <param name="username"></param>
		/// <param name="password"></param>
		public UserPasswordDTO(string username, string password)
		{
			User = username;
			Password = password;
		}
	}
}
