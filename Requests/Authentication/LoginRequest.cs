using DTOs.Authentication.Interfaces;


namespace Requests.Authentication
{
	/// <summary>
	/// Request for logging in a user
	/// </summary>
	public class LoginRequest : ILogin
	{
		/// <inheritdoc/>
		public string Username { get; init; }

		/// <inheritdoc/>
		public string Password { get; init; }


		/// <summary>
		/// Constructor for <see cref="LoginRequest"/>
		/// </summary>
		/// <param name="username"></param>
		/// <param name="password"></param>
		public LoginRequest(string username, string password)
		{
			Username = username;
			Password = password;
		}
	}
}
