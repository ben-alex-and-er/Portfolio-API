namespace DTOs.Permissions
{
	/// <summary>
	/// DTO containing role and claim information
	/// </summary>
	public class RoleClaimDTO
	{
		/// <summary>
		/// Role name
		/// </summary>
		public string Role { get; init; }

		/// <summary>
		/// Claim information
		/// </summary>
		public ClaimDTO Claim { get; init; }


		/// <summary>
		/// Constructor to be used for entity framework ONLY
		/// </summary>
		public RoleClaimDTO() { }

		/// <summary>
		/// Constructor for <see cref="RoleClaimDTO"/>
		/// </summary>
		/// <param name="role"></param>
		/// <param name="claimDTO"></param>
		public RoleClaimDTO(string role, ClaimDTO claimDTO)
		{
			Role = role;
			Claim = claimDTO;
		}
	}
}
