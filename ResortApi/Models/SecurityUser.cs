using System.ComponentModel.DataAnnotations; 

namespace ResortApi.Models
{
    public class SecurityUser
    {
        [Key] 
        public string UserId { get; set; }
        public string TruePassword { get; set; }
        public string Salt { get; set; }
    }
}
