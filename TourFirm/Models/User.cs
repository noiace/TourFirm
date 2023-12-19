using System;
using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourFirm.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
        public string? LastName { get; set; }
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public int RoleId { get; set; } = 1;
        public virtual Role? Role { get; set; }
        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
