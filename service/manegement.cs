using Gestion_clinica.models;
using Gestion_clinica.Interfaces;
namespace Gestion_clinica.service
{
    public class GestionPatient
    {
        // List to store patients
        public static List<Patient> patients = new List<Patient>();
        // Dictionary for quick access by ID
        public static Dictionary<int, Patient> patientDict = new Dictionary<int, Patient>();
        // List to store veterinarians
        public static List<Veterinarian> veterinarians = new List<Veterinarian>();
        public static int nextId = 1;

        // Register a new patient
        public static void RegisterPatient()
        {
            Console.Clear();
            Console.WriteLine("Register Patient");

            try
            {

                string name;
                while (true)
                {
                    Console.Write("Name patient: ");
                    name = Console.ReadLine() ?? string.Empty;
                    if (!string.IsNullOrWhiteSpace(name))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Name cannot be empty. Please enter a valid name.");
                    }
                }

                int age;
                while (true)
                {
                    Console.Write("Age patient: ");
                    var ageInput = Console.ReadLine();
                    if (int.TryParse(ageInput, out age))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid age. Please enter a valid integer.");
                    }
                }

                int phone;
                while (true)
                {
                    Console.Write("Phone patient: ");
                    var phoneInput = Console.ReadLine();
                    if (int.TryParse(phoneInput, out phone))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid phone number. Please enter a valid integer.");
                    }
                }

