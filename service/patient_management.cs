using Gestion_clinica.models;
using Gestion_clinica.Interfaces;
namespace Gestion_clinica.service
{
    public class GestionPaciente
    {
        // List to store patients
        public static List<Patient> patients = new List<Patient>();
        // Dictionary for quick access by ID
        public static Dictionary<int, Patient> patientDict = new Dictionary<int, Patient>();
        public static int nextId = 1;

        // List patient names in uppercase and sorted
        public static void ListPatientNamesUppercaseSorted()
        {
            Console.Clear();
            var names = patients.Select(p => p.Name.ToUpper()).OrderBy(n => n).ToList();
            if (names.Count == 0)
            {
                Console.WriteLine("There are no registered patients.");
            }
            else
            {
                Console.WriteLine("Patient names in uppercase, sorted:");
                foreach (var name in names)
                {
                    Console.WriteLine(name);
                }
            }
            Console.WriteLine("Press Enter to continue...");
            Console.ReadKey();
        }

        // Check if any patient has a pet without a defined species
        public static void CheckPatientWithPetWithoutSpecies()
        {
            Console.Clear();
            bool exist = patients.Any(p => p.Pets.Any(pet => string.IsNullOrWhiteSpace(pet.Specie)));
            if (exist)
                Console.WriteLine("There is at least one patient with a pet of undefined species.");
            else
                Console.WriteLine("There are no patients with pets without a defined species.");
            Console.WriteLine("Press Enter to continue...");
            Console.ReadKey();
        }

        // Count pets by species
        public static void CountPetsBySpecies()
        {
            Console.Clear();
            var conteo = patients
                .SelectMany(p => p.Pets)
                .GroupBy(pet => pet.Specie)
                .Select(g => new { Specie = g.Key, Amount = g.Count() });

            if (!conteo.Any())
            {
                Console.WriteLine("No pets found.");
            }
            else
            {
                Console.WriteLine("number of pets by species:");
                foreach (var c in conteo)
                {
                    Console.WriteLine($"{c.Specie}: {c.Amount}");
                }
            }
            Console.WriteLine("Press Enter to continue...");
            Console.ReadKey();
        }

        // Show the youngest patient
        public static void ShowYoungestPatient()
        {
            Console.Clear();
            var patientYoungest = patients.OrderBy(p => p.Age).FirstOrDefault();
            if (patientYoungest == null)
            {
                Console.WriteLine("No patients found.");
            }
            else
            {
                Console.WriteLine($"Patient youngest: ID: {patientYoungest.Id}, Name: {patientYoungest.Name}, Age: {patientYoungest.Age}, Phone: {patientYoungest.Phone}");
            }
            Console.WriteLine("Press Enter to continue...");
            Console.ReadKey();
        }

        // Show patients with dogs ordered by age
        public static void ShowDogOwnersOrderedByAge()
        {
            Console.Clear();
            var resultado = patients
                .Where(p => p.Pets.Any(m => m.Specie.Equals("Dog", StringComparison.OrdinalIgnoreCase)))
                .OrderBy(p => p.Age)
                .Select(p => new { p.Name, p.Phone });

            Console.WriteLine("Pet owners sorted by age:");
            foreach (var r in resultado)
            {
                Console.WriteLine($"Name: {r.Name}, Phone: {r.Phone}");
            }
            Console.WriteLine("Press Enter to continue...");
            Console.ReadKey();
        }

        // Group patients by pet species
        public static void GroupPatientsByPetSpecies()
        {
            Console.Clear();
            var grupos = patients
                .SelectMany(p => p.Pets, (p, pet) => new { Patient = p, Species = pet.Specie })
                .GroupBy(x => x.Species);

            if (!grupos.Any())
            {
                Console.WriteLine("No patients with pets found.");
            }
            else
            {
                foreach (var grupo in grupos)
                {
                    Console.WriteLine($"species: {grupo.Key}");
                    foreach (var x in grupo)
                    {
                        Console.WriteLine($"  Patient: {x.Patient.Name} (ID: {x.Patient.Id})");
                    }
                }
            }
            Console.WriteLine("Press Enter to continue...");
            Console.ReadKey();
        }

        // Order patients by name
        public static void OrderPatientsByName(bool descending = false)
        {
            var ordered = descending ? patients.OrderByDescending(p => p.Name).ToList() : patients.OrderBy(p => p.Name).ToList();
            Console.Clear();
            Console.WriteLine(descending ? "Patients ordered by name (descending):" : "Patients ordered by name (ascending):");
            foreach (var patient in ordered)
                Console.WriteLine($"ID: {patient.Id}, Name: {patient.Name}, Age: {patient.Age}, Symptom: {patient.Symptom}");
            Console.WriteLine("Press Enter to continue...");
            Console.ReadKey();
        }

        // Filter patients by minimum age
        public static void FilterPatientsByAge(int minAge)
        {
            var filtered = patients.Where(p => p.Age >= minAge).ToList();
            Console.Clear();
            if (filtered.Count == 0)
                Console.WriteLine("No patients found.");
            else
                foreach (var patient in filtered)
                    Console.WriteLine($"ID: {patient.Id}, Name: {patient.Name}, Age: {patient.Age}, Symptom: {patient.Symptom}");
            Console.WriteLine("Press Enter to continue...");
            Console.ReadKey();
        }

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


                string symptom;
                while (true)
                {
                    Console.Write("Symptom: ");
                    symptom = Console.ReadLine() ?? string.Empty;
                    if (!string.IsNullOrWhiteSpace(symptom))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Symptom cannot be empty. Please enter a valid symptom.");
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

                var patient = new Patient(nextId++, name, age, symptom, phone, address);
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
                    Console.WriteLine($"ID: {patient.Id}, Name: {patient.Name}, Age: {patient.Age}, Symptom: {patient.Symptom}");
                    if (patient.Pets.Count > 0)
                    {
                        Console.WriteLine("  Pets:");
                        foreach (var pet in patient.Pets)
                        {
                            Console.WriteLine($"    - {pet.Name} ({pet.Specie})");
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
                    Console.WriteLine($"ID: {patient.Id}, Name: {patient.Name}, Age: {patient.Age}, Symptom: {patient.Symptom}, Pets: {patient.Pets.Count}");
                }
            }
            Console.WriteLine("Press Enter to continue...");
            Console.ReadKey();
        }
    }
}
