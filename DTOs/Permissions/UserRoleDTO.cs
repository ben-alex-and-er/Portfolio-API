namespace DTOs.Permissions
{
	/// <summary>
	/// DTO containing a user identifier and role
	/// </summary>
	public class UserRoleDTO
	{
		/// <summary>
		/// User identifier
		/// </summary>
		public string User {  get; init; }

		/// <summary>
		/// Role name
		/// </summary>
		public string Role { get; init; }


		/// <summary>
		/// Constructor to be used for entity framework ONLY
		/// </summary>
		public UserRoleDTO() { }

		/// <summary>
		/// Constructor for <see cref="UserRoleDTO"/>
		/// </summary>
		/// <param name="user"></param>
		/// <param name="role"></param>
		public UserRoleDTO(string user, string role)
		{
			User = user;
			Role = role;
		}
	}
}
