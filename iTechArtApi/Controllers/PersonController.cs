using iTechArtApi.Data;
using iTechArtApi.IRepositories;
using iTechArtApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;

namespace iTechArtApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        public IPersonRepository _personRepository;
        public PersonController(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        //all people from the database get the list
        [HttpGet]
        public async  Task<IQueryable<Person>> GetAll()
        {
            return await  _personRepository.GetAll();
        }

        //Transfer data from Excel "Person" to the database 
        [HttpPost("Excel Read")]
        public void ExcelReadData()
        {
            _personRepository.ExselRead();
        }

        //adding people to the database
        [HttpPost]
        public Person Add([FromBody] Person person)
        {
            _personRepository.AddPerson(person);
            return person;
        }

        //add information about pets to a person
        [HttpPost("AddPetToPersonId")]
        public async Task<Pet> Addpet([FromBody] Pet pet,int id)
        {
           await  _personRepository.AddPetPersonid(pet,id);
            return pet;
        }

        
    }
}
