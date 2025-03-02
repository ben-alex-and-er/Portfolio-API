namespace Responses.Authentication.Enums
{
	/// <summary>
	/// Status code for logging in a user
	/// </summary>
	public enum LoginResponseStatus
	{
		/// <summary>
		/// Indicates the user logged in successfully
		/// </summary>
		SUCCESS = 0,

		/// <summary>
		/// Indicates the user could not be found
		/// </summary>
		USER_NOT_FOUND = 1,

		/// <summary>
		/// Indicates the user password was incorrect
		/// </summary>
		INCORRECT_PASSWORD = 2,

		/// <summary>
		/// Indicates the user failed to be logged in (for some unknown reason)
		/// </summary>
		FAILED = 3,
	}
}
