using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using TestEasy.Data;
using TestEasy.Domain.Models;
using TestEasy.ViewModels.RegisterViewModel;

namespace TestEasy.Repository
{
    public class RegisterRepository
    {
        private readonly TestEasyDbContext _context;

        public RegisterRepository(TestEasyDbContext context)
        {
            _context = context;
        }

        internal IEnumerable<ListRegisterViewModel> GetRegister()
        {
            return _context.Registers
                .Select(x => new ListRegisterViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Email = x.Email,
                    City = x.City,
                    State = x.State,
                    LinkCRUD = x.LinkCRUD,
                    Linkedin = x.Linkedin,
                    Phone = x.Phone,
                    Portfolio = x.Portfolio,
                    salaryPrefer = x.salaryPrefer,
                    willingnessWorkWeek = x.willingnessWorkWeek,
                    TimeWork = x.TimeWork,
                    Knowledge = x.Knowledge,
                    OtherLanguageFramework = x.OtherLanguageFramework,
                    CreateDateTime = x.CreateDateTime,

                })
                .AsNoTracking()
                .ToList();

        }

        internal Register GetIdRegister(int id)
        {
            return _context.Registers.AsNoTracking()
                .Where(x => x.Id == id).FirstOrDefault();
        }
        internal IEnumerable<ListRegisterViewModel> GetRegistersSkills(int id)
        {
          
            return _context.Registers
                .Where(x => x.Id == id)
                .Select(x => new ListRegisterViewModel 
                {

                    Id = x.Id,
                    Name = x.Name,
                    Email = x.Email,
                    City = x.City,
                    State = x.State,
                    LinkCRUD = x.LinkCRUD,
                    Linkedin = x.Linkedin,
                    Phone = x.Phone,
                    Portfolio = x.Portfolio,
                    salaryPrefer = x.salaryPrefer,
                    willingnessWorkWeek = x.willingnessWorkWeek,
                    TimeWork = x.TimeWork,
                    Knowledge = x.Knowledge,
                    OtherLanguageFramework = x.OtherLanguageFramework,
                    CreateDateTime = x.CreateDateTime,


                })
                .AsNoTracking()
                .ToList();

        }
        
        internal void Save(Register register)
        {
            _context.Registers.Add(register);
            _context.SaveChanges();
        }
        internal void Update(Register register)
        {
            _context.Entry<Register>(register).State = EntityState.Modified;
            _context.SaveChanges();
        }

        internal Register Delete(Register register)
        {
            _context.Registers.Remove(register);
            _context.SaveChanges();

            return register;
        }

    }
}

