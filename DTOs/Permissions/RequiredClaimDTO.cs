namespace DTOs.Permissions
{
	/// <summary>
	/// DTO containing claim type and value
	/// </summary>
	public class RequiredClaimDTO
	{
		/// <summary>
		/// Claim type
		/// </summary>
		public string Type { get; init; }

		/// <summary>
		/// Claim value
		/// </summary>
		public string Value { get; init; }


		/// <summary>
		/// Constructor for <see cref="RequiredClaimDTO"/>
		/// </summary>
		/// <param name="type"></param>
		/// <param name="value"></param>
		public RequiredClaimDTO(string type, string value)
		{
			Type = type;
			Value = value;
		}
	}
}
