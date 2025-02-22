namespace DTOs.Authentication
{
	/// <summary>
	/// DTO containing a username and hashed password
	/// </summary>
	public class UserHashedPasswordDTO
	{
		/// <summary>
		/// User's identifier
		/// </summary>
		public string User { get; init; }

		/// <summary>
		/// User's hashed password
		/// </summary>
		public HashedPassword HashedPassword { get; init; }


		/// <summary>
		/// Constructor to be used for entity framework ONLY
		/// </summary>
		public UserHashedPasswordDTO() { }

		/// <summary>
		/// Constructor for <see cref="UserHashedPasswordDTO"/>
		/// </summary>
		/// <param name="username"></param>
		/// <param name="hashedPassword"></param>
		public UserHashedPasswordDTO(string username, HashedPassword hashedPassword)
		{
			User = username;
			HashedPassword = hashedPassword;
		}
	}
}
