namespace Responses.Authentication
{
	using Enums;


	/// <summary>
	/// Response for logging in a user
	/// </summary>
	public class LoginResponse
	{
		/// <summary>
		/// Represents the status result from loggin in
		/// </summary>
		public LoginResponseStatus Status { get; }

		/// <summary>
		/// JWT Token containing user claims
		/// </summary>
		public string? Token { get; }


		/// <summary>
		/// Constructor for <see cref="LoginResponse"/>
		/// </summary>
		/// <param name="status"></param>
		/// <param name="token"></param>
		public LoginResponse(LoginResponseStatus status, string? token = null)
		{
			Status = status;
			Token = token;
		}
	}
}
