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

        Console.Write("Name patient: ");
        var name = Console.ReadLine();

        Console.Write("Age patient: ");
        var age = Convert.ToInt32(Console.ReadLine());

        Console.Write("Symptom: ");
        var symptom = Console.ReadLine();

        var patient = new Patient(nextId++, name, age, symptom);
        patients.Add(patient);
        Console.WriteLine("Patient successfully registered. Press Enter to continue....");
        Console.ReadKey();
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

            var found = patients.Where(p => p.Name.IndexOf(name, StringComparison.OrdinalIgnoreCase) >= 0).ToList();

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