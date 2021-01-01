using SikayetTakipSitesi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace SikayetTakipSitesi.ViewModels
{
    public class AdminComplaintViewModel
    {
        public IPagedList<Brand> Brands { get; set; }
  //       public List<Brand> Brands { get; set; }
   //     public List<Complaint> Complaints { get; set; }
        public IPagedList<Complaint> Complaints { get; set; }

    }
}
