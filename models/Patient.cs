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
        public List<Appointment> Appointments { get; set; }

        public Patient(int id, string name, int age, int phone, string address)
        {
            Id = id;
            Name = name;
            Age = age;
            this.phone = phone;
            Address = address;
            Pets = new List<Pet>();
            Appointments = new List<Appointment>();
        }

        public void Register(Patient patient)
        {
            Console.WriteLine($"Patient registered: {patient.Name}, Age: {patient.Age}, Phone: {patient.Phone}, Address: {patient.Address}");
        }

        // Implementación de INotificable
        public void EnviarNotificacion(string mensaje)
        {
            Console.WriteLine($"[NOTIFICACIÓN] For {Name}: {mensaje}");
        }

        // Método para agendar cita y enviar recordatorio
        public void ScheduleAppointmentt(DateTime fecha)
        {
            // Crear una cita y agregarla a la lista
            var appointment = new Appointment(Appointments.Count + 1, Id, fecha, "Consulta médica", "Doctor asignado");
            Appointments.Add(appointment);
            Console.WriteLine($"Appointment for {Name} on {fecha:dd/MM/yyyy HH:mm}");
        }    

        // Método para agregar una cita
        public void AddAppointment(Appointment appointment)
        {
            Appointments.Add(appointment);
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