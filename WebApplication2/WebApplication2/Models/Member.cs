using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class Member
    {
        public int MemberId { get; set; }
        public int OrganizationId { get; set; }
        public string MemberName { get; set; }
        public string MemberSurname { get; set; }
        public string MemberNickName { get; set; }
        public virtual Organization Organization { get; set; }
        public virtual ICollection<Membership> Memberships { get; set; }
    }
}
