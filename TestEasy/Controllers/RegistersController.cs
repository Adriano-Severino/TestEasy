using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
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
                register.willingnessWorkWeek = model.willingnessWorkWeek;
                register.TimeWork = model.TimeWork;
                register.Knowledge = model.Knowledge;
                register.OtherLanguageFramework = model.OtherLanguageFramework;

                //salva no banco de dados
                _repository.Save(register);

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
            var register = _repository.GetIdRegister(model.Id);

            if (register == null)
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
                register.Name = model.Name;
                register.Email = model.Email;
                register.City = model.City;
                register.State = model.State;
                register.LinkCRUD = model.LinkCRUD;
                register.Linkedin = model.Linkedin;
                register.Phone = model.Phone;
                register.Portfolio = model.Portfolio;
                register.salaryPrefer = model.salaryPrefer;
                register.willingnessWorkWeek = model.willingnessWorkWeek;
                register.TimeWork = model.TimeWork;
                register.Knowledge = model.Knowledge;
                register.OtherLanguageFramework = model.OtherLanguageFramework;
                
                
                //update the db
                _repository.Update(register);
                // _repository.SaveSkill(skills);

                return new ResultViewModel()
                {
                    Success = true,
                    Message = "Registro Atulizado Com Sucesso!",
                    Data = register
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
        public ResultViewModel Deletar(int id)
        {
            try
            {
                var register = _repository.GetIdRegister(id);

                if (register == null)
                {
                    return new ResultViewModel()
                    {
                        Success = false,
                        Message = "Não encontrado",
                    };
                }
                
                _repository.Delete(register);

                return new ResultViewModel()
                {
                    Success = true,

                    Message = "registro Deletado com Sucesso!"
                };
            }
            catch (Exception)
            {
                return new ResultViewModel()
                {
                    Success = false,
                    Message = "Erro ao deletado o registro!"
                };
            }

        }
    }
}

