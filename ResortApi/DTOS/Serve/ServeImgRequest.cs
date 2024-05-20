using System.ComponentModel.DataAnnotations;

namespace ResortApi.DTOS.Serve
{
    public class ServeImgRequest
    {
        //[Required]
        public int serveId { get; set; }

        public IFormFileCollection? formFiles { get; set; }


    }
}
