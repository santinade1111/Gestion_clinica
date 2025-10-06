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
            Console.WriteLine("1.Patient");
            Console.WriteLine("2.Pets");
            Console.WriteLine("3.General Consultation");
            Console.WriteLine("4.go out");
            Console.Write("Select an option: ");
            var opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    PatientMenu();
                    break;
                case "2":
                    PetsMenu();
                    break;
                case "3":
                    GeneralConsultation.GeneralConsultationMethod();
                    break; 
                case "4":
                    return;
                default:
                    Console.WriteLine("Invalid option. Press Enter to continue....");
                    Console.ReadLine();
                    break;
            }
        }
    }

    public static void PatientMenu()
    {
        while(true)
        {
            Console.WriteLine("1. Register Patient");
            Console.WriteLine("2. See patients");
            Console.WriteLine("3. Search patient");
            Console.WriteLine("4. Remove Patient");
            Console.WriteLine("5. go out");
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
                    GestionPaciente.RemovePatient();
                    break;  
                case "5":
                    return;   
                default:
                    Console.WriteLine("Invalid option. Press Enter to continue....");
                    Console.ReadLine();
                    break;       
            }
        }
    }

    public static void PetsMenu()
    {
        while(true)
        {
            Console.WriteLine("1. Add Pet to Patient");
            Console.WriteLine("2. salir");
            Console.Write("Select an option: ");
            var opcion = Console.ReadLine();

            switch(opcion)
            {
                case "1":
                    GestionPaciente.AddPetToPatient();
                    break;  
                case "2":
                    return;   
                default:
                    Console.WriteLine("Invalid option. Press Enter to continue....");
                    Console.ReadLine();
                    break;
            }
        }
    }
}







