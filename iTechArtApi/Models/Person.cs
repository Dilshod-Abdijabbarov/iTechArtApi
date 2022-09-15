namespace iTechArtApi.Models
{
    public class Person
    {
        public int Personid { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

       public virtual ICollection<Pet> Pets { get; set; }

    }
}
