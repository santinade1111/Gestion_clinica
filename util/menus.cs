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
                Console.WriteLine("4. Delete customer");
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

            Console.WriteLine("Ingrese el nombre del cliente:");
            string name = Console.ReadLine()?.Trim();
            if (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("El nombre no puede estar vacío. Operación cancelada. Presione Enter para continuar...");
                Console.ReadLine();
                return;
            }


            Console.WriteLine("Ingrese la edad del cliente:");
            string ageInput = Console.ReadLine() ?? string.Empty;
            if (!int.TryParse(ageInput, out int age) || age < 0 || age > 130)
            {
                Console.WriteLine("Edad inválida. La edad debe ser un número entre 0 y 30. Operación cancelada. Presione Enter para continuar...");
                Console.ReadLine();
                return;
            }

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

            if (customers == null || !customers.Any())
            {
                Console.WriteLine("⚠️ No hay clientes registrados en el sistema.");
            }
            else
            {
                Console.WriteLine("📋 Lista de clientes registrados:\n");

                foreach (var customer in customers)
                {
                    int petCount = _managementService.GetPetCountByCustomer(customer.Id);

                    Console.WriteLine($"ID: {customer.Id} | Nombre: {customer.Name} | Edad: {customer.Age} | Dirección: {customer.Address} | 🐾 Mascotas: {petCount}");
                    if (customer.Appointments.Any())
                    {
                        Console.WriteLine("  📅 Citas agendadas:");
                        foreach (var appointment in customer.Appointments)
                        {
                            Console.WriteLine($"     - {appointment}");
                        }
                    }
                    Console.WriteLine();
                }
            }

            Console.WriteLine("\nPresione cualquier tecla para volver al menú.");
            Console.ReadKey();
        }



        private void UpdateCustomer()
        {
            int id;

            // 🔁 Bucle hasta que se ingrese un ID válido y existente
            while (true)
            {
                Console.WriteLine("Ingrese el ID del cliente a actualizar:");
                string? idInput = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(idInput) || !int.TryParse(idInput, out id))
                {
                    Console.WriteLine("⚠️ ID inválido. Intente nuevamente.\n");
                    continue;
                }

                // Verificar existencia del cliente antes de continuar
                if (!_managementService.CustomerExists(id))
                {
                    Console.WriteLine($"⚠️ No existe ningún cliente con el ID {id}. Intente nuevamente.\n");
                    continue;
                }


                break;
            }

            Console.WriteLine("Ingrese el nuevo nombre del cliente:");
            string? name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("El nombre no puede estar vacío. Operación cancelada.");
                Console.ReadLine();
                return;
            }

            Console.WriteLine("Ingrese la nueva edad del cliente:");
            string? ageInput = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(ageInput) || !int.TryParse(ageInput, out int age))
            {
                Console.WriteLine("Edad inválida. Operación cancelada.");
                Console.ReadLine();
                return;
            }

            Console.WriteLine("Ingrese la nueva dirección del cliente:");
            string? address = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(address))
            {
                Console.WriteLine("La dirección no puede estar vacía. Operación cancelada.");
                Console.ReadLine();
                return;
            }

            var updatedCustomer = new Customer(id, name, age, address);
            _managementService.UpdateCustomer(updatedCustomer);
            Console.WriteLine("✅ Cliente actualizado con éxito!");
        }



        private void DeleteCustomer()
        {
            Console.WriteLine("Ingrese el ID del cliente a eliminar:");
            string? idInput = Console.ReadLine()?.Trim();

            if (string.IsNullOrWhiteSpace(idInput) || !int.TryParse(idInput, out int id) || id <= 0)
            {
                Console.WriteLine("❌ ID inválido. Debe ser un número entero positivo. Operación cancelada. Presione Enter para continuar...");
                Console.ReadLine();
                return;
            }

            // ✅ Validar si el cliente existe antes de eliminar
            if (!_managementService.CustomerExists(id))
            {
                Console.WriteLine($"⚠️ No existe ningún cliente con el ID {id}. Operación cancelada. Presione Enter para continuar...");
                Console.ReadLine();
                return;
            }

            // ✅ Eliminar si existe
            _managementService.DeleteCustomer(id);
            Console.WriteLine("✅ Cliente eliminado con éxito. Presione Enter para continuar...");
            Console.ReadLine();
        }



        private void RegisterPet()
        {
            // --- ID del dueño ---
            Console.WriteLine("Ingrese el ID del dueño de la mascota:");
            string? idInput = Console.ReadLine()?.Trim();

            if (string.IsNullOrWhiteSpace(idInput) || !int.TryParse(idInput, out int ownerId) || ownerId <= 0)
            {
                Console.WriteLine("❌ ID inválido. Debe ser un número entero positivo. Operación cancelada. Presione Enter para continuar...");
                Console.ReadLine();
                return;
            }

            // ✅ Verificar si el cliente (dueño) existe
            if (!_managementService.CustomerExists(ownerId))
            {
                Console.WriteLine($"⚠️ No existe ningún cliente con el ID {ownerId}. No se puede registrar la mascota. Presione Enter para continuar...");
                Console.ReadLine();
                return;
            }

            // --- Nombre ---
            Console.WriteLine("Ingrese el nombre de la mascota:");
            string? name = Console.ReadLine()?.Trim();
            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("❌ El nombre de la mascota no puede estar vacío. Operación cancelada. Presione Enter para continuar...");
                Console.ReadLine();
                return;
            }

            // --- Edad ---
            Console.WriteLine("Ingrese la edad de la mascota:");
            string? ageInput = Console.ReadLine()?.Trim();
            if (string.IsNullOrWhiteSpace(ageInput) || !int.TryParse(ageInput, out int age) || age < 0 || age > 50)
            {
                Console.WriteLine("❌ Edad inválida. Debe ser un número entre 0 y 50. Operación cancelada. Presione Enter para continuar...");
                Console.ReadLine();
                return;
            }

            // --- Especie ---
            Console.WriteLine("Ingrese la especie de la mascota:");
            string? specie = Console.ReadLine()?.Trim();
            if (string.IsNullOrWhiteSpace(specie))
            {
                Console.WriteLine("❌ La especie no puede estar vacía. Operación cancelada. Presione Enter para continuar...");
                Console.ReadLine();
                return;
            }

            // --- Raza ---
            Console.WriteLine("Ingrese la raza de la mascota:");
            string? race = Console.ReadLine()?.Trim();
            if (string.IsNullOrWhiteSpace(race))
            {
                Console.WriteLine("❌ La raza no puede estar vacía. Operación cancelada. Presione Enter para continuar...");
                Console.ReadLine();
                return;
            }

            // --- Registro ---
            _managementService.RegisterPet(name, age, specie, race, ownerId);
            Console.WriteLine("✅ Mascota registrada con éxito. Presione Enter para continuar...");
            Console.ReadLine();
        }



        private void ShowAllPets()
        {
            var pets = _managementService.GetAllPets();
            if (pets == null || !pets.Any())
            {
                Console.WriteLine("⚠️ No hay mascotas registradas en el sistema.");
            }
            else
            {
                Console.WriteLine("📋 Lista de mascotass registrados:\n");
                foreach (var pet in pets)
                {
                    Console.WriteLine($"Nombre: {pet.Name}, Especie: {pet.Specie}, Raza: {pet.Race}, Id: {pet.Id}");
                }
            }
            Console.WriteLine("Presione cualquier tecla para volver al menú.");
            Console.ReadKey();
        }

        private void UpdatePet()
        {
            // --- ID de la mascota ---
            Console.WriteLine("Ingrese el ID de la mascota a actualizar:");
            string? idInput = Console.ReadLine()?.Trim();
            if (string.IsNullOrWhiteSpace(idInput) || !int.TryParse(idInput, out int petId) || petId <= 0)
            {
                Console.WriteLine("❌ ID inválido. Operación cancelada. Presione Enter para continuar...");
                Console.ReadLine();
                return;
            }

            // --- Validar si la mascota existe ---
            if (!_managementService.PetExists(petId))
            {
                Console.WriteLine($"⚠️ No existe ninguna mascota con el ID {petId}. Operación cancelada. Presione Enter para continuar...");
                Console.ReadLine();
                return;
            }

            // --- Nombre ---
            Console.WriteLine("Ingrese el nuevo nombre de la mascota:");
            string? name = Console.ReadLine()?.Trim();
            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("❌ El nombre no puede estar vacío. Operación cancelada. Presione Enter para continuar...");
                Console.ReadLine();
                return;
            }

            // --- Edad ---
            Console.WriteLine("Ingrese la nueva edad de la mascota:");
            string? ageInput = Console.ReadLine()?.Trim();
            if (string.IsNullOrWhiteSpace(ageInput) || !int.TryParse(ageInput, out int age) || age < 0 || age > 50)
            {
                Console.WriteLine("❌ Edad inválida. Debe ser un número entre 0 y 50. Operación cancelada. Presione Enter para continuar...");
                Console.ReadLine();
                return;
            }

            // --- Especie ---
            Console.WriteLine("Ingrese la nueva especie de la mascota:");
            string? specie = Console.ReadLine()?.Trim();
            if (string.IsNullOrWhiteSpace(specie))
            {
                Console.WriteLine("❌ La especie no puede estar vacía. Operación cancelada. Presione Enter para continuar...");
                Console.ReadLine();
                return;
            }

            // --- Raza ---
            Console.WriteLine("Ingrese la nueva raza de la mascota:");
            string? race = Console.ReadLine()?.Trim();
            if (string.IsNullOrWhiteSpace(race))
            {
                Console.WriteLine("❌ La raza no puede estar vacía. Operación cancelada. Presione Enter para continuar...");
                Console.ReadLine();
                return;
            }

            // --- ID del dueño ---
            Console.WriteLine("Ingrese el ID del dueño de la mascota:");
            string? ownerIdInput = Console.ReadLine()?.Trim();
            if (string.IsNullOrWhiteSpace(ownerIdInput) || !int.TryParse(ownerIdInput, out int ownerId) || ownerId <= 0)
            {
                Console.WriteLine("❌ ID de dueño inválido. Operación cancelada. Presione Enter para continuar...");
                Console.ReadLine();
                return;
            }

            // ✅ Verificar si el dueño existe
            if (!_managementService.CustomerExists(ownerId))
            {
                Console.WriteLine($"⚠️ No existe ningún cliente con el ID {ownerId}. Operación cancelada. Presione Enter para continuar...");
                Console.ReadLine();
                return;
            }

            // --- Actualización ---
            var updatedPet = new Pet(name, age, specie, race, ownerId)
            {
                Id = petId // 👈 importante: mantener el ID original de la mascota
            };

            _managementService.UpdatePet(updatedPet);
            Console.WriteLine("✅ Mascota actualizada con éxito. Presione Enter para continuar...");
            Console.ReadLine();
        }



        private void DeletePet()
        {
            Console.WriteLine("Ingrese el ID de la mascota a eliminar:");
            string? idInput = Console.ReadLine()?.Trim();

            // --- Validar ID ---
            if (string.IsNullOrWhiteSpace(idInput) || !int.TryParse(idInput, out int petId) || petId <= 0)
            {
                Console.WriteLine("❌ ID inválido. Debe ser un número entero positivo. Operación cancelada.");
                Console.WriteLine("Presione Enter para continuar...");
                Console.ReadLine();
                return;
            }

            // --- Validar si la mascota existe ---
            if (!_managementService.PetExists(petId))
            {
                Console.WriteLine($"⚠️ No existe ninguna mascota con el ID {petId}. Operación cancelada.");
                Console.WriteLine("Presione Enter para continuar...");
                Console.ReadLine();
                return;
            }

            // --- Confirmación antes de eliminar ---
            Console.WriteLine($"¿Está seguro de que desea eliminar la mascota con ID {petId}? (S/N)");
            string? confirm = Console.ReadLine()?.Trim().ToUpper();

            if (confirm != "S")
            {
                Console.WriteLine("❎ Operación cancelada por el usuario.");
                Console.WriteLine("Presione Enter para continuar...");
                Console.ReadLine();
                return;
            }

            // --- Eliminación ---
            _managementService.DeletePet(petId);
            Console.WriteLine("✅ Mascota eliminada con éxito.");
            Console.WriteLine("Presione Enter para continuar...");
            Console.ReadLine();
        }



        private void RegisterVeterinarian()
        {
            Console.WriteLine("Ingrese el nombre del veterinario:");
            string? name = Console.ReadLine()?.Trim();

            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("❌ El nombre no puede estar vacío. Operación cancelada.");
                Console.WriteLine("Presione Enter para continuar...");
                Console.ReadLine();
                return;
            }

            Console.WriteLine("Ingrese la especialidad del veterinario:");
            string? specialty = Console.ReadLine()?.Trim();

            if (string.IsNullOrWhiteSpace(specialty))
            {
                Console.WriteLine("❌ La especialidad no puede estar vacía. Operación cancelada.");
                Console.WriteLine("Presione Enter para continuar...");
                Console.ReadLine();
                return;
            }

            _managementService.RegisterVeterinarian(name, specialty);
            Console.WriteLine("✅ Veterinario registrado con éxito.");
            Console.WriteLine("Presione Enter para continuar...");
            Console.ReadLine();
        }


        private void ShowAllVeterinarians()
        {
            var vets = _managementService.GetAllVeterinarians();

            if (vets == null || !vets.Any())
            {
                Console.WriteLine("⚠️ No hay veterinarios registrados actualmente.");
                Console.WriteLine("Presione Enter para continuar...");
                Console.ReadLine();
                return;
            }

            Console.WriteLine("\n📋 Lista de Veterinarios Registrados:");
            foreach (var vet in vets)
            {
                Console.WriteLine($"ID: {vet.Id} | Nombre: {vet.Name} | Especialidad: {vet.Specialty}");
            }

            Console.WriteLine("\nPresione cualquier tecla para volver al menú...");
            Console.ReadKey();
        }

        private void UpdateVeterinarian()
        {
            Console.WriteLine("Ingrese el ID del veterinario a actualizar:");
            string? idInput = Console.ReadLine()?.Trim();

            if (string.IsNullOrWhiteSpace(idInput) || !int.TryParse(idInput, out int id) || id <= 0)
            {
                Console.WriteLine("❌ ID inválido. Debe ser un número entero positivo. Operación cancelada.");
                Console.WriteLine("Presione Enter para continuar...");
                Console.ReadLine();
                return;
            }

            // Verificar si el veterinario existe
            if (!_managementService.VeterinarianExists(id))
            {
                Console.WriteLine($"⚠️ No existe ningún veterinario con el ID {id}. Operación cancelada.");
                Console.WriteLine("Presione Enter para continuar...");
                Console.ReadLine();
                return;
            }

            Console.WriteLine("Ingrese el nuevo nombre del veterinario:");
            string? name = Console.ReadLine()?.Trim();

            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("❌ El nombre no puede estar vacío. Operación cancelada.");
                Console.WriteLine("Presione Enter para continuar...");
                Console.ReadLine();
                return;
            }

            Console.WriteLine("Ingrese la nueva especialidad del veterinario:");
            string? specialty = Console.ReadLine()?.Trim();

            if (string.IsNullOrWhiteSpace(specialty))
            {
                Console.WriteLine("❌ La especialidad no puede estar vacía. Operación cancelada.");
                Console.WriteLine("Presione Enter para continuar...");
                Console.ReadLine();
                return;
            }

            // Crear objeto actualizado
            var updatedVet = new Veterinarian(id, name, specialty);

            _managementService.UpdateVeterinarian(updatedVet);
            Console.WriteLine("✅ Veterinario actualizado con éxito.");
            Console.WriteLine("Presione Enter para continuar...");
            Console.ReadLine();
        }


        private void DeleteVeterinarian()
        {
            Console.WriteLine("Ingrese el ID del veterinario a eliminar:");
            string? idInput = Console.ReadLine()?.Trim();

            if (string.IsNullOrWhiteSpace(idInput) || !int.TryParse(idInput, out int id) || id <= 0)
            {
                Console.WriteLine("❌ ID inválido. Debe ser un número entero positivo. Operación cancelada.");
                Console.WriteLine("Presione Enter para continuar...");
                Console.ReadLine();
                return;
            }

            // Verificar existencia del veterinario
            if (!_managementService.VeterinarianExists(id))
            {
                Console.WriteLine($"⚠️ No existe ningún veterinario con el ID {id}. Operación cancelada.");
                Console.WriteLine("Presione Enter para continuar...");
                Console.ReadLine();
                return;
            }

            // Mostrar detalles antes de eliminar (opcional)
            var vet = _managementService.GetVeterinarianById(id);
            Console.WriteLine($"Veterinario encontrado: {vet.Name} ({vet.Specialty})");
            Console.WriteLine($"¿Está seguro de que desea eliminar al veterinario con ID {id}? (S/N)");
            string? confirm = Console.ReadLine()?.Trim().ToUpper();

            if (confirm != "S")
            {
                Console.WriteLine("❎ Operación cancelada por el usuario.");
                Console.WriteLine("Presione Enter para continuar...");
                Console.ReadLine();
                return;
            }

            _managementService.DeleteVeterinarian(id);
            Console.WriteLine("✅ Veterinario eliminado con éxito.");
            Console.WriteLine("Presione Enter para continuar...");
            Console.ReadLine();
        }



        private void ScheduleAppointment()
        {
            Console.WriteLine("Ingrese el ID de la cita:");
            string? idInput = Console.ReadLine();

            if (!int.TryParse(idInput, out int id))
            {
                Console.WriteLine("❌ El ID de la cita no es válido. Operación cancelada.");
                Console.WriteLine("Presione Enter para continuar...");
                Console.ReadLine();
                return;
            }

            Console.WriteLine("Ingrese el ID del cliente:");
            string? customerInput = Console.ReadLine();

            if (!int.TryParse(customerInput, out int customerId))
            {
                Console.WriteLine("❌ El ID del cliente no es válido. Operación cancelada.");
                Console.WriteLine("Presione Enter para continuar...");
                Console.ReadLine();
                return;
            }

            Console.WriteLine("Ingrese la fecha de la cita (formato: dd/MM/yyyy HH:mm):");
            string? dateInput = Console.ReadLine();

            if (!DateTime.TryParseExact(dateInput, "dd/MM/yyyy HH:mm", null, System.Globalization.DateTimeStyles.None, out DateTime date))
            {
                Console.WriteLine("❌ Fecha inválida. Use el formato dd/MM/yyyy HH:mm. Ejemplo: 13/10/2025 14:30");
                Console.WriteLine("Presione Enter para continuar...");
                Console.ReadLine();
                return;
            }

            Console.WriteLine("Ingrese una descripción para la cita:");
            string? description = Console.ReadLine()?.Trim();

            if (string.IsNullOrWhiteSpace(description))
            {
                Console.WriteLine("❌ La descripción no puede estar vacía. Operación cancelada.");
                Console.ReadLine();
                return;
            }

            Console.WriteLine("Ingrese el ID del veterinario:");
            string? vetInput = Console.ReadLine();

            if (!int.TryParse(vetInput, out int vetId))
            {
                Console.WriteLine("❌ El ID del veterinario no es válido. Operación cancelada.");
                Console.WriteLine("Presione Enter para continuar...");
                Console.ReadLine();
                return;
            }

            // Confirmación opcional
            Console.WriteLine($"\n📅 Confirme los datos de la cita:");
            Console.WriteLine($"   ID: {id}");
            Console.WriteLine($"   Cliente ID: {customerId}");
            Console.WriteLine($"   Veterinario ID: {vetId}");
            Console.WriteLine($"   Fecha: {date:dd/MM/yyyy HH:mm}");
            Console.WriteLine($"   Descripción: {description}");
            Console.WriteLine("¿Desea agendar esta cita? (s/n)");

            string? confirm = Console.ReadLine()?.Trim().ToLower();
            if (confirm != "s")
            {
                Console.WriteLine("Operación cancelada por el usuario.");
                Console.ReadLine();
                return;
            }

            // Llamada al servicio
            _managementService.ScheduleAppointment(id, customerId, date, description, vetId);

            Console.WriteLine("\n✅ Cita agendada con éxito.");
            Console.WriteLine("Presione Enter para continuar...");
            Console.ReadLine();
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
            string? idInput = Console.ReadLine();

            // Validar ID
            if (!int.TryParse(idInput, out int id))
            {
                Console.WriteLine("❌ El ID ingresado no es válido. Operación cancelada.");
                Console.WriteLine("Presione Enter para continuar...");
                Console.ReadLine();
                return;
            }

            // Verificar si la cita existe
            var existingAppointment = _managementService.GetAllAppointments().FirstOrDefault(a => a.Id == id);
            if (existingAppointment == null)
            {
                Console.WriteLine("❌ No existe ninguna cita con ese ID.");
                Console.WriteLine("Presione Enter para continuar...");
                Console.ReadLine();
                return;
            }

            Console.WriteLine("Ingrese el nuevo ID del cliente:");
            string? customerInput = Console.ReadLine();
            if (!int.TryParse(customerInput, out int customerId))
            {
                Console.WriteLine("❌ El ID del cliente no es válido. Operación cancelada.");
                Console.WriteLine("Presione Enter para continuar...");
                Console.ReadLine();
                return;
            }

            Console.WriteLine("Ingrese la nueva fecha de la cita (formato: dd/MM/yyyy HH:mm):");
            string? dateInput = Console.ReadLine();

            if (!DateTime.TryParseExact(dateInput, "dd/MM/yyyy HH:mm", null, System.Globalization.DateTimeStyles.None, out DateTime date))
            {
                Console.WriteLine("❌ Fecha inválida. Use el formato dd/MM/yyyy HH:mm. Ejemplo: 14/10/2025 15:00");
                Console.WriteLine("Presione Enter para continuar...");
                Console.ReadLine();
                return;
            }

            Console.WriteLine("Ingrese la nueva descripción de la cita:");
            string? description = Console.ReadLine()?.Trim();

            if (string.IsNullOrWhiteSpace(description))
            {
                Console.WriteLine("❌ La descripción no puede estar vacía. Operación cancelada.");
                Console.ReadLine();
                return;
            }

            Console.WriteLine("Ingrese el nuevo ID del veterinario:");
            string? vetInput = Console.ReadLine();

            if (!int.TryParse(vetInput, out int vetId))
            {
                Console.WriteLine("❌ El ID del veterinario no es válido. Operación cancelada.");
                Console.WriteLine("Presione Enter para continuar...");
                Console.ReadLine();
                return;
            }

            // Obtener veterinario desde el servicio (por si queremos validar que exista)
            var veterinarian = _managementService.GetAllVeterinarians().FirstOrDefault(v => v.Id == vetId);
            if (veterinarian == null)
            {
                Console.WriteLine("❌ No existe ningún veterinario con ese ID. Operación cancelada.");
                Console.ReadLine();
                return;
            }

            var updatedAppointment = new Appointment(id, customerId, date, description, veterinarian);

            _managementService.UpdateAppointment(updatedAppointment);

            Console.WriteLine("✅ Cita actualizada con éxito.");
            Console.WriteLine("Presione Enter para continuar...");
            Console.ReadLine();
        }



        private void DeleteAppointment()
        {
            Console.WriteLine("Ingrese el ID de la cita a eliminar:");
            string? input = Console.ReadLine();

            if (!int.TryParse(input, out int id))
            {
                Console.WriteLine("❌ ID inválido. Operación cancelada.");
                Console.WriteLine("Presione Enter para continuar...");
                Console.ReadLine();
                return;
            }

            // Verificar si la cita existe antes de eliminar
            var existingAppointment = _managementService.GetAllAppointments().FirstOrDefault(a => a.Id == id);
            if (existingAppointment == null)
            {
                Console.WriteLine("❌ No existe ninguna cita con ese ID.");
                Console.WriteLine("Presione Enter para continuar...");
                Console.ReadLine();
                return;
            }

            // Confirmar eliminación
            Console.WriteLine($"⚠️ ¿Está seguro de que desea eliminar la cita con ID {id}? (s/n)");
            string? confirm = Console.ReadLine()?.Trim().ToLower();

            if (confirm != "s")
            {
                Console.WriteLine("Operación cancelada por el usuario.");
                Console.WriteLine("Presione Enter para continuar...");
                Console.ReadLine();
                return;
            }

            _managementService.DeleteAppointment(id);

            Console.WriteLine("✅ Cita eliminada con éxito.");
            Console.WriteLine("Presione Enter para continuar...");
            Console.ReadLine();
        }



    }
}






