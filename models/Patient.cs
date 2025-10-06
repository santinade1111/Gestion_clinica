using Gestion_clinica.Interfaces;
namespace Gestion_clinica.models
{
    public class Patient : IRegistrable<Patient>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Symptom { get; set; }
        private int phone;
        public string Address { get; set; }
        public List<Pet> Pets { get; set; }

        public Patient(int id, string name, int age, string symptom, int phone, string address)
        {
            Id = id;
            Name = name;
            Age = age;
            Symptom = symptom;
            this.phone = phone;
            Address = address;
            Pets = new List<Pet>();
        }

        public void Register(Patient patient)
        {
            Console.WriteLine($"Patient registered: {patient.Name}, Age: {patient.Age}, Phone: {patient.Phone}, Address: {patient.Address}");
        }

        public int Phone
        {
            get { return phone; }
            set
            {
                if (value <= 0) throw new ArgumentException("Phone number must be a valid positive integer.");
                phone = value;
            }
        }
    }
}