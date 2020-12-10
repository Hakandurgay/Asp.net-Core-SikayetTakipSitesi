using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SikayetTakipSitesi.Models
{
    public class Member
    {

        [Key]
        
        public int PK_MEMBER_ID { get; set; }

        public string MemberName { get; set; }

        public string MemberLastName { get; set; }

        public string MemberMail { get; set; }

        public string MemberPassword { get; set; }

        public string MemberPhoto { get; set; }

        public bool MemberStatus { get; set; }
        public int? CountryId { get; set; }
        public Country FK_Country { get; set; }
        public Role Role { get; set; }

     //   public ICollection<Complaint> Complaints { get; set; }

     //   public ICollection<Comment> Comments { get; set; }


    }
}
