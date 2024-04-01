namespace AngularApex.Services.JWT
{
    public interface ITokenHandler
    {
        /// <summary>
        /// Generate a token
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="emailAddress"></param>
        /// <param name="accountId"></param>
        /// <param name="license"></param>
        /// <returns></returns>
        string GenerateToken(
            int userId, 
            string emailAddress, 
            string accountId,
            string license);
    }
}