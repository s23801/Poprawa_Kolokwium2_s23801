using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class Membership
    {
        public int MemberId { get; set; }
        public int TeamId { get; set; }
        public DateTime MembershipDate { get; set; }
        public virtual Team Team { get; set; }
        public virtual Member Member { get; set; }

    }

}
