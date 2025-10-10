using Gestion_clinica.Interfaces;
namespace Gestion_clinica.models
{
    public class Customer 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public List<Pet> Pets { get; set; }
        public List<Appointment> Appointments { get; set; }

        public Customer(int id, string name, int age, string address)
        {
            Id = id;
            Name = name;
            Age = age;
            Address = address;
            Pets = new List<Pet>();
            Appointments = new List<Appointment>();
        }

       
    }
}