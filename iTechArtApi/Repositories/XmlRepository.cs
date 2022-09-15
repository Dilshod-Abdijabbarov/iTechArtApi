using iTechArtApi.Data;
using iTechArtApi.IRepositories;
using iTechArtApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Xml;

namespace iTechArtApi.Repositories
{
    public class XmlRepository:IXmlRepository
    {
        public DatabaseContext _database;
        public XmlRepository(DatabaseContext database)
        {
            _database = database;
        }
        //Transfer data from database to the Xml
        public void Createxml()
        {

            using (XmlWriter writer = XmlWriter.Create("Person.xml"))
            {
                var ss = _database.People.Include("Pets").ToList();
                
                writer.WriteStartDocument();
                writer.WriteStartElement("People");
                foreach (Person item in ss)
                {
                    writer.WriteStartElement("Person");
                    writer.WriteElementString("Id", item.Personid.ToString());
                    writer.WriteElementString("Name", item.Name);
                    writer.WriteElementString("Age", item.Age.ToString());
                    foreach (var pet in item.Pets.ToList())
                    {
                        writer.WriteStartElement("Pet");
                        writer.WriteElementString("Petid", pet.Petid.ToString());
                        writer.WriteElementString("Name", pet.Name);
                        writer.WriteElementString("Type", pet.Type);
                        writer.WriteEndElement();
                    }
                    writer.WriteEndElement();

                }
                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
        }

    }
}
