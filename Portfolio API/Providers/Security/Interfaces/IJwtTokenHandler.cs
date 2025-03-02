using System.Security.Claims;


namespace Portfolio_API.Providers.Security.Interfaces
{
	/// <summary>
	/// Interface for <see cref="JwtTokenHandler"/>
	/// </summary>
	public interface IJwtTokenHandler
	{
		/// <summary>
		/// Creates a new JWT token using the provided claims
		/// </summary>
		/// <param name="claims"></param>
		/// <param name="expiry"></param>
		/// <returns></returns>
		public string CreateToken(IEnumerable<Claim> claims, DateTime? expiry = null);
	}
}
