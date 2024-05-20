using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ResortApi.Models
{
    public class Account
    {
        [Key]
        public string AccountId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        //public string UserProfil { get; set; } = "";
        public string Tel { get; set; }
        public int IsUsed { get; set; }
        public DateTime CreateTime { get; set; } = DateTime.Now;



        public string RoleId { get; set; }
        [ValidateNever]
        [ForeignKey("RoleId")]
        //[ForeignKey("RoleId")]
        public virtual Role Role { get; set; }

    }
}
