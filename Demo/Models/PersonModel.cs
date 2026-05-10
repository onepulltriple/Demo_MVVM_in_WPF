namespace Demo.Models
{
    public class PersonModel
    {
        public string Name { get; }
        public int Age { get; }
        public int EmployeeNumber { get; set; }
        public PersonModel(string name, int age, int employeeNumber)
        {
            Name = name;
            Age = age;
            EmployeeNumber = employeeNumber;
        }
    }
}
