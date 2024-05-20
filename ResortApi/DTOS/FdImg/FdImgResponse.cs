using ResortApi.Settings;

namespace ResortApi.DTOS.FdImg
{
    public class FdImgResponse
    {

        public Guid FdImgId { get; set; }
        public string FdImgName { get; set; }
        public DateTime CreateDate { get; set; }
        public string FoodDrinkFdId { get; set; }

        //public Guid FdImgId { get; set; } = Guid.NewGuid();
        //public string FdImgName { get; set; }
        //public DateTime? CreateDate { get; set; } = DateTime.Now;
        //public string FoodDrinkFdId { get; set; }


        static public FdImgResponse FromDescription(Models.FdImg fdImg)
        {
              // return ตัวมันเอง
              return new FdImgResponse
              {
                    
                    FdImgId = fdImg.FdImgId,
                    FoodDrinkFdId = fdImg.FoodDrinkFdId,
                    //Image = productDescription.Image,
                    FdImgName = !string.IsNullOrEmpty(fdImg.FdImgName) ? Constants.PathServer + fdImg.FdImgName : "",
                    //CreateDate = DateTime.Now,

              };
        }
    }
}
