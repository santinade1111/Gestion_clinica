namespace Gestion_clinica.service
{
    public class GestionPaciente
    {
        // Lista de pacientes
        public static List<Patient> patients = new List<Patient>();
        // Diccionario para acceso rápido por ID
        public static Dictionary<int, Patient> patientDict = new Dictionary<int, Patient>();
        public static int nextId = 1;

        // Agrupar pacientes por especie de mascota
        public static void GroupPatientsByPetSpecies()
        {
            Console.Clear();
            var grupos = patients
                .SelectMany(p => p.Pets, (p, pet) => new { Paciente = p, Especie = pet.Species })
                .GroupBy(x => x.Especie);

            if (!grupos.Any())
            {
                Console.WriteLine("No patients with pets found.");
            }
            else
            {
                foreach (var grupo in grupos)
                {
                    Console.WriteLine($"Especie: {grupo.Key}");
                    foreach (var x in grupo)
                    {
                        Console.WriteLine($"  Paciente: {x.Paciente.Name} (ID: {x.Paciente.Id})");
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

                var patient = new Patient(nextId++, name, age, symptom);
                patients.Add(patient);
                patientDict[patient.Id] = patient;
                Console.WriteLine("Patient successfully registered. Press Enter to continue....");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                Console.WriteLine("Please try again. Press Enter to continue....");
                Console.ReadKey();
            }
        }

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
                            Console.WriteLine($"    - {pet.Name} ({pet.Species})");
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

            string petSpecies;
            while (true)
            {
                Console.Write("Pet species: ");
                petSpecies = Console.ReadLine() ?? string.Empty;
                if (!string.IsNullOrWhiteSpace(petSpecies))
                    break;
                else
                    Console.WriteLine("Pet species cannot be empty.");
            }

            patient.Pets.Add(new Pet(petName, petSpecies));
            Console.WriteLine($"Pet '{petName}' added to patient {patient.Name}. Press Enter to continue...");
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
