using SikayetTakipSitesi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SikayetTakipSitesi.ViewModels
{
    public class CommentModelView
    {
        public List<Comment> comments { get; set; }
        public Member Member { get; set; }

        public Complaint Complaint { get; set; }
    }
}
