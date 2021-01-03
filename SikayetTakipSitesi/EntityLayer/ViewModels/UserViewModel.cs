using SikayetTakipSitesi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;
namespace SikayetTakipSitesi.ViewModels
{
    public class UserViewModel
    {
        public IPagedList<Complaint> Complaints { get; set; }
        public IPagedList<Comment> Comments { get; set; }
    }
}
