using DTOs.Permissions.Interfaces;


namespace Portfolio_API.Services.Permissions.Interface
{
	/// <summary>
	/// Interface for <see cref="ClaimService"/>
	/// </summary>
	public interface IClaimService
	{
		/// <summary>
		/// Adds multiple claims to the db
		/// </summary>
		/// <param name="claims"></param>
		/// <returns></returns>
		Task<bool> AddClaims(IAddClaims claims);
	}
}
