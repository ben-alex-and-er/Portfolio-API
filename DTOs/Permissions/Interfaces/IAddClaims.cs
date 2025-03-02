namespace DTOs.Permissions.Interfaces
{
	/// <summary>
	/// Interface for adding new claims to the db
	/// </summary>
	public interface IAddClaims
	{
		/// <summary>
		/// The claims to be added
		/// </summary>
		public IEnumerable<RequiredClaimDTO> Claims { get; }
	}
}
