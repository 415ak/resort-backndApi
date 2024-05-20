using ResortApi.DTOS.Account;
using ResortApi.Models;

namespace ResortApi.Services
{
    public interface IAccountService
    {
        Task<object> Register(RegisterRequest data);
        Task<object> Login(LoginRequest data);
        Task<Account> LoginShow(LoginRequest data);

        Task<object> Update(AccountUpdate data);

        string GenerateToken(Account user);
        Account GetInfo(string accessToken);
        Task<object> GetByToken(string? userToken);

        Task<object> GetByID(string id);
        //Task<object> Delete(Account user);



        Task<object> DeleteAccount(string id);
        Task<IEnumerable<Account>> FindAll();
    }
}
