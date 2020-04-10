using System.ComponentModel.DataAnnotations.Schema;

namespace DAL
{
    public class MembershipType
    {
        [Column(nameof(MembershipType) + "Id")]
        public byte Id { get; set; }
        public short SignUpFee { get; set; }
        public byte DurationInMonths { get; set; }
        public byte DiscountRate { get; set; }
    }
}
