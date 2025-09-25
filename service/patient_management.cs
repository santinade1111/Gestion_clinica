namespace Gestion_clinica.service
{
    public class GestionPaciente
    {
        public static List<Patient> patients = new List<Patient>();
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
            }
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
                    Console.WriteLine($"ID: {patient.Id}, Name: {patient.Name}, Age: {patient.Age}, Symptom: {patient.Symptom}");
                }
            }
            Console.WriteLine("Press Enter to continue...");
            Console.ReadKey();
        }
    }
}