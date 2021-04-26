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

       
    }
}

