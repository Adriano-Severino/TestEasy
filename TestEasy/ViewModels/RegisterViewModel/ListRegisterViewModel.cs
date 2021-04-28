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

        [Required(ErrorMessage = "*")]
        public string Name { get; set; }

        [Required(ErrorMessage = "*")]
        public string Email { get; set; }

        [Required(ErrorMessage = "*")]
        public string Phone { get; set; }
        public string Linkedin { get; set; }
        public string LinkCRUD { get; set; }

        [Required(ErrorMessage = "*")]
        public string City { get; set; }

        [Required(ErrorMessage = "*")]
        public string State { get; set; }
        public string Portfolio { get; set; }
        public string salaryPrefer { get; set; }
        public DateTime CreateDateTime { get; set; }
        public object Skills { get; set; }
    }
}
