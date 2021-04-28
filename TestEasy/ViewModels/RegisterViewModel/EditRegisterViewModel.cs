using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TestEasy.Domain.Models;


namespace TestEasy.ViewModels.RegisterViewModel
{
    public class EditRegisterViewModel : Notifiable, IValidatable
    {
        public int Id { get; set; }


        public string Name { get; set; }


        //[Required]
        //[EmailAddress]
        public string Email { get; set; }

        //[Required(ErrorMessage = "*")]
        public string Phone { get; set; }
        public string Linkedin { get; set; }
        public string LinkCRUD { get; set; }

        //[Required(ErrorMessage = "*")]
        public string City { get; set; }

        //[Required(ErrorMessage = "*")]
        public string State { get; set; }
        public string Portfolio { get; set; }
        public string salaryPrefer { get; set; }
        public string willingnessWorkWeek { get; set; }
        public string TimeWork { get; set; }

        //[Required(ErrorMessage = "*")]
        public string Knowledge { get; set; }
        public string OtherLanguageFramework { get; set; }

        //[Required]
        public DateTime CreateDateTime{ get; set; }
     
        public void Validate()
        {
            AddNotifications(new Contract()
                .HasMaxLen(Name, 120, "Nome", "O Nome deve conter até 120 caracteres")
                .HasMaxLen(Phone, 40, "Telefone", "O campo telefone deve ser preenchido")
            .IsNotNullOrEmpty(Email, "Email", "O email náo pode estar em branco")
            .IsEmail(Email, "Email","Valido")
            );
        }

      
    }
}
