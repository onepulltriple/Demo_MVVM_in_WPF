using Demo.Models;

namespace Demo.Services
{
    public interface IPersonService
    {
        IEnumerable<PersonModel> GetPeople();

        PersonModel GetOnePerson();
    }
}
