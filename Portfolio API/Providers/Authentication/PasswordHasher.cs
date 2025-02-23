using DTOs.Authentication;
using System.Security.Cryptography;


namespace Portfolio_API.Providers.Authentication
{
	/// <summary>
	/// Manager for hashing and verifying passwords
	/// </summary>
	public static class PasswordHasher
	{
		private const int SALT_SIZE = 16;
		private const int HASH_SIZE = 32;
		private const int ITERATIONS = 100000;


		private static readonly HashAlgorithmName HashAlgorithm = HashAlgorithmName.SHA512;


		/// <summary>
		/// Converts a password to a <see cref="HashedPassword"/>
		/// </summary>
		/// <param name="password"></param>
		/// <returns></returns>
		public static HashedPassword HashPassword(string password)
		{
			var salt = RandomNumberGenerator.GetBytes(SALT_SIZE);

			var iterations = ITERATIONS;
			var algorithm = HashAlgorithm;
			var hashSize = HASH_SIZE;

			var hash = Rfc2898DeriveBytes.Pbkdf2(password, salt, iterations, algorithm, hashSize);

			return new(salt, iterations, algorithm, hashSize, hash);
		}

		/// <summary>
		/// Verified that the entered password is eqivalent to the HashedPassword
		/// </summary>
		/// <param name="password"></param>
		/// <param name="storedHash"></param>
		/// <returns></returns>
		public static bool VerifyPassword(string password, HashedPassword storedHash)
		{
			var salt = Convert.FromBase64String(storedHash.Salt);
			var iterations = storedHash.Iterations;
			var algorithm = storedHash.Algorithm;
			var hashSize = storedHash.HashSize;

			var newHashBytes = Rfc2898DeriveBytes.Pbkdf2(password, salt, iterations, algorithm, hashSize);

			var newHash = Convert.ToBase64String(newHashBytes);

			return newHash.Equals(storedHash.Hash);
		}
	}

}
