using System.Collections.Generic;

namespace Shared.Models
{
    public class RentalModel
    {
        public long CustomerId { get; set; }
        public List<long> GameIds { get; set; }
    }
}
