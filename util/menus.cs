using Gestion_clinica.models;
namespace Gestion_clinica
{
    public class Menu
    {
        private readonly ManagementService _managementService;

        public Menu(ManagementService managementService)
        {
            _managementService = managementService;
        }

        public void ShowMenu()
        {
            bool running = true;
            while (running)
            {
                Console.Clear();
                Console.WriteLine(" ---- CLINICAL VETERINARY ---");
                Console.WriteLine("1. Patient Consultation");
                Console.WriteLine("2. Pets Consultation");
                Console.WriteLine("3. Veterinarian consultation");
                Console.WriteLine("4. Appointment consultation");
                Console.WriteLine("5. Exit");
                Console.Write("Select an option: ");
                var opcion = Console.ReadLine() ?? string.Empty;

                switch (opcion)
                {
                    case "1":
                        PatientMenu();
                        break;
                    case "2":
                        PetMenu();
                        break;
                    case "3":
                        VeterinarianMenu();
                        break;
                    case "4":
                        AppointmentMenu();
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Invalid option. Press Enter to continue");
                        Console.ReadLine();
                        break;
                }
            }
        }

        public void PatientMenu()
        {
            bool running = true;
            while (running)
            {
                Console.Clear();
                Console.WriteLine(" ---- Patient Menu ---");
                Console.WriteLine("1. Register Customer");
                Console.WriteLine("2. See customers");
                Console.WriteLine("3. Update customer");
                Console.WriteLine("3. Delete customer");
                Console.WriteLine("0. Salir");
                Console.WriteLine("Seleccione una opción: ");
                string option = Console.ReadLine() ?? string.Empty;

                switch (option)
                {
                    case "1":
                        RegisterCustomer();
                        break;
                    case "2":
                        ShowAllCustomers();
                        break;
                    case "3":
                        UpdateCustomer();
                        break;
                    case "4":
                        DeleteCustomer();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Opción no válida. Presione Enter para continuar...");
                        Console.ReadLine();
                        break;
                }
            }
        }

        public void PetMenu()
        {
            bool running = true;
            while (running)
            {
                Console.Clear();
                Console.WriteLine(" ---- Pets Menu ---");
                Console.WriteLine("1. Register Pet");
                Console.WriteLine("2. See Pets");
                Console.WriteLine("3. Upadate Pets");
                Console.WriteLine("4. Delete Pets");
                Console.WriteLine("0. Salir");
                Console.WriteLine("Seleccione una opción: ");
                string option = Console.ReadLine() ?? string.Empty;

                switch (option)
                {
                    case "1":
                        RegisterPet();
                        break;
                    case "2":
                        ShowAllPets();
                        break;
                    case "3":
                        UpdatePet();
                        break;
                    case "4":
                        DeletePet();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Opción no válida. Presione Enter para continuar...");
                        Console.ReadLine();
                        break;
                }
            }
        }

        public void VeterinarianMenu()
        {
            bool running = true;
            while (running)
            {
                Console.Clear();
                Console.WriteLine(" ---- Veterinarian Menu ---");
                Console.WriteLine("1. Register veterinarian");
                Console.WriteLine("2. See Veterinarian");
                Console.WriteLine("3. Upadate Veterinarian");
                Console.WriteLine("4. Delete Veterinarian");
                Console.WriteLine("0. Salir");
                Console.WriteLine("Seleccione una opción: ");
                string option = Console.ReadLine() ?? string.Empty;

                switch (option)
                {
                    case "1":
                        RegisterVeterinarian();
                        break;
                    case "2":
                        ShowAllVeterinarians();
                        break;
                    case "3":
                        UpdateVeterinarian();
                        break;
                    case "4":
                        DeleteVeterinarian();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Opción no válida. Presione Enter para continuar...");
                        Console.ReadLine();
                        break;
                }
            }
        }

        public void AppointmentMenu()
        {
            bool running = true;
            while (running)
            {
                Console.Clear();
                Console.WriteLine(" ---- Appointment Menu ---");
                Console.WriteLine("1. Register Appointment");
                Console.WriteLine("2. See appointments");
                Console.WriteLine("3. Update appointments");
                Console.WriteLine("4. Delete appointments");
                Console.WriteLine("0. Salir");
                Console.WriteLine("Seleccione una opción: ");
                string option = Console.ReadLine() ?? string.Empty;

                switch (option)
                {
                    case "1":
                        ScheduleAppointment();
                        break;
                    case "2":
                        ShowAllAppointments();
                        break;
                    case "3":
                        UpdateAppointment();
                        break;
                    case "4":
                        DeleteAppointment();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Opción no válida. Presione Enter para continuar...");
                        Console.ReadLine();
                        break;
                }
            }
        }

