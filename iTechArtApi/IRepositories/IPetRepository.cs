using iTechArtApi.Models;

namespace iTechArtApi.IRepositories
{
    public interface IPetRepository
    {
        public void ExcelDataReadPet();

        public Task<List<Pet>> GetAllPet();
    }
}