                string address;
                while (true)
                {
                    Console.Write("Address: ");
                    address = Console.ReadLine() ?? string.Empty;
                    if (!string.IsNullOrWhiteSpace(address))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Address cannot be empty. Please enter a valid address.");
                    }
                }

                var patient = new Patient(nextId++, name, age, phone, address);
                patients.Add(patient);
                patientDict[patient.Id] = patient;
                // Invoca el método Register de la interfaz
                Console.WriteLine("Patient successfully registered. Press Enter to continue....");
                patient.Register(patient);
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                Console.WriteLine("Please try again. Press Enter to continue....");
                Console.ReadKey();
            }
        }

        // View all patients 
        public static void SeePatients()
        {
            Console.Clear();
            Console.WriteLine("Patient List");
            if (patients.Count == 0)
            {
                Console.WriteLine("There are no registered patients.");
            }
            else
            {
                foreach (var patient in patients)
                {
                    Console.WriteLine($"ID: {patient.Id}, Name: {patient.Name}, Age: {patient.Age}");
                    if (patient.Pets.Count > 0)
                    {
                        Console.WriteLine("  Pets:");
                        foreach (var pet in patient.Pets)
                        {
                            Console.WriteLine($"{pet.Name} ({pet.Specie})");
                        }
                    }
                }
            }
            Console.WriteLine("Press Enter to continue...");
            Console.ReadKey();
        }

        // Adding a pet to a patient
        public static void AddPetToPatient()
        {
            Console.Clear();
            Console.WriteLine("Add Pet to Patient");
            int patientId;
            while (true)
            {
                Console.Write("Enter patient ID: ");
                var idInput = Console.ReadLine();
                if (int.TryParse(idInput, out patientId))
                    break;
                else
                    Console.WriteLine("Invalid ID. Please enter a valid integer.");
            }

            if (!patientDict.TryGetValue(patientId, out var patient))
            {
                Console.WriteLine("Patient not found. Press Enter to continue...");
                Console.ReadKey();
                return;
            }

            string petName;
            while (true)
            {
                Console.Write("Pet name: ");
                petName = Console.ReadLine() ?? string.Empty;
                if (!string.IsNullOrWhiteSpace(petName))
                    break;
                else
                    Console.WriteLine("Pet name cannot be empty.");
            }

            int petAge;
            while (true)
            {
                Console.Write("Pet age: ");
                var petAgeInput = Console.ReadLine();
                if (int.TryParse(petAgeInput, out petAge))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid age. Please enter a valid integer.");
                }
            }

            string petSpecie;
            while (true)
            {
                Console.Write("Pet specie: ");
                petSpecie = Console.ReadLine() ?? string.Empty;
                if (!string.IsNullOrWhiteSpace(petSpecie))
                    break;
                else
                    Console.WriteLine("Pet specie cannot be empty.");
            }

            string petRace;
            while (true)
            {
                Console.Write("Pet race: ");
                petRace = Console.ReadLine() ?? string.Empty;
                if (!string.IsNullOrWhiteSpace(petRace))
                    break;
                else
                    Console.WriteLine("Pet race cannot be empty.");
            }

            string petOwner;
            while (true)
            {
                Console.Write("Pet owner: ");
                petOwner = Console.ReadLine() ?? string.Empty;
                if (!string.IsNullOrWhiteSpace(petOwner))
                    break;
                else
                    Console.WriteLine("Pet owner cannot be empty.");
            }

            var pet = new Pet(petName, petAge, petSpecie, petRace, petOwner);
            patient.Pets.Add(pet);
            // Invokes the Register method of the interface
            Console.WriteLine("Sound:");
            pet.MakeSound();
            Console.WriteLine($"Pet '{petName}' added to patient {patient.Name}.");
            pet.Register(pet);
            Console.WriteLine("Press Enter to continue...");
            Console.ReadKey();
        }

        // Delete a patient
        public static void RemovePatient()
        {
            Console.Clear();
            Console.WriteLine("RemovePatient");
            int patientId;
            while (true)
            {
                Console.Write("Enter patient ID: ");
                var idInput = Console.ReadLine();
                if (int.TryParse(idInput, out patientId))
                    break;
                else
                    Console.WriteLine("Invalid ID. Please enter a valid integer.");
            }
            if (patientDict.TryGetValue(patientId, out var patient))
            {
                patients.Remove(patient);
                patientDict.Remove(patientId);
                Console.WriteLine($"Patient with ID {patientId} removed.");
            }
            else
            {
                Console.WriteLine("Patient not found.");
            }
        }

        // Modify a patient name
        public static void UpdatePatientName(string newName = "Updated Name")
        {
            Console.Clear();
            Console.WriteLine("Name Patient Update");
            int patientId;
            while (true)
            {
                Console.Write("Enter patient ID: ");
                var idInput = Console.ReadLine();
                if (int.TryParse(idInput, out patientId))
                    break;
                else
                    Console.WriteLine("Invalid ID. Please enter a valid integer.");
            }
            if (patientDict.TryGetValue(patientId, out var patient))
            {
                Console.WriteLine("enter the new name:");
                newName = Console.ReadLine() ?? string.Empty;
                if (string.IsNullOrWhiteSpace(newName))
                {
                    Console.WriteLine("Name cannot be empty. Press Enter to continue...");
                    Console.ReadKey();
                    return;
                }
                patient.Name = newName;
                Console.WriteLine($"Patient name updated to {newName}.");
            }
            else
            {
                Console.WriteLine("Patient not found.");
            }
            Console.WriteLine("Press Enter to continue...");
            Console.ReadKey();
        }

        // Search for a patient by name
        public static void SearhPatient()
        {
            Console.Clear();
            Console.WriteLine("Search Paciente");
            Console.Write("enter the patient's name: ");

            var name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Name cannot be empty. Press Enter to continue...");
                Console.ReadKey();
                return;
            }
            var found = patients.Where(p => p.Name != null && p.Name.IndexOf(name, StringComparison.OrdinalIgnoreCase) >= 0).ToList();

            if (found.Count == 0)
            {
                Console.WriteLine("No patients with that name were found..");
            }
            else
            {
                foreach (var patient in found)
                {
                    Console.WriteLine($"ID: {patient.Id}, Name: {patient.Name}, Age: {patient.Age}, Pets: {patient.Pets.Count}");
                }
            }
            Console.WriteLine("Press Enter to continue...");
            Console.ReadKey();
        }

        // schedule appointment
        public static void ScheduleAppointment()
        {
            Console.Clear();
            Console.WriteLine("Schedule appointment for patient");
            Console.Write("Enter patient ID: ");
            var idInput = Console.ReadLine();
            if (!int.TryParse(idInput, out int patientId))
            {
                Console.WriteLine("Invalid ID. Press Enter to continue...");
                Console.ReadKey();
                return;
            }
            if (!patientDict.TryGetValue(patientId, out var patient))
            {
                Console.WriteLine("Patient not found. Press Enter to continue...");
                Console.ReadKey();
                return;
            }
            Console.Write("Enter the date and time of the appointment (format: dd/MM/yyyy HH:mm): ");
            var fechaInput = Console.ReadLine();
            if (!DateTime.TryParseExact(fechaInput, "dd/MM/yyyy HH:mm", null, System.Globalization.DateTimeStyles.None, out DateTime fecha))
            {
                Console.WriteLine("Invalid date. Press Enter to continue...");
                Console.ReadKey();
                return;
            }
            // Ask for veterinarian to assign
            Veterinarian? selectedVet = null;
            if (veterinarians.Count == 0)
            {
                Console.WriteLine("No veterinarians registered. The appointment will be created without a veterinarian.");
            }
            else
            {
                Console.WriteLine("Available veterinarians:");
                foreach (var vet in veterinarians)
                {
                    Console.WriteLine($"ID: {vet.Id}, Name: {vet.Name}, Specialty: {vet.Specialty}");
                }

                while (true)
                {
                    Console.Write("Enter veterinarian ID to assign (or press Enter to leave unassigned): ");
                    var vetInput = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(vetInput))
                    {
                        // leave unassigned
                        break;
                    }
                    if (!int.TryParse(vetInput, out int vetId))
                    {
                        Console.WriteLine("Invalid ID. Please enter a valid integer or press Enter to skip.");
                        continue;
                    }
                    selectedVet = veterinarians.FirstOrDefault(v => v.Id == vetId);
                    if (selectedVet == null)
                    {
                        Console.WriteLine("No veterinarian found with that ID. Try again or press Enter to skip.");
                        continue;
                    }
                    break;
                }
            }

            // Create appointment and associate veterinarian if provided
            Appointment appointment;
            if (selectedVet != null)
            {
                appointment = new Appointment(patient.Appointments.Count + 1, patient.Id, fecha, "Consulta médica", selectedVet);
            }
            else
            {
                appointment = new Appointment(patient.Appointments.Count + 1, patient.Id, fecha, "Consulta médica", "Doctor asignado");
            }
            patient.AddAppointment(appointment);
            Console.WriteLine("Press Enter to continue...");
            Console.ReadKey();
        }
        // Show appointments by patient ID
        public static void ShowAppointmentsByPatientId()
        {
            Console.Clear();
            Console.WriteLine("Show appointments of a patient by ID");
            Console.Write("Enter patient ID: ");
            var input = Console.ReadLine();
            if (!int.TryParse(input, out int patientId))
            {
                Console.WriteLine("Invalid ID. Press Enter to continue...");
                Console.ReadKey();
                return;
            }
            if (!patientDict.TryGetValue(patientId, out var patient))
            {
                Console.WriteLine("Patient not found. Press Enter to continue...");
                Console.ReadKey();
                return;
            }
            if (patient.Appointments == null || patient.Appointments.Count == 0)
            {
                Console.WriteLine("The patient has no registered appointments.");
            }
            else
            {
                Console.WriteLine($"Appointments for {patient.Name}:");
                foreach (var appointment in patient.Appointments)
                {
                    Console.WriteLine(appointment.ToString());
                    patient.EnviarNotificacion($"Reminder for {appointment.Date:dd/MM/yyyy HH:mm}");
                }
            }
            Console.WriteLine("Press Enter to continue..");
            Console.ReadKey();
        }

        // register a veterinarian
        public static void RegisterVeterinarian()
        {
            Console.Clear();
            Console.WriteLine("Register Veterinarian");
            Console.Write("Enter ID: ");
            var idInput = Console.ReadLine();
            if (!int.TryParse(idInput, out int id))
            {
                Console.WriteLine("Invalid ID. Press Enter to continue...");
                Console.ReadKey();
                return;
            }

            if (id <= 0)
            {
                Console.WriteLine("ID must be a positive integer. Press Enter to continue...");
                Console.ReadKey();
                return;
            }

            if (veterinarians.Any(v => v.Id == id))
            {
                Console.WriteLine("A veterinarian with that ID already exists. Press Enter to continue...");
                Console.ReadKey();
                return;
            }

            Console.Write("Enter Name: ");
            var name = Console.ReadLine();
            Console.Write("Enter Specialty: ");
            var specialty = Console.ReadLine();
            var veterinarian = new Veterinarian(id, name, specialty);
            veterinarians.Add(veterinarian);
            veterinarian.Register(veterinarian);
            Console.WriteLine("Press Enter to continue...");
            Console.ReadKey();
        }


        public static void SeeVeterinarians()
        {
        
            Console.Clear();
            Console.WriteLine("Veterinarians List");
            if (veterinarians.Count == 0)
            {
                Console.WriteLine("There are no registered veterinarians.");
            }
            else
            {
                foreach (var veterinarian in veterinarians)
                {
                    Console.WriteLine($"ID: {veterinarian.Id}, Name: {veterinarian.Name}, Specialty: {veterinarian.Specialty}");
                }
            }
            Console.WriteLine("Press Enter to continue...");
            Console.ReadKey();
        }

        public static void ViewPetVaccinationHistory()
        {
            Console.Clear();
            Console.WriteLine("View Pet Vaccination History");
            Console.Write("Enter pet name: ");
            string petName = Console.ReadLine()?.Trim() ?? string.Empty;

            var foundPet = patients
                .SelectMany(p => p.Pets)
                .FirstOrDefault(pet => pet.Name.Equals(petName, StringComparison.OrdinalIgnoreCase));

            if (foundPet != null)
            {
                foundPet.ShowVaccinationHistory();
            }
            else
            {
                Console.WriteLine($"Pet '{petName}' not found.");
            }

            Console.WriteLine("Press Enter to continue...");
            Console.ReadKey();
        }
    }
}

