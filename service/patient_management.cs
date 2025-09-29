namespace Gestion_clinica.service
{
    public class GestionPaciente
    {
        // Lista de pacientes
        public static List<Patient> patients = new List<Patient>();
        // Diccionario para acceso rápido por ID
        public static Dictionary<int, Patient> patientDict = new Dictionary<int, Patient>();
        public static int nextId = 1;



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
        //Agregar una mascota a un paciente
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

        //Eliminar un paciente
        public static void RemovePatient(int patientId)
        {
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

        //Modificar el nombre de un paciente
        public static void UpdatePatientName(int patientId, string newName)
        {
            if (patientDict.TryGetValue(patientId, out var patient))
            {
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
