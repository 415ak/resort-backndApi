using System.ComponentModel.DataAnnotations;

namespace ResortApi.DTOS.Account
{
    public class AccountUpdate
    {
        //[Required]
        //[EmailAddress]
        //public string Email { get; set; }

        //[Required]
        //[MinLength(5)]
        //public string Password { get; set; }
        [Required]
        public string AccountId { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        //[Required]
        //public string UserProfile { get; set; }

        [Required]
        public string Tel { get; set; }

        public string RoleId { get; set; }


    }
}
