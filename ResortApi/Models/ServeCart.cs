using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ResortApi.Models
{
    public class ServeCart
    {
        [Key]
        public int Id { get; set; }
        public string AccountId { get; set; }
        public int ServeId { get; set; }
        public int Amount { get; set; }
        
        public DateTime CreateDate { get; set; } = DateTime.Now;


        [ForeignKey("ServeId")]
        [ValidateNever]
        public Serve Serve { get; set; }
    }
}
