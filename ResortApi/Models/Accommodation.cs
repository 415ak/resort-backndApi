using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ResortApi.Models
{
    public class Accommodation
    {
        [Key]
        public string AccommodationId { get; set; } //ไอดีที่พัก
        public string Name { get; set; }
        public int Quantity { get; set; }  ///จำนวนผู้เข้าใช้
        public int Price { get; set; }
        public string Detail { get; set; }
        public string Status { get; set; } /// ว่างไม่ว่าง
        public int IsUsed { get; set; }
        public DateTime CreateTime { get; set; } = DateTime.Now;

        public string AccommodationTypeId { get; set; }
        [ValidateNever]
        [ForeignKey("AccommodationTypeId")]
        public virtual AccommodationType AccommodationType { get; set; }


        public ICollection<AccommodationImg> AccommodationImgs { get; set; } = new List<AccommodationImg>();


    }
}
