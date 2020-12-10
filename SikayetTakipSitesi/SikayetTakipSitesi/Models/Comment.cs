using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SikayetTakipSitesi.Models
{
    public class Comment
    {
        [Key]
        public int PK_COMMENT_ID { get; set; }
        public string CommentContent { get; set; }
        public int? MemberId { get; set; }
        public int? ComplaintId { get; set; }
        public bool CommentStatus { get; set; }
        public bool CommentSwitchActive { get; set; }
        //     public Complaint FK_COMPLAINT_ID { get; set; }
        public Complaint Complaint { get; set; }
        public Member Member { get; set; }
    }
}
