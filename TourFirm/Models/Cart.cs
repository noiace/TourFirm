using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourFirm.Models
{
    public class Cart
    {
        public int Id { get; set; } 
        public int UserId { get; set; } 
        public string TourId { get; set; } = null!;
       
        
    }
}
