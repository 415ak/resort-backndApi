using System.ComponentModel.DataAnnotations;

namespace ResortApi.DTOS.Accommodation
{
    public class AcmdImgRequest
    {
        //[Required]
        public string AcmdId { get; set; }

        public IFormFileCollection? formFiles { get; set; }


    }
}