        private void RegisterCustomer()
        {
            // Validación para el nombre
            Console.WriteLine("Ingrese el nombre del cliente:");
            string name = Console.ReadLine()?.Trim();
            if (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("El nombre no puede estar vacío. Operación cancelada. Presione Enter para continuar...");
                Console.ReadLine();
                return;
            }

            // Validación para la edad
            Console.WriteLine("Ingrese la edad del cliente:");
            string ageInput = Console.ReadLine() ?? string.Empty;
            if (!int.TryParse(ageInput, out int age) || age < 0 || age > 130)
            {
                Console.WriteLine("Edad inválida. La edad debe ser un número entre 0 y 30. Operación cancelada. Presione Enter para continuar...");
                Console.ReadLine();
                return;
            }

            // Validación para la dirección
            Console.WriteLine("Ingrese la dirección del cliente:");
            string address = Console.ReadLine()?.Trim();
            if (string.IsNullOrEmpty(address))
            {
                Console.WriteLine("La dirección no puede estar vacía. Operación cancelada. Presione Enter para continuar...");
                Console.ReadLine();
                return;
            }

            // Registro del cliente
            _managementService.RegisterCustomer(name, age, address);
            Console.WriteLine("Cliente registrado con éxito! Presione Enter para continuar...");
            Console.ReadLine();
        }


        private void ShowAllCustomers()
        {
            var customers = _managementService.GetAllCustomers();
            foreach (var customer in customers)
            {
                Console.WriteLine($"ID: {customer.Id}, Nombre: {customer.Name}, Edad: {customer.Age}, Dirección: {customer.Address}");
            }
            Console.WriteLine("Presione cualquier tecla para volver al menú.");
            Console.ReadKey();
        }

        private void UpdateCustomer()
        {
            Console.WriteLine("Ingrese el ID del cliente a actualizar:");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el nuevo nombre del cliente:");
            string name = Console.ReadLine();
            if (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("El nombre no puede estar vacío. Operación cancelada. Presione Enter para continuar...");
                Console.ReadLine();
                return;
            }
            Console.WriteLine("Ingrese la nueva edad del cliente:");
            int age = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese la nueva dirección del cliente:");
            string address = Console.ReadLine();

            var updatedCustomer = new Customer(id, name, age, address);
            _managementService.UpdateCustomer(updatedCustomer);
            Console.WriteLine("Cliente actualizado con éxito!");
        }

        private void DeleteCustomer()
        {
            Console.WriteLine("Ingrese el ID del cliente a eliminar:");
            int id = int.Parse(Console.ReadLine());
            _managementService.DeleteCustomer(id);
            Console.WriteLine("Cliente eliminado con éxito!");
        }

        private void RegisterPet()
        {
            Console.WriteLine("Ingrese el nombre de la mascota:");
            string name = Console.ReadLine();
            Console.WriteLine("Ingrese la edad de la mascota:");
            int age = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese la especie de la mascota:");
            string specie = Console.ReadLine();
            Console.WriteLine("Ingrese la raza de la mascota:");
            string race = Console.ReadLine();
            Console.WriteLine("Ingrese el nombre del dueño de la mascota:");
            string owner = Console.ReadLine();

            _managementService.RegisterPet(name, age, specie, race, owner);
            Console.WriteLine("Mascota registrada con éxito!");
        }

        private void ShowAllPets()
        {
            var pets = _managementService.GetAllPets();
            foreach (var pet in pets)
            {
                Console.WriteLine($"Nombre: {pet.Name}, Especie: {pet.Specie}, Raza: {pet.Race}, Dueño: {pet.Owner}");
            }
            Console.WriteLine("Presione cualquier tecla para volver al menú.");
            Console.ReadKey();
        }

