using Gestion_clinica.models;
using Gestion_clinica.Interfaces;
namespace Gestion_clinica.service
{
    public class GestionPaciente
    {
        // Método para agendar cita a un paciente

        // List to store patients
        public static List<Patient> patients = new List<Patient>();
        // Dictionary for quick access by ID
        public static Dictionary<int, Patient> patientDict = new Dictionary<int, Patient>();
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
            // Invoca el método Register de la interfaz
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
            patient.ScheduleAppointmentt(fecha);
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
    }
}
