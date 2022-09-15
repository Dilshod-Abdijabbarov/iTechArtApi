using iTechArtApi.Data;
using iTechArtApi.IRepositories;
using iTechArtApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using System.Linq.Expressions;

namespace iTechArtApi.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        public DatabaseContext _database;
        public PersonRepository(DatabaseContext database)
        {
            _database = database;
        }

        //Transfer data from Excel "Person" to the database 
        public void ExselRead()
        {
            var FilePath = "C:\\Users\\Dilshod\\source\\repos\\iTechArtApi\\iTechArtApi\\wwwroot\\File\\ExcelFile.xlsx";
            FileInfo fileInfo = new FileInfo(FilePath);
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (ExcelPackage package = new ExcelPackage(fileInfo))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                int colcout = worksheet.Dimension.End.Column;
                int rowcout = worksheet.Dimension.End.Row;
               int number= _database.People.Count();
                for (int row =number+2 ; row <= rowcout ; row++)
                {
                    Person person = new Person();
                    for (int col = 2; col <= colcout + 2; col++)
                    {
                        if (worksheet.Cells[row, col].Value.ToString() is not null)
                        {
                            if (col == 2)
                                person.Name = worksheet.Cells[row, col].Value.ToString();
                            if (col == 3)
                                person.Age = int.Parse(worksheet.Cells[row, col].Value.ToString());
                        }
                    }
                    _database.People.Add(person);
                    _database.SaveChanges();
                }
            }
          
        }
        public async Task<IQueryable<Person>> GetAll()
        {
            return  _database.People.Include("Pets");
        
        }
      
        public async  Task<Person> AddPerson( Person person)
        {
            
            await    _database.AddAsync(person);

            await _database.SaveChangesAsync();

            return person;
        }
        
        public async Task<Pet> AddPetPersonid(Pet pet,int id)
        {
            var person = await  _database.People.Include(person => person.Pets).FirstOrDefaultAsync(person => person.Personid == id);
            if (person == null)
                return null;
            
            person.Pets.Add(pet);
            await  _database.SaveChangesAsync();
            return pet;
        
        }


    }
    
}
