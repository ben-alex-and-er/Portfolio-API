namespace DTOs.Authentication.Interfaces
{
	/// <summary>
	/// Interface for a login request
	/// </summary>
	public interface ILogin
	{
		/// <summary>
		/// The user's username
		/// </summary>
		public string Username { get; }

		/// <summary>
		/// The user's password
		/// </summary>
		public string Password { get; }
	}
}
