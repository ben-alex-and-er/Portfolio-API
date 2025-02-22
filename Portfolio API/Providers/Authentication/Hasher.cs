using Microsoft.AspNetCore.Identity;


namespace Portfolio_API.Providers.Authentication
{
	using DTOs.Authentication;
	using Interfaces;


	/// <summary>
	/// Password hasher and verifier
	/// </summary>
	public class Hasher : IHasher
	{
		private readonly IPasswordHasher<string> passwordHasher;


		/// <summary>
		/// Constructor for <see cref="Hasher"/>
		/// </summary>
		/// <param name="passwordHasher"></param>
		public Hasher(IPasswordHasher<string> passwordHasher)
		{
			this.passwordHasher = passwordHasher;
		}


		/// <summary>
		/// Hashes a password
		/// </summary>
		/// <param name="password">Password to hash</param>
		/// <returns>Hashed password</returns>
		HashedPassword IHasher.HashPassword(string password)
			=> passwordHasher.HashPassword(null!, password);

		/// <summary>
		/// Returns a <see cref="PasswordVerificationResult"/> indicating the result of a password hash comparison.
		/// </summary>
		/// <param name="hashedPassword">The hash value for a user's stored password.</param>
		/// <param name="providedPassword">The password supplied for comparison.</param>
		/// <returns>A <see cref="PasswordVerificationResult"/> indicating the result of a password hash comparison.</returns>
		/// <remarks>Implementations of this method should be time consistent.</remarks>
		PasswordVerificationResult IHasher.VerifyHashedPassword(HashedPassword hashedPassword, string providedPassword)
			=> passwordHasher.VerifyHashedPassword(null!, hashedPassword.Hash, providedPassword);
	}
}
