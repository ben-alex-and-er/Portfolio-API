using Portfolio_API.Providers.Authentication;


namespace UNIT_Tests.Providers.Authentication
{
	internal class PasswordHasherTests
	{
		[TestCaseSource(nameof(VerifyPasswordTestCases))]
		public void VerifyPasswordTests(string password1, string password2, bool isEqual)
		{
			// Arrange
			var password2Hashed = PasswordHasher.HashPassword(password2);

			// Act
			var result = PasswordHasher.VerifyPassword(password1, password2Hashed);

			// Assert
			Assert.That(result, Is.EqualTo(isEqual));
		}


		private static IEnumerable<TestCaseData> VerifyPasswordTestCases
		{
			get
			{
				// Same password should match
				yield return new TestCaseData("password", "password", true)
					.SetName("ValidPassword_Matches");

				// A case where the password is only slightly different
				yield return new TestCaseData("passwor", "password", false)
					.SetName("ShortPassword_DoesNotMatch");

				yield return new TestCaseData("password", "passwor", false)
					.SetName("ShortPassword2_DoesNotMatch");

				// Check if hashing creates a unique hash
				var hashedPassword1 = PasswordHasher.HashPassword("password");
				var hashedPassword2 = PasswordHasher.HashPassword("password");

				// Ensure hashing for same password generates different salts (thus different hashes)
				yield return new TestCaseData(hashedPassword1.Hash, hashedPassword2.Hash, false)
					.SetName("SamePassword_DifferentHashesDueToSalt");

				// Test hashing behavior with edge cases
				yield return new TestCaseData("12345", "12345", true)
					.SetName("EdgePassword1_Matches");

				yield return new TestCaseData("1234567890", "1234567890", true)
					.SetName("EdgePassword2_Matches");

				yield return new TestCaseData("!@#$%^&*()", "!@#$%^&*()", true)
					.SetName("SpecialCharacters_Matches");

				// Empty password
				yield return new TestCaseData("", "", true)
					.SetName("EmptyPassword_Matches");

				// Test long passwords
				yield return new TestCaseData(new string('a', 1000), new string('a', 1000), true)
					.SetName("LongPassword_Matches");

				// Verify wrong password when hashed
				var testHash = PasswordHasher.HashPassword("password");
				yield return new TestCaseData("wrongpassword", testHash.Hash, false)
					.SetName("HashVerification_FailsWithWrongPassword");
			}
		}

	}
}
