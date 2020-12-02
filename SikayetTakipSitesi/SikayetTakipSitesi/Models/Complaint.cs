using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SikayetTakipSitesi.Models
{
    public class Complaint
    {
        [Key]
        public int PK_COMPLAINT_ID { get; set; }
        public string ComplaintContent { get; set; }
        public bool ComplaintStatus { get; set; }
        public string ComplaintTitle { get; set; }
        public bool ComplaintSwitchActive { get; set; }
        public Member FK_MEMBER_ID { get; set; }
        public Brand FK_BRAND_ID { get; set; }
        public ICollection<Comment> Comments { get; set; }

    }
}
