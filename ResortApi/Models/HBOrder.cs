using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using ResortApi.Models.OrderAggregate;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ResortApi.Models
{
    public class HBOrder
    {

            [Key]
            public string Id { get; set; }
            //public string Status { get; set; } = "1";
            public string? Detail { get; set; }

            public string? ImagePay { get; set; }
            public PaymentStatus Status { get; set; } = PaymentStatus.WorkInProgress;

            public int Total { get; set; }
            public DateTime? CreateDate { get; set; } = DateTime.Now;
            
            public string Isused { get; set; }

            public string AccountId { get; set; }
            [ForeignKey("AccountId")]
            [ValidateNever]
            public virtual Account Account { get; set; }


            [ValidateNever]
            public virtual ICollection<HBOrderItem>? HBOrderItem { get; set; }


        }
    }
