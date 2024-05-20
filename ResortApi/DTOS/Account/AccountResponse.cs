using ResortApi.Models;
using ResortApi.Settings;

namespace ResortApi.DTOS.Account
{
    public class AccountResponse
    {
        public string AccountId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        //public string UserProfile { get; set; } = "";
        public string Tel { get; set; }

        public int IsUsed { get; set; } = 1;
        public DateTime CreateTime { get; set; } = DateTime.Now;


        public string RoleName { get; set; }

        public virtual Role Role { get; set; }

        static public AccountResponse FromUser(Models.Account user)
        {
            return new AccountResponse
            {
                AccountId = user.AccountId,
                FirstName = user.FirstName,
                CreateTime = user.CreateTime,
                Email = user.Email,
                LastName = user.LastName,
                Tel = user.Tel,
                IsUsed = user.IsUsed,
                Password = user.Password,
                RoleName = user.Role.RoleName,
                //Role = user.Role,
                //UserProfile =user.UserProfile,


            };
        }
        //[ForeignKey("RoleId")]
        

        static public object User(Models.Account data) => new
        {
            data.AccountId,
            data.Email,
            data.FirstName,
            data.LastName,
            //ProfileImage = !string.IsNullOrEmpty(data.UserProfile) ? Constants.PathServer + data.UserProfile : null,
            data.CreateTime,
            data.IsUsed,
            data.RoleId,
            Role = data.Role.RoleName

        };

        static public object AccountRole(Models.Account data) => new
        {
            data.AccountId,
            data.Email,
            data.FirstName,
            data.LastName,
            //ProfileImage = !string.IsNullOrEmpty(data.UserProfile) ? Constants.PathServer + data.UserProfile : null,
            data.CreateTime,
            data.IsUsed,
            data.RoleId,
            Role = data.Role.RoleName
        };
    }
}
