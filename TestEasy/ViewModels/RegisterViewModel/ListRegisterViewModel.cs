using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestEasy.ViewModels.RegisterViewModel
{
    public class ListRegisterViewModel
    {
        public int Id { get; set; }


        public string Name { get; set; }

 
        public string Email { get; set; }

        public string Phone { get; set; }
        public string Linkedin { get; set; }
        public string LinkCRUD { get; set; }

     
        public string City { get; set; }

        
        public string State { get; set; }
        public string Portfolio { get; set; }
        public string salaryPrefer { get; set; }
        public string willingnessWorkWeek { get; set; }
        public string TimeWork { get; set; }
        public string Knowledge { get; set; }
        public string OtherLanguageFramework { get; set; }
        public DateTime CreateDateTime { get; set; }
    }
}
