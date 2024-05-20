using System.ComponentModel.DataAnnotations;

namespace ResortApi.DTOS.ServeCart
{
    public class ServeCartCreate
    {

        public string AccountId { get; set; }
        public int ServeId { get; set; }
        public int Amount { get; set; }
    }
}
