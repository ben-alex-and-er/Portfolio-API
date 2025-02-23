using System.Security.Cryptography;
using System.Text;


namespace DTOs.Authentication
{
	/// <summary>
	/// Represents a hashed password
	/// </summary>
	public class HashedPassword
	{
		/// <summary>
		/// Base-64 Salt
		/// </summary>
		public string Salt { get; set; }

		/// <summary>
		/// The number of times the password is hashed
		/// </summary>
		public int Iterations { get; set; }

		/// <summary>
		/// The hashing algorithm used
		/// </summary>
		public HashAlgorithmName Algorithm { get; set; }

		/// <summary>
		/// The size of the hash
		/// </summary>
		public int HashSize { get; set; }

		/// <summary>
		/// Base-64 Hash
		/// </summary>
		public string Hash { get; set; }


		/// <summary>
		/// Constructor for an existing hashed password. E.g. from the db
		/// </summary>
		/// <param name="hashedPassword"></param>
		public HashedPassword(string hashedPassword)
		{
			var unBase64 = Convert.FromBase64String(hashedPassword);

			var decoded = Encoding.UTF8.GetString(unBase64);

			var split = decoded.Split('.');

			Salt = Encoding.UTF8.GetString(Convert.FromBase64String(split[0]));
			Iterations = int.Parse(split[1]);
			Algorithm = new HashAlgorithmName(split[2]);
			HashSize = int.Parse(split[3]);
			Hash = Encoding.UTF8.GetString(Convert.FromBase64String(split[4]));
		}

		/// <summary>
		/// Constructor for a new hashed password
		/// </summary>
		/// <param name="salt"></param>
		/// <param name="iterations"></param>
		/// <param name="algorithm"></param>
		/// <param name="hashSize"></param>
		/// <param name="hash"></param>
		public HashedPassword(byte[] salt, int iterations, HashAlgorithmName algorithm, int hashSize, byte[] hash)
		{
			Salt = Convert.ToBase64String(salt);
			Iterations = iterations;
			Algorithm = algorithm;
			HashSize = hashSize;
			Hash = Convert.ToBase64String(hash);
		}

		/// <summary>
		/// Converts the <see cref="HashedPassword"/> to a hashed password string
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			var salt = Convert.ToBase64String(Encoding.UTF8.GetBytes(Salt));
			var hash = Convert.ToBase64String(Encoding.UTF8.GetBytes(Hash));

			var bytes = Encoding.UTF8.GetBytes($"{salt}.{Iterations}.{Algorithm.Name}.{HashSize}.{hash}");

			var base64 = Convert.ToBase64String(bytes);

			return base64;
		}
	}
}
