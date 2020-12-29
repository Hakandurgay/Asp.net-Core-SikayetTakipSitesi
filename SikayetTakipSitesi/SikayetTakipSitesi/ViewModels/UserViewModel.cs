using SikayetTakipSitesi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SikayetTakipSitesi.ViewModels
{
    public class UserViewModel
    {
        public List<Complaint> Complaints { get; set; }
        public List <Comment> Comments { get; set; }
    }
}
