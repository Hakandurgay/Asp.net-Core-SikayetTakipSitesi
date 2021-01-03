using SikayetTakipSitesi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace SikayetTakipSitesi.ViewModels
{
    public class CommentModelView
    {
        public IPagedList<Comment> Comments { get; set; }
        //public Comment ComplaintInformation { get; set; }
        //public List<Comment> comments { get; set; }
        public Complaint Complaint { get; set; }
        public Comment Comment  { get; set; }


     
    }
}
