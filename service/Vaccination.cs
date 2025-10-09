using System;
using System.Transactions;
using Gestion_clinica;
using Gestion_clinica.models;

namespace Gestion_clinica.service
{
    public class Vaccination : ServiceVeterinary
    {
        public override void Attend()
        {
            Console.Clear();
            Console.WriteLine("--- Vaccination ---");
            Console.Write("Enter pet name: ");
            string petName = Console.ReadLine()?.Trim() ?? string.Empty;

            if (string.IsNullOrWhiteSpace(petName))
            {
                Console.WriteLine("Pet name cannot be empty. Press Enter to continue...");
                Console.ReadKey();
                return;
            }

            // search the pet in all patients
            var foundPet = GestionPatient.patients
                .SelectMany(p => p.Pets)
                .FirstOrDefault(pet => pet.Name.Equals(petName, StringComparison.OrdinalIgnoreCase));

            if (foundPet != null)
            {
                Console.WriteLine($"Pet '{foundPet.Name}' found.");

                Console.WriteLine("Enter vaccine name:");
                string vaccineName = Console.ReadLine()?.Trim() ?? string.Empty;

                if (string.IsNullOrWhiteSpace(vaccineName))
                {
                    Console.WriteLine("Vaccine name cannot be empty. Press enter to continue");
                    Console.ReadKey();
                    return;
                }

                // Ask for the date of vaccination
                Console.Write("Enter date of vaccination (format: dd/MM/yyyy) or press Enter to use today: ");
                var dateInput = Console.ReadLine();
                DateTime dateApplied;
                if (string.IsNullOrWhiteSpace(dateInput))
                {
                    dateApplied = DateTime.Now;
                }
                else if (!DateTime.TryParseExact(dateInput, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dateApplied))
                {
                    Console.WriteLine("Invalid date format. Press Enter to continue...");
                    Console.ReadKey();
                    return;
                }

                // register the vaccination to pet with specified date
                foundPet.AddVaccination(vaccineName, dateApplied);
                Console.WriteLine($"Vaccination '{vaccineName}' applied on {dateApplied:dd/MM/yyyy} successfully");
            }
            else
            {
                Console.WriteLine($"Pet '{petName}' not found. Cannot apply vaccination.");
            }
            Console.WriteLine("Press Enter to continue...");
            Console.ReadKey();
        }

        public static void VaccinationMethod()
        {
            var consulta = new Vaccination();
            consulta.Attend();
        }

    }
}