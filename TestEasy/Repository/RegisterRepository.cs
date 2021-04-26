using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
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

        public IEnumerable<ListRegisterViewModel> GetRegister()
        {
            return _context.Registers
                .Include(x => x.Skills)
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
                    CreateDateTime = x.CreateDateTime,
                    Skills = x.Skills

                })
                .AsNoTracking()
                .ToList();

        }

        public Register GetIdRegister(int id)
        {
            return _context.Registers.AsNoTracking().Where(x => x.Id == id).FirstOrDefault();
        }

       


        public void Save(Register register)
        {
            _context.Registers.Add(register);
            _context.SaveChanges();
        }

        public void Update(Register register)
        {
            _context.Entry<Register>(register).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public Register Delete(Register register)
        {
            _context.Registers.Remove(register);
            _context.SaveChanges();

            return register;
        }

    }
}

