using System;
using Gestion_clinica.service;
class Menus
{
    public static void Menu()
    {
        // Main menu loop
        while (true)
        {
            Console.Clear();
            Console.WriteLine("clinical management");
            Console.WriteLine("1. Register Patient");
            Console.WriteLine("2. See Patients");
            Console.WriteLine("3. Searh Patient");
            Console.WriteLine("4. Add Pet to Patient");
            Console.WriteLine("5. Remove Patient");
            Console.WriteLine("6. Update Patient Name");
            Console.WriteLine("7. go out");
            Console.Write("Select an option: ");
            var opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    GestionPaciente.RegisterPatient();
                    break;
                case "2":
                    GestionPaciente.SeePatients();
                    break;
                case "3":
                    GestionPaciente.SearhPatient();
                    break;
                case "4":
                    GestionPaciente.AddPetToPatient();
                    break;
                case "5":
                    GestionPaciente.RemovePatient();
                    break;
                case "6":
                    GestionPaciente.UpdatePatientName();
                    break;   
                case "7":
                    return;
                default:
                    Console.WriteLine("Invalid option. Press Enter to continue....");
                    Console.ReadLine();
                    break;
            }
        }
    }
}







