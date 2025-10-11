using Gestion_clinica.models;

namespace Gestion_clinica
{
    class Program
    {
        static void Main(string[] args)
        {
            // Crear las instancias de los repositorios
            ICustomerRepository customerRepo = new CustomerRepository();
            IPetRepository petRepo = new PetRepository();
            IVeterinarianRepository vetRepo = new VeterinarianRepository();
            IAppointmentRepository appointmentRepo = new AppointmentRepository();

            // Crear el servicio de gestión
            var managementService = new ManagementService(customerRepo, petRepo, vetRepo, appointmentRepo);

            // Crear y mostrar el menú
            var menu = new Menu(managementService);
            menu.ShowMenu();
        }
    }
}
