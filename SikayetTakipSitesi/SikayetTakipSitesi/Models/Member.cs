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
        [Required]
        public string MemberName { get; set; }
        [Required]
        public string MemberLastName { get; set; }
        [Required]
        public string MemberMail { get; set; }
        [Required]
        public string MemberPassword { get; set; }
        [Required]
        public string MemberPhoto { get; set; }
        [Required]
        public bool MemberStatus { get; set; }

        public Role Role { get; set; }

        public ICollection<Complaint> Complaints { get; set; }

        public ICollection<Comment> Comments { get; set; }

    }
}
