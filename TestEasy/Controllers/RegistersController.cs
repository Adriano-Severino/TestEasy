using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestEasy.Domain.Models;
using TestEasy.Repository;
using TestEasy.ViewModels;
using TestEasy.ViewModels.RegisterViewModel;

namespace TestEasy.Controllers
{
    [ApiController]
    public class RegistersController : Controller
    {
        private readonly RegisterRepository _repository;

        public RegistersController(RegisterRepository repository)
        {
            _repository = repository;
        }

        // GET: register
        [Route("v1/registers")]
        [ResponseCache(Duration = 3600)]
        [HttpGet]
        public IEnumerable<ListRegisterViewModel> GetRegister()
        {
            return _repository.GetRegister();
        }

        // GET: register id
        [Route("v1/registers/{id}")]
        [HttpGet]
        public Register GetIdRegister(int id)
        {
            return _repository.GetIdRegister(id);
        }

        [Route("v1/registers/{id}/skills")]
        [ResponseCache(Duration = 30)]
        [HttpGet]
        public IEnumerable<ListRegisterViewModel> GetRegistersSkills(int id)
        {
            return _repository.GetRegistersSkills(id);
        }

        // POST: register
        [Route("v1/registers")]
        [HttpPost]
        public ResultViewModel CreateRegister([Bind("Id,Name,Email,City,State,LinkCRUD,Linkedin,Phone,Portfolio,salaryPrefer,CreateDateTime,RegisterId,willingnessWorkWeek,TimeWork,Knowledge,OtherLanguageFramework")][FromBody] EditRegisterViewModel model)
        {
            // valida os campos digitado pelo usuario
            model.Validate();
            if (model.Invalid)
                return new ResultViewModel
                {
                    Success = false,
                    Message = "Não foi possivel registrar",
                    Data = model.Notifications
                };
            try
            {
                var register = new Register();
                var skills = new RegisterSkill();
                register.Name = model.Name;
                register.Email = model.Email;
                register.City = model.City;
                register.State = model.State;
                register.LinkCRUD = model.LinkCRUD;
                register.Linkedin = model.Linkedin;
                register.Phone = model.Phone;
                register.Portfolio = model.Portfolio;
                register.salaryPrefer = model.salaryPrefer;
                register.CreateDateTime = DateTime.Now;
                skills.RegisterId = register.Id;
                skills.willingnessWorkWeek = model.willingnessWorkWeek;
                skills.TimeWork = model.TimeWork;
                skills.Knowledge = model.Knowledge;
                skills.OtherLanguageFramework = model.OtherLanguageFramework;

                //salva no banco de dados
                _repository.Save(register);
                var registerId = _repository.GetIdRegister(register.Id);
                skills.RegisterId = registerId.Id;
                _repository.SaveSkill(skills);

                //sucesso ao salvar no banco de dados
                return new ResultViewModel
                {
                    Success = true,
                    Message = "Registrado Com Sucesso!",
                    Data = register
                };
            }
            catch (Exception)
            {
                return new ResultViewModel
                {
                    Success = false,
                    Message = "Erro ao criar o registro!",
                    Data = model.Notifications
                };
            }

        }

        // Put: register
        [Route("v1/registers")]
        [HttpPut]
        //[ValidateAntiForgeryToken]
        public ResultViewModel UpdateRegisters([Bind("Id,Name,Email,City,State,LinkCRUD,Linkedin,Phone,Portfolio,salaryPrefer,CreateDateTime")][FromBody] EditRegisterViewModel model)
        {
           
            //buscar no banco o registro para a atualização
            var registerskills = _repository.GetIdRegister(model.Id);
            var skills = new RegisterSkill();

            if (registerskills == null)
            {
                return new ResultViewModel()
                {
                    Success = false,
                    Message = "Não encontrado",
                    Data = model.Notifications
                };
            }

            //valida os campos digitado pelo usuario
            model.Validate();
            if (model.Invalid)
                return new ResultViewModel()
                {
                    Success = false,
                    Message = "Nao foi possivel atualizar o registro",
                    Data = model.Notifications
                };

            try
            {
                registerskills.Name = model.Name;
                registerskills.Email = model.Email;
                registerskills.City = model.City;
                registerskills.State = model.State;
                registerskills.LinkCRUD = model.LinkCRUD;
                registerskills.Linkedin = model.Linkedin;
                registerskills.Phone = model.Phone;
                registerskills.Portfolio = model.Portfolio;
                registerskills.salaryPrefer = model.salaryPrefer;
                skills.RegisterId = model.Id;
                skills.Id = registerskills.Skills.FirstOrDefault().Id;
                skills.willingnessWorkWeek = registerskills.Skills.FirstOrDefault().willingnessWorkWeek;
                skills.TimeWork = registerskills.Skills.FirstOrDefault().TimeWork;
                skills.Knowledge = registerskills.Skills.FirstOrDefault().Knowledge;
                skills.OtherLanguageFramework = registerskills.Skills.FirstOrDefault().OtherLanguageFramework;

                //update the db
                _repository.Update(registerskills);
               // _repository.SaveSkill(skills);

                return new ResultViewModel()
                {
                    Success = true,
                    Message = "Registro Atulizado Com Sucesso!",
                    Data = registerskills
                };
            }
            catch (Exception)
            {
                return new ResultViewModel()
                {
                    Success = false,
                    Message = "Erro ao atualizar o registro",
                    Data = model.Notifications
                };
            }


        }

        // Delete: register
        [Route("v1/registers/{id}")]
        [HttpDelete]
        public ResultViewModel Deletar([FromBody] EditRegisterViewModel model, int id = -1)
        {
            try
            {
                var registers = new Register();
                _ = id == -1 ? registers.Id = model.Id : registers.Id = id;
                registers.Name = model.Name;

                _repository.Delete(registers);

                return new ResultViewModel()
                {
                    Success = true,

                    Message = "registro Deletado com Sucesso!",
                    Data = model.Notifications
                };
            }
            catch (Exception)
            {
                return new ResultViewModel()
                {
                    Success = false,
                    Message = "Erro ao deletado o registro!",
                    Data = model.Notifications
                };
            }

        }
    }
}

