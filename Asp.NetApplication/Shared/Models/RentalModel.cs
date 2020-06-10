using System.Collections.Generic;

namespace Shared.Models
{
    public class RentalModel
    {
        public int CustomerId { get; set; }
        public List<int> MoveieIds { get; set; }
    }
}
