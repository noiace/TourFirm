using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourFirm.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public int UserId { get; set; }
        public int TourId { get; set; }
        public virtual User User { get; set; } = null!;
        public virtual Tour Tour { get; set; } = null!;
    }
}
