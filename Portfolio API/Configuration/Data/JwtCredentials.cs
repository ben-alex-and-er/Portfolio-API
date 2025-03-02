namespace Portfolio_API.Configuration.Data
{
	/// <summary>
	/// Retrieves jwt credentials from environment variables
	/// </summary>
	public class JwtCredentials
	{
		private const string KEY = "Jwt";


		/// <summary>
		/// The JWT Issuer
		/// </summary>
		public string Issuer { get; set; }

		/// <summary>
		/// The JWT Audience
		/// </summary>
		public string Audience { get; set; }

		/// <summary>
		/// The JWT signing credentials secret key
		/// </summary>
		public string SecretKey { get; set; }


		/// <summary>
		/// Constructor for <see cref="JwtCredentials"/>
		/// </summary>
		/// <param name="configuration"></param>
		public JwtCredentials(IConfiguration configuration)
		{
			configuration.Bind(KEY, this);
		}
	}
}
