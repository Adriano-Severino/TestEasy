using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestEasy.Domain.Models
{
    public class RegisterSkill
    {
        public int Id { get; set; }
        public string willingnessWorkWeek { get; set; }
        public string TimeWork { get; set; }
        public string Knowledge { get; set; }
        public string OtherLanguageFramework { get; set; }
        public int RegisterId { get; set; }
        public Register Register { get; set; }
    }
}
