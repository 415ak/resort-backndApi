using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ResortApi.Models
{
    public class Payment
    {
        [Key]
        public string Id { get; set; }
        public string ImgPay { get; set; }
        public string Status { get; set; }
        public string? Detail { get; set; }
        public DateTime Createdate { get; set; }

        public string AccountId { get; set; }
        [ForeignKey("AccountId")]
        [ValidateNever]
        public Account Account { get; set; }


        public string? OrderId { get; set; }
        public string? HbOrderId { get; set; }
        public string? ServeOrderId { get; set; }
    }
}
