namespace AngularApex.Services.JWT
{
    public interface ITokenHandler
    {

        string GenerateToken(int userId, string emailAddress);
    }
}