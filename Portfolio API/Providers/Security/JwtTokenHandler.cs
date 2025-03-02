using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace Portfolio_API.Providers.Security
{
	using Configuration.Data;
	using Interfaces;


	/// <summary>
	/// Handler for creating JWT Tokens
	/// </summary>
	public class JwtTokenHandler : IJwtTokenHandler
	{
		private static DateTime DefaultExpiry => DateTime.UtcNow.AddHours(1);

		private readonly JwtCredentials credentials;

		private readonly JwtSecurityTokenHandler handler = new();


		/// <summary>
		/// Constructor for <see cref="JwtTokenHandler"/>
		/// </summary>
		/// <param name="credentials"></param>
		public JwtTokenHandler(JwtCredentials credentials)
		{
			this.credentials = credentials;
		}


		/// <summary>
		/// Creates a new JWT token using the provided claims
		/// </summary>
		/// <param name="claims"></param>
		/// <param name="expiry"></param>
		/// <returns></returns>
		string IJwtTokenHandler.CreateToken(IEnumerable<Claim> claims, DateTime? expiry)
		{
			expiry = expiry ?? DefaultExpiry;

			var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(credentials.SecretKey));
			var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

			var token = new JwtSecurityToken(
				issuer: credentials.Issuer,
				audience: credentials.Audience,
				claims: claims,
				expires: expiry,
				signingCredentials: creds);

			var tokenString = handler.WriteToken(token);

			return tokenString;
		}
	}
}
