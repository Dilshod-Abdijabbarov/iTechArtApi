using iTechArtApi.Data;
using iTechArtApi.IRepositories;
using iTechArtApi.Models;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using System;


namespace iTechArtApi.Repositories
{
    public class PetRepository : IPetRepository
    {
        private readonly DatabaseContext _database;
            public PetRepository(DatabaseContext database)
        {
            _database = database;   
        }

        //Transfer data from Excel "Pet" to the database
        public void ExcelDataReadPet()
        {
            var FilePath = "C:\\Users\\Dilshod\\source\\repos\\iTechArtApi\\iTechArtApi\\wwwroot\\File\\ExcelFile.xlsx";
            FileInfo fileInfo = new FileInfo(FilePath);
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (ExcelPackage package = new ExcelPackage(fileInfo))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets[1];
                int colcout = worksheet.Dimension.End.Column;
                int rowcout = worksheet.Dimension.End.Row;
                int petsNumber=_database.Pets.Count();
                for (int row = petsNumber+2; row <= rowcout ; row++)
                {
                    Pet pet = new Pet();

                    for (int col = 2; col <= colcout + 2; col++)
                    {
                        if (worksheet.Cells[row, 2].Value.ToString() != "-"&& worksheet.Cells[row, 2].Value.ToString()is not null)
                        {
                            if (col == 2)
                                pet.Name = worksheet.Cells[row, col].Value.ToString();
                            if (col == 3)
                                pet.Type = worksheet.Cells[row, col].Value.ToString();

                        }
                    }
                     _database.Pets.Add(pet);

                     _database.SaveChanges();
                                        
                }
            }
            
        }

        public async  Task<List<Pet>> GetAllPet()
        {
            return await _database.Pets.ToListAsync();
        }
        public async  Task<Pet> AddPet(Pet pet)
        {
            Person person = new Person();

            person.Pets.Add(pet);

            await _database.Pets.AddAsync(pet);

            await _database.People.AddAsync(person);

            return pet;

        }
    }
}
