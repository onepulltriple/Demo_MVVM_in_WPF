using Demo.Models;

namespace Demo.Services
{
    public class PersonService : IPersonService
    {
        public IEnumerable<PersonModel> GetPeople()
        {
            // In a real app, this would be: a database, REST API, file, etc.
            // the source of truth / where data comes from / where business rules live

            return new List<PersonModel>
            {
                new PersonModel("Alice", 20),
                new PersonModel("Bob", 25),
                new PersonModel("Charlie", 30)
            };


        }
    }
}
