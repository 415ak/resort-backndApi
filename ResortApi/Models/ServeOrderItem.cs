using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ResortApi.Models
{
    public class ServeOrderItem
    {
        [Key]
        public string Id { get; set; }
        public int ServeId { get; set; }
        public int Amount { get; set; }
        public string ServeOrderId { get; set; }



        [ForeignKey("ServeId")]
        [ValidateNever]
        public Serve Serve { get; set; }


    }
}
