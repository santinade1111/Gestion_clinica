using Gestion_clinica.Interfaces;
namespace Gestion_clinica.models
{
    using Gestion_clinica.interfaces;
    public class Patient : IRegistrable<Patient>, INotificable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        private int phone;
        public string Address { get; set; }
        public List<Pet> Pets { get; set; }

        public Patient(int id, string name, int age, int phone, string address)
        {
            Id = id;
            Name = name;
            Age = age;
            this.phone = phone;
            Address = address;
            Pets = new List<Pet>();
        }

        public void Register(Patient patient)
        {
            Console.WriteLine($"Patient registered: {patient.Name}, Age: {patient.Age}, Phone: {patient.Phone}, Address: {patient.Address}");
        }

        // Implementación de INotificable
        public void EnviarNotificacion(string mensaje)
        {
            Console.WriteLine($"[NOTIFICACIÓN] Para {Name}: {mensaje}");
        }

        // Método para agendar cita y enviar recordatorio
        public void AgendarCita(DateTime fecha)
        {
            Console.WriteLine($"Cita agendada para {Name} el {fecha:dd/MM/yyyy HH:mm}");
            EnviarNotificacion($"Recordatorio de cita el {fecha:dd/MM/yyyy HH:mm}");
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