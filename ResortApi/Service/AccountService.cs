using ResortApi.DTOS.Account;
using ResortApi.Models;
using ResortApi.Models.Data;
using ResortApi.Settings;
using Mapster;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace ResortApi.Services
{
    public class AccountService : IAccountService
    {
        private readonly DatabaseContext context;
        private readonly JwtSetting jwtSetting;

        public AccountService(DatabaseContext context, JwtSetting jwtSetting)
        {
            this.context = context;
            this.jwtSetting = jwtSetting;
        }
        public string GenerateToken(Account account)
        {
            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Sub,account.Email),
                new Claim("email",account.Email),
                new Claim("name",account.FirstName),
                new Claim("lastname",account.LastName),
                new Claim("tel",account.Tel),
                new Claim("userId",account.AccountId.ToString()),
                new Claim("role",account.Role.RoleName),
                //new Claim("additonal","TestSomething"),
                new Claim("todoDay", DateTime.Now.ToString())
            };
            return BuildToken(claims);
        }

        public async Task<object> GetByToken(string accessToken)
        {
            if (accessToken is null) return Constants.Return400("no token");
            //แปลงค่า Token (ถอดรหัส)
            var token = new JwtSecurityTokenHandler().ReadToken(accessToken) as JwtSecurityToken;
            // key is case-sensitive
            var id = token!.Claims.First(claim => claim.Type == "accountId").Value;
            var result = await context.Accounts.Include(a => a.Role).FirstOrDefaultAsync(a => a.AccountId.Equals(id) && a.IsUsed.Equals(1));
            if (result is null) return Constants.Return400("no account");
            return Constants.Return200Data("success", AccountResponse.AccountRole(result));
        }

        private string BuildToken(Claim[] claims)
        {
            var expires = DateTime.Now.AddDays(Convert.ToDouble(jwtSetting.Expire));
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSetting.Key));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            //สร้าง Token
            var token = new JwtSecurityToken(
                issuer: jwtSetting.Issuer,
                audience: jwtSetting.Audience,
                claims: claims,
                expires: expires,
                signingCredentials: creds
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<Account> LoginShow(LoginRequest data)
        {
            var result = await context.Accounts.Include(a => a.Role)
                .FirstOrDefaultAsync(a => a.Email.Equals(data.Email) && a.IsUsed == 1);
            if (result != null)
            {
                var salt = await context.SecurityUsers.FindAsync(result.AccountId);
                var token = GenerateToken(result);
                if (VerifyPassword(result.Password, data.Password, salt!.Salt))
                    return result;
            }
            return (Account)Constants.Return400("ชื่อผู้ใช้หรือรหัสผ่านไม่ถูกต้อง");
            //return null;
        }

        //public async Task<object> Login(LoginRequest data)
        //{
        //    var result = await context.Accounts.Include(a => a.Role)
        //        .FirstOrDefaultAsync(a => a.Email.Equals(data.Email) && a.IsUsed == 1);
        //    if (result != null)
        //    {
        //        var salt = await context.SecurityUsers.FindAsync(result.AccountId);
        //        var token = GenerateToken(result);
        //        if (VerifyPassword(result.Password, data.Password, salt!.Salt))
        //            return Constants.Return200Token("เข้าสู่ระบบสำเร็จ", GenerateToken(result));
        //    }
        //    return Constants.Return400("ชื่อผู้ใช้หรือรหัสผ่านไม่ถูกต้อง");
        //}


        public async Task<object> Login(LoginRequest data)
        {
            var result = await context.Accounts.Include(a => a.Role)
                .FirstOrDefaultAsync(a => a.Email.Equals(data.Email) && a.IsUsed == 1);
            if (result != null)
            {
                var salt = await context.SecurityUsers.FindAsync(result.AccountId);
                if (VerifyPassword(result.Password, data.Password, salt!.Salt))
                    return Constants.Return200Token("เข้าสู่ระบบสำเร็จ", GenerateToken(result));
            }
            return Constants.Return400("ชื่อผู้ใช้หรือรหัสผ่านไม่ถูกต้อง");
        }

  
        public async Task<object> Register(RegisterRequest data)
        {
            var result = await context.Accounts.FirstOrDefaultAsync(a => a.Email.Equals(data.Email));
            if (result != null) return Constants.Return400("อีเมลผู้ใช้ซ้ำ");

            //#region Check and UploadImage
            //(string errorMessage, string imageName) = await UpLoadImage(data.ProfileImage!);
            //if (!string.IsNullOrEmpty(errorMessage)) return Constants.Return400(errorMessage);
            //#endregion

            (string passwordHash, string salt) = CreateHashPasswordAndSalt(data.Password);

            #region New Account
            Account newAccount = data.Adapt<Account>();
            newAccount.Email = newAccount.Email.ToLower();
            newAccount.Password = passwordHash;
            //newAccount.ProfileImage = imageName;
            newAccount.AccountId = Constants.uuid18();
            newAccount.CreateTime = DateTime.Now;
            newAccount.IsUsed = 1;
            #endregion

            #region New Salt
            SecurityUser newSalt = new SecurityUser
            {
                UserId = newAccount.AccountId,
                TruePassword = data.Password,
                Salt = salt
            };
            #endregion

            await context.Accounts.AddAsync(newAccount);
            await context.SecurityUsers.AddAsync(newSalt);
            await context.SaveChangesAsync();
            return Constants.Return200("สมัครสมาชิกสำเร็จ");
        }



        public async Task<object> Update(AccountUpdate data)
        {
            var result = await context.Accounts.FirstOrDefaultAsync(a => a.AccountId.Equals(data.AccountId));
            if (result is null) return Constants.Return400("ไม่พบข้อมูล");

            //#region Check and UploadImage
            //(string errorMessage, string imageName) = await UpLoadImage(data.ProfileImage!);
            //if (!string.IsNullOrEmpty(errorMessage)) Constants.Return400(errorMessage);
            //if (!string.IsNullOrEmpty(imageName))
            //{
            //    await uploadFileService.DeleteImage(result.ProfileImage!);
            //    result.ProfileImage = imageName;
            //}
            //#endregion

            result.FirstName = data.FirstName;
            result.LastName = data.LastName;
            result.RoleId = data.RoleId;

            //if (result.RoleId == null)
            //{
            //    result.RoleId = "1";
            //}
            //else 

            context.Accounts.Update(result);
            await context.SaveChangesAsync();
            return Constants.Return200("อัพเดตข้อมูลสำเร็จ");
        }


        private bool VerifyPassword(string passwordHashFormDB, string UserPassword, string salt)
        {
            if (string.IsNullOrEmpty(salt)) return false;
            string newHashed = HashPassword(UserPassword, Convert.FromBase64String(salt));
            return newHashed == passwordHashFormDB;
        }

        private string CreateHashPassword(string UserPassword)
        {
            byte[] salt = new byte[128 / 8];
            using (var rngCsp = new RNGCryptoServiceProvider())
            {
                rngCsp.GetNonZeroBytes(salt);
            }
            Console.WriteLine($"Salt: {Convert.ToBase64String(salt)}");

            var hashed = HashPassword(UserPassword, salt);


            var hpw = $"{Convert.ToBase64String(salt)}.{hashed}";
            return hpw;
        }

        private (string passwordHash, string salt) CreateHashPasswordAndSalt(string password)
        {
            byte[] salt = new byte[128 / 8];
            using (var rngCsp = new RNGCryptoServiceProvider()) rngCsp.GetNonZeroBytes(salt);

            string hashed = HashPassword(password, salt);
            return (hashed, Convert.ToBase64String(salt));
        }

        private string HashPassword(string UserPassword, byte[] salt)
        {
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: UserPassword,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256 / 8));
            return hashed;
        }



        public async Task<IEnumerable<Account>> FindAll()
        {
            var users = await context.Accounts.
                Include(x => x.Role).ToListAsync();

            return users;
        }

        public Account GetInfo(string accessToken)
        {
            var token = new JwtSecurityTokenHandler().ReadToken(accessToken) as JwtSecurityToken;

            // key is case-sensitive
            var email = token.Claims.First(claim => claim.Type == "email").Value;
            var role = token.Claims.First(claim => claim.Type == "role").Value;
            var id = token.Claims.First(claim => claim.Type == "accountId").Value;
            var name = token.Claims.First(claim => claim.Type == "name").Value;



            var user = new Account
            {
                AccountId = id,
                Email = email,
                Role = new Role
                {
                    RoleName = role
                },
                FirstName = name
            };

            return user;
        }

        //public async Task<object> GetByToken(string userToken)
        //{
        //    if (userToken is null) return Constants.Return400("no token");
        //    //แปลงค่า Token (ถอดรหัส)
        //    var token = new JwtSecurityTokenHandler().ReadToken(userToken) as JwtSecurityToken;
        //    // key is case-sensitive
        //    var id = token!.Claims.First(claim => claim.Type == "accountId").Value;
        //    var result = await context.Accounts.Include(a => a.Role).FirstOrDefaultAsync(a => a.AccountId.Equals(id) && a.IsUsed.Equals(1));
        //    if (result is null) return Constants.Return400("no account");
        //    return Constants.Return200Data("success", AccountResponse.FromUser(result));
        //}

        public async Task<object> GetByID(string id)
        {
            var result = await context.Accounts.Include(e => e.Role).FirstOrDefaultAsync(a => a.AccountId.Equals(id) && a.IsUsed == 1);
            if (result == null) return Constants.Return400("ไม่พบข้อมูล");
            return result;
        }

        public async Task Delete(Account user)
        {
            context.Remove(user);
            //if (result is null) return Constants.Return400();
            await context.SaveChangesAsync();

        }

        public async Task<object> DeleteAccount(string id)
        {
            var result = await context.Accounts.FirstOrDefaultAsync(a => a.AccountId.Equals(id));
            if (result == null) return Constants.Return400("ไม่พบผู้ใช้");

            //result.IsUsed = 0;
            context.Accounts.Remove(result);
            //context.Accounts.Update(result);
            await context.SaveChangesAsync();

            return result;
           
        }





        //public async Task<object> Login(LoginRequest data)
        //{
        //    var result = await context.Accounts.Include(a => a.Role).FirstOrDefaultAsync(a =>
        //        a.Email.Equals(data.Email) && a.IsUsed == 1
        //    );
        //    if (result != null)
        //    {
        //        var salt = await context.SecurityUsers.FindAsync(result.AccountId);
        //        if (VerifyPassword(result.Password, data.Password, salt!.Salt))
        //            return Constants.Return200Token("เข้าสู่ระบบสำเร็จ", GenerateToken(result));
        //    }
        //    return Constants.Return400("ชื่อผู้ใช้หรือรหัสผ่านไม่ถูกต้อง");
        //}

    }
}
