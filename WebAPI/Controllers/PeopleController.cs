using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        IPersonService _personService;

        public PeopleController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _personService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _personService.GetById(id);
            if(result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }


        [HttpPost("add")]
        public IActionResult Add (Person person)
        {
            var result = _personService.Add(person);
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


    }
}