using DTOs.Permissions;
using DTOs.Permissions.Interfaces;


namespace Requests.Permissions
{
	/// <summary>
	/// Request for adding new claims to the db
	/// </summary>
	public class AddClaimsRequest : IAddClaims
	{
		/// <summary>
		/// The claims to be added
		/// </summary>
		public IEnumerable<RequiredClaimDTO> Claims { get; }


		/// <summary>
		/// Constructor for <see cref="AddClaimsRequest"/>
		/// </summary>
		/// <param name="claims"></param>
		public AddClaimsRequest(IEnumerable<RequiredClaimDTO> claims)
		{
			Claims = claims;
		}
	}
}
