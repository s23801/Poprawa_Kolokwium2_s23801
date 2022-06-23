using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class Team
    {
        public int TeamId { get; set; }
        public int OrganizationId { get; set; }
        public string TeamName { get; set; }
        public string TeamDescription { get; set; }
        public virtual Organization Organization { get; set; }
        public virtual ICollection<File> Files { get; set; }
        public virtual ICollection<Membership> Memberships { get; set; }
    }
}
