using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;


namespace TestEasy.ViewModels.RegisterViewModel
{
    public class EditRegisterViewModel : Notifiable, IValidatable
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
