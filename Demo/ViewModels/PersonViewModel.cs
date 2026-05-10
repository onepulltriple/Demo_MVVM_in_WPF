using Demo.Models;

namespace Demo.ViewModels
{
    public class PersonViewModel : ViewModelBase
    {
        private readonly PersonModel _model;

        public string Name => _model.Name;
        public string Age => _model.Age.ToString();

        public string EmployeeNumber
        {
            get { return _model.EmployeeNumber.ToString(); }
            set
            {
                _model.EmployeeNumber = Int32.Parse(value);
            }
        }

        public PersonViewModel(PersonModel model)
        {
            _model = model;
        }
    }
}
