using iTechArtApi.IRepositories;
using iTechArtApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace iTechArtApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetController : ControllerBase
    {
        private readonly IPetRepository _petRepository;
        public PetController(IPetRepository petRepository)
        {
            _petRepository = petRepository; 
        }

        //all pet from the database get the list
        [HttpGet]
        public async Task<List<Pet>> GetAllPet()
        {
            return await  _petRepository.GetAllPet();
        }

        //Transfer data from Excel "Pet" to the database 
        [HttpPost("FromExcelToSQLGetPet")]
        public void ExcelToSQL()
        {
            _petRepository.ExcelDataReadPet();
        }


    }
}
