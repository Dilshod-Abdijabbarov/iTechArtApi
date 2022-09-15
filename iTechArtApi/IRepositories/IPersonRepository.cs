using iTechArtApi.Models;
using System.Linq.Expressions;

namespace iTechArtApi.IRepositories
{
    public interface IPersonRepository
    {
        public void ExselRead();

        public Task<IQueryable<Person>> GetAll();

        public Task<Person> AddPerson(Person person);

        public Task<Pet> AddPetPersonid(Pet pet, int id);
    }
}
