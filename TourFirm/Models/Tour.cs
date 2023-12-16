using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourFirm.Models
{
    public class Tour
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int Price { get; set; }
        public string? Description { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public string? Image { get; set; }
        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

        [NotMapped]
        public string TourImageFromResources => "/Resources/" + Image;
        [NotMapped]
        public string DollarPrice => Price + "$";
    }
}
