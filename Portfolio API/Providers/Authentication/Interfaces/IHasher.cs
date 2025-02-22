using DTOs.Authentication;
using Microsoft.AspNetCore.Identity;


namespace Portfolio_API.Providers.Authentication.Interfaces
{
	/// <summary>
	/// Interface for <see cref="Hasher"/>
	/// </summary>
	public interface IHasher
	{
		/// <summary>
		/// Hashes a password
		/// </summary>
		/// <param name="password">Password to hash</param>
		/// <returns>Hashed password</returns>
		HashedPassword HashPassword(string password);

		/// <summary>
		/// Returns a <see cref="PasswordVerificationResult"/> indicating the result of a password hash comparison.
		/// </summary>
		/// <param name="hashedPassword">The hash value for a user's stored password.</param>
		/// <param name="providedPassword">The password supplied for comparison.</param>
		/// <returns>A <see cref="PasswordVerificationResult"/> indicating the result of a password hash comparison.</returns>
		/// <remarks>Implementations of this method should be time consistent.</remarks>
		PasswordVerificationResult VerifyHashedPassword(HashedPassword hashedPassword, string providedPassword);
	}
}
