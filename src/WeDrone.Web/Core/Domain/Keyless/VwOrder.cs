using System.ComponentModel.DataAnnotations.Schema;

namespace WeDrone.Web.Core.Domain.Keyless
{
    public class VwOrder
    {
        [Column("Order Id")]
        public int OrderId { get; set; }

        [Column("Ordered By")]
        public string OrderedBy { get; set; }

        [Column("Package Pick-up")]
        public string PackagePickup { get; set; }

        [Column("Package Destination")]
        public string PackageDestination { get; set; }

        [Column("Current Status")]
        public string CurrentStatus { get; set; }

        [Column("Last Update")]
        public DateTime LastUpdate { get; set; }

        [Column("Ordered On")]
        public DateTime OrderedOn { get; set; }
    }
}
