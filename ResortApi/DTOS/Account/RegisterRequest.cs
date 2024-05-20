using System.ComponentModel.DataAnnotations;

namespace ResortApi.DTOS.Account
{
    public class RegisterRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(5)]
        public string Password { get; set; }

        public int RoleId { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        //[Required]
        //public string UserProfile { get; set; }

        [Required]
        public string Tel { get; set; }

        //public string IsUsed { get; set; }
    }
}
