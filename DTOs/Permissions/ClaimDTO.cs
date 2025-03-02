namespace DTOs.Permissions
{
	/// <summary>
	/// DTO containing a claim type, value, and db guid
	/// </summary>
	public class ClaimDTO
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
		/// Claim guid
		/// </summary>
		public Guid Guid { get; init; }


		/// <summary>
		/// Constructor to be used for entity framework ONLY
		/// </summary>
		public ClaimDTO() { }

		/// <summary>
		/// Constructor for <see cref="ClaimDTO"/>
		/// </summary>
		/// <param name="type"></param>
		/// <param name="value"></param>
		/// <param name="guid"></param>
		public ClaimDTO(string type, string value, Guid guid)
		{
			Type = type;
			Value = value;
			Guid = guid;
		}
	}
}
