using SikayetTakipSitesi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SikayetTakipSitesi.ViewModels
{
    public class AdminComplaintViewModel
    {
         public List<Brand> Brands { get; set; }
        public List<Complaint> Complaints { get; set; }
    }
}
