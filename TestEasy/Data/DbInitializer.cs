using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestEasy.Domain.Models;

namespace TestEasy.Data
{
    public class DbInitializer
    {
        public static void Initialize(TestEasyDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Registers.Any())
            {
                return;   // DB has been seeded
            }

            //iniciar o banco com dados da tabela registros para os testes
            var Registers = new Register[]
                {
            new Register{Name= "adriano",Email= "adriano@hotmail.com",Phone= "11-111111-1111",Linkedin="www.Linkedin.com.br",LinkCRUD="www.LinkCRUD.com.br",CreateDateTime=DateTime.Now,City="SP",State="itapevi",Portfolio="www.Portfolio.com.br",salaryPrefer="2000"},
            new Register{Name= "testenome",Email= "teste@hotmail.com",Phone= "11-111111-1111",Linkedin="www.Linkedin.com.br",LinkCRUD="www.LinkCRUD.com.br",CreateDateTime=DateTime.Now,City="SP",State="itapevi",Portfolio="www.Portfolio.com.br",salaryPrefer="2000"},
            new Register{Name= "outronome",Email= "outronome@hotmail.com",Phone= "11-111111-1111",Linkedin="www.Linkedin.com.br",LinkCRUD="www.LinkCRUD.com.br",CreateDateTime=DateTime.Now,City="SP",State="itapevi",Portfolio="www.Portfolio.com.br",salaryPrefer="2000"},
            new Register{Name= "pricila",Email= "pricila@hotmail.com",Phone= "11-111111-1111",Linkedin="www.Linkedin.com.br",LinkCRUD="www.LinkCRUD.com.br",CreateDateTime=DateTime.Now,City="SP",State="itapevi",Portfolio="www.Portfolio.com.br",salaryPrefer="2000"},
            new Register{Name= "katia",Email= "katia@hotmail.com",Phone= "11-111111-1111",Linkedin="www.Linkedin.com.br",LinkCRUD="www.LinkCRUD.com.br",CreateDateTime=DateTime.Now,City="SP",State="itapevi",Portfolio="www.Portfolio.com.br",salaryPrefer="2000"},
                };

            foreach (Register r in Registers)
            {
                context.Registers.Add(r);
            }
            context.SaveChanges();


        //inicia no banco os dados da tabela fotos para teste
        var Skills = new RegisterSkill[]
            {
                new RegisterSkill{RegisterId =1,willingnessWorkWeek="Acima de 8 horas por dia)",TimeWork="08:00 ás 12:00",Knowledge="Android,3",OtherLanguageFramework="xamarin,3"},
                new RegisterSkill{RegisterId =2,willingnessWorkWeek="Acima de 8 horas por dia)",TimeWork="08:00 ás 12:00",Knowledge="Ionic,3",OtherLanguageFramework="javascript,3"},
                new RegisterSkill{RegisterId =3,willingnessWorkWeek="Acima de 8 horas por dia)",TimeWork="08:00 ás 12:00",Knowledge="Angular 6,3",OtherLanguageFramework="ReactJS,5,xamarin,3"},
                new RegisterSkill{RegisterId =4,willingnessWorkWeek="Acima de 8 horas por dia)",TimeWork="08:00 ás 12:00",Knowledge="Flutter,3",OtherLanguageFramework="go,5,ef core,3"},
                new RegisterSkill{RegisterId =5,willingnessWorkWeek="Acima de 8 horas por dia)",TimeWork="08:00 ás 12:00",Knowledge="C++,3",OtherLanguageFramework="SWIFT,5,angular,3,css,1,go,5"},
            };

            foreach (RegisterSkill x in Skills)
            {
                context.RegisterSkills.Add(x);
            }
            context.SaveChanges();

        }
    }
}

