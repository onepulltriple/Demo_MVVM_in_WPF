using Demo.Models;
using System.ComponentModel;
using System.Windows.Input;

namespace Demo.ViewModels
{
    public class PeopleViewModelOLD : INotifyPropertyChanged
    {
        // bindable properties

        private readonly PersonModel _model;

        public string Name => _model.Name;
        public string Age => _model.Age.ToString();

        //private string _name;

        //public string Name
        //{
        //    get => _name;
        //    private set
        //    {
        //        _name = value;
        //        NotifyPropertyChanged(nameof(Name));
        //    }
        //}

        //private string _age;

        //public string Age
        //{
        //    get => _age;
        //    private set
        //    {
        //        _age = value;
        //        NotifyPropertyChanged(nameof(Age));
        //    }
        //}

        public ICommand Previous { get; init; }

        public ICommand Next { get; init; }

        // implementation

        private PersonModel[] people = new PersonModel[]
        {
            new PersonModel("Alice", 20, 70),
            new PersonModel("Bob", 25, 80),
            new PersonModel("Charlie", 30, 90)
        };

        private int index = 0;

        public PeopleViewModelOLD(PersonModel model) // this is offered as a closure
        {
            //Name = people[index].Name;
            //Age = people[index].Age.ToString();
            _model = model;


            // here we are creating an expression that returns a method, e.g. an action or a function
            //Previous = new RelayCommand((someType) => // the signature of the method,
            //                                  // the rest is the method itself
            //{
            //    if (index > 0)
            //    {
            //        index--;
            //        Name = people[index].Name;
            //        Age = people[index].Age.ToString();
            //    }
            //});

            //Next = new RelayCommand(NextDelegate); // this only works if the signatures match

            //Next = new RelayCommand((whateverType) =>
            //{
            //    if (index < people.Length - 1)
            //    {
            //        index++;
            //        Name = people[index].Name;
            //        Age = people[index].Age.ToString();
            //    }
            //});
        }

        //public void NextDelegate(object someThing)
        //{
        //    if (index < people.Length - 1)
        //    {
        //        index++;
        //        Name = people[index].Name;
        //        Age = people[index].Age.ToString();
        //    }
        //}

        // boilerplate code to satisfy INotifyPropertyChanged

        public event PropertyChangedEventHandler? PropertyChanged;

        public void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged is null) return;
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
