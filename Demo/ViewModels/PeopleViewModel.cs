using Demo.Infrastructure;
using Demo.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Linq;

namespace Demo.ViewModels
{
    public class PeopleViewModel : ViewModelBase
    {
        private int _index;

        public ObservableCollection<PersonViewModel> People { get; }

        private PersonViewModel _currentPerson;
        public PersonViewModel CurrentPerson
        {
            get => _currentPerson;
            private set
            {
                _currentPerson = value;
                NotifyPropertyChanged();
            }
        }

        private PersonViewModel _pitBoss;
        public PersonViewModel PitBoss
        {
            get => _pitBoss;
            private set
            {
                _pitBoss = value;
                NotifyPropertyChanged();
            }
        }

        public ICommand Next { get; }
        public ICommand Previous { get; }

        public PeopleViewModel(IPersonService service)
        {
            var models = service.GetPeople();

            People = new ObservableCollection<PersonViewModel>(
                models.Select(m => new PersonViewModel(m)));

            _index = 0;
            CurrentPerson = People[_index];

            Next =     new RelayCommand(_ => MoveNext(),     _ => _index < People.Count - 1);
            Previous = new RelayCommand(_ => MovePrevious(), _ => _index > 0);

            PitBoss = new PersonViewModel(service.GetOnePerson());
        }

        private void MoveNext()
        {
            if (_index < People.Count - 1)
            {
                _index++;
                CurrentPerson = People[_index];
            }
        }

        private void MovePrevious()
        {
            if (_index > 0)
            {
                _index--;
                CurrentPerson = People[_index];
            }
        }

    }
}
