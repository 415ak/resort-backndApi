using System.ComponentModel.DataAnnotations;

namespace ResortApi.Models
{
    public class Information
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImgInform { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;


        //public ICollection<FdImg> FdImgs { get; set; } = new List<FdImg>();
    }
}
