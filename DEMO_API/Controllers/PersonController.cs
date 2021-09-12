using BAL.Services;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DEMO_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly PersonService service;
        public PersonController(PersonService service)
        {
            this.service = service;
        }

        [HttpGet]
        public IEnumerable<Person> GetAllPersons()
        {
            return service.GetAllPersons();
        }

        [HttpGet("{id}")]
        public IActionResult GetPersonById(int id)
        {
            var person = service.GetPersonById(id);
            if (person != null)
            {
                return Ok(person);
            }
            return BadRequest("User not found");
        }

        [HttpPost]
        public async Task<Person> AddPerson([FromBody] Person person)
        {
            return await service.AddPerson(person);
        }

        [HttpPut]
        public bool UpdatePerson([FromBody] Person person)
        {
            return service.UpdatePerson(person);
        }

        [HttpDelete("{id}")]
        public bool DeletePerson(int id)
        {
            return service.DeletePerson(id);
        }
    }
}
