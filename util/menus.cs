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
            Console.WriteLine(" ---- CLINICAL MANAGEMENT ---");
            Console.WriteLine("1. Patient Consultation");
            Console.WriteLine("2. Pets Consultation");
            Console.WriteLine("3. General Consultation");
            Console.WriteLine("4. Veterinarian Management");
            Console.WriteLine("5. Exit");
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
                    GeneralConsultationMenu();
                    break;
                case "4":
                    VeterinarianMenu();
                    break;
                 case "5" :
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
        while (true)
        {
            Console.WriteLine("1. --- PATIENT MENU ---");
            Console.WriteLine("1. Register Patient");
            Console.WriteLine("2. See patients");
            Console.WriteLine("3. Search patient");
            Console.WriteLine("4. Remove Patient");
            Console.WriteLine("5. Exit");
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
        while (true)
        {
            Console.WriteLine(" ----- PETS MENU -----");
            Console.WriteLine("1. Add Pet to Patient");
            Console.WriteLine("2. Vaccination");
            Console.WriteLine("3. Exit");
            Console.Write("Select an option: ");
            var opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    GestionPaciente.AddPetToPatient();
                    break;
                case "2":
                    Vaccination.VaccinationMethod();
                    break;
                case "3":
                    return;
                default:
                    Console.WriteLine("Invalid option. Press Enter to continue....");
                    Console.ReadLine();
                    break;
            }
        }
    }

    public static void VeterinarianMenu()
    {
        while (true)
        {
            Console.WriteLine(" ----- VETERINARIAN MENU ----");
            Console.WriteLine("1. Register Veterinarian");
            Console.WriteLine("2. See Veterinarians");
            Console.WriteLine("3. Exit");
            Console.WriteLine("Select an option: ");
            var opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    GestionPaciente.RegisterVeterinarian();
                    break;
                case "3":
                    return;
                default:
                    Console.WriteLine("Invalid option. Press Enter to continue....");
                    Console.ReadLine();
                    break;       
    
            }
        }
    }

    public static void GeneralConsultationMenu()
    {
        while (true)
        {
            Console.WriteLine("----- GENERAL CONSULTATION ----");
            Console.WriteLine("1. Schedule appointment");
            Console.WriteLine("2. Show appointments of a patient by ID");
            Console.WriteLine("3. Exit");
            Console.Write("Select an option: ");
            var opcion = Console.ReadLine();


            switch (opcion)
            {
                case "1":
                    GestionPaciente.ScheduleAppointment();
                    break;

                case "2":
                    GestionPaciente.ShowAppointmentsByPatientId();
                    break;
                case "3":
                    return;
                default:
                    Console.WriteLine("Invalid option. Press Enter to continue....");
                    Console.ReadLine();
                    break;


            }
        }
    }
}







