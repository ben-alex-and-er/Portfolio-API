using DTOs.Authentication;


namespace Portfolio_API.DataAccessors.Authentication.Interfaces
{
	/// <summary>
	/// Interface for <see cref="PasswordDA"/>
	/// </summary>
	public interface IPasswordDA : ICreate<HashedPassword>, IUpdate<HashedPassword, HashedPassword>
	{
	}
}
