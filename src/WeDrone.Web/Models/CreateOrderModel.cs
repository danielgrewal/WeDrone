using System.ComponentModel.DataAnnotations;
using WeDrone.Web.Core.Common;
using WeDrone.Web.Core.Domain;

namespace WeDrone.Web.Models
{
    public class CreateOrderModel
    {
        [Required]
        public decimal Length { get; set; }
        [Required]
        public decimal Width { get; set; }
        [Required]
        public decimal Height { get; set; }
        [Required]
        public decimal Weight { get; set; }
        [Required]
        public string PickupAddress { get; set; }
        [Required]
        public string DropoffAddress { get; set; }


        public Result<Order> CreateOrder()
        {
            throw new NotImplementedException();
        }
    }
}
