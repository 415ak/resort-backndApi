namespace ResortApi.Models
{
    public class ServeImg
    {
        //public Guid FdImgId { get; set; } 
        public Guid ServeImgId { get; set; } = Guid.NewGuid();
        public string Image { get; set; }
        public int IsUsed { get; set; } = 1;
        public DateTime DateTime { get; set; } = DateTime.Now;
        public int ServeId { get; set; }
    }
}