        private void UpdatePet()
        {
            Console.WriteLine("Ingrese el nombre de la mascota a actualizar:");
            string name = Console.ReadLine();
            Console.WriteLine("Ingrese la nueva edad de la mascota:");
            int age = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese la nueva especie de la mascota:");
            string specie = Console.ReadLine();
            Console.WriteLine("Ingrese la nueva raza de la mascota:");
            string race = Console.ReadLine();
            Console.WriteLine("Ingrese el nuevo nombre del dueño de la mascota:");
            string owner = Console.ReadLine();

            var updatedPet = new Pet(name, age, specie, race, owner);
            _managementService.UpdatePet(updatedPet);
            Console.WriteLine("Mascota actualizada con éxito!");
        }

        private void DeletePet()
        {
            Console.WriteLine("Ingrese el nombre de la mascota a eliminar:");
            string name = Console.ReadLine();
            _managementService.DeletePet(name);
            Console.WriteLine("Mascota eliminada con éxito!");
        }

        private void RegisterVeterinarian()
        {
            Console.WriteLine("Ingrese el ID del veterinario:");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el nombre del veterinario:");
            string name = Console.ReadLine();
            Console.WriteLine("Ingrese la especialidad del veterinario:");
            string specialty = Console.ReadLine();

            _managementService.RegisterVeterinarian(id, name, specialty);
            Console.WriteLine("Veterinario registrado con éxito!");
        }

        private void ShowAllVeterinarians()
        {
            var vets = _managementService.GetAllVeterinarians();
            foreach (var vet in vets)
            {
                Console.WriteLine($"ID: {vet.Id}, Nombre: {vet.Name}, Especialidad: {vet.Specialty}");
            }
            Console.WriteLine("Presione cualquier tecla para volver al menú.");
            Console.ReadKey();
        }

        private void UpdateVeterinarian()
        {
            Console.WriteLine("Ingrese el ID del veterinario a actualizar:");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el nuevo nombre del veterinario:");
            string name = Console.ReadLine();
            Console.WriteLine("Ingrese la nueva especialidad del veterinario:");
            string specialty = Console.ReadLine();

            var updatedVet = new Veterinarian(id, name, specialty);
            _managementService.UpdateVeterinarian(updatedVet);
            Console.WriteLine("Veterinario actualizado con éxito!");
        }

        private void DeleteVeterinarian()
        {
            Console.WriteLine("Ingrese el ID del veterinario a eliminar:");
            int id = int.Parse(Console.ReadLine());
            _managementService.DeleteVeterinarian(id);
            Console.WriteLine("Veterinario eliminado con éxito!");
        }


        private void ScheduleAppointment()
        {
            Console.WriteLine("Ingrese el ID de la cita:");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el ID del cliente:");
            int customerId = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese la fecha de la cita (formato: dd/MM/yyyy HH:mm):");
            DateTime date = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese una descripción para la cita:");
            string description = Console.ReadLine();
            Console.WriteLine("Ingrese el ID del veterinario:");
            int vetId = int.Parse(Console.ReadLine());

            _managementService.ScheduleAppointment(id, customerId, date, description, vetId);
            Console.WriteLine("Cita agendada con éxito!");
        }

        private void ShowAllAppointments()
        {
            var appointments = _managementService.GetAllAppointments();
            foreach (var appointment in appointments)
            {
                Console.WriteLine(appointment);
            }
            Console.WriteLine("Presione cualquier tecla para volver al menú.");
            Console.ReadKey();
        }

        private void UpdateAppointment()
        {
            Console.WriteLine("Ingrese el ID de la cita a actualizar:");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el ID del customer:");
            int customerId = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese la nueva fecha de la cita (formato: dd/MM/yyyy HH:mm):");
            DateTime date = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese la nueva descripción de la cita:");
            string description = Console.ReadLine();
            Console.WriteLine("Ingrese el nuevo ID del veterinario:");

            var UpdateAppoint = new Appointment(id, customerId, date, description);
            _managementService.UpdateAppointment(UpdateAppoint);
            Console.WriteLine("Cita actualizada con éxito!");
        }

        private void DeleteAppointment()
        {
            Console.WriteLine("Ingrese el ID de la cita a eliminar:");
            int id = int.Parse(Console.ReadLine());
            _managementService.DeleteAppointment(id);
            Console.WriteLine("Cita eliminada con éxito!");
        }

    }
}






