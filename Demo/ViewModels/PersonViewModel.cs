using Demo.Models;

namespace Demo.ViewModels
{
    public class PersonViewModel : ViewModelBase
    {
        private readonly PersonModel _model;

        public string Name => _model.Name;
        public string Age => _model.Age.ToString();

        public PersonViewModel(PersonModel model)
        {
            _model = model;
        }
    }
}
