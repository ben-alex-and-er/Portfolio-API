namespace DTOs.Authentication
{
	/// <summary>
	/// Represents a password that has been hashed
	/// </summary>
	public class HashedPassword
	{
		/// <summary>
		/// The hashed password
		/// </summary>
		public string Hash { get; set; }


		/// <summary>
		/// Constructor for <see cref="HashedPassword"/>
		/// </summary>
		/// <param name="password"></param>
		public HashedPassword(string password)
		{
			this.Hash = password;
		}

		/// <summary>
		/// Implicitly converts a <see cref="string"/> to a <see cref="HashedPassword"/>
		/// </summary>
		/// <param name="password"></param>
		public static implicit operator HashedPassword(string password)
			=> new(password);
	}
}
