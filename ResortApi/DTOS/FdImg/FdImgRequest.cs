using System.ComponentModel.DataAnnotations;

namespace ResortApi.DTOS.FdImg
{
    public class FdImgRequest
    {
        //[Required]
        public string FdId { get; set; }

        public IFormFileCollection? formFiles { get; set; }


    }
}
