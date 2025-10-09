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

            // Search the pet in all patients
            var foundPet = GestionPatient.patients
                .SelectMany(p => p.Pets)
                .FirstOrDefault(pet => pet.Name.Equals(petName, StringComparison.OrdinalIgnoreCase));

            if (foundPet != null)
            {
                Console.WriteLine($"Pet '{foundPet.Name}' found.");

                // Check if there are any registered veterinarians
                if (GestionPatient.veterinarians.Count == 0)
                {
                    Console.WriteLine("No veterinarians registered. Vaccination cannot proceed. Press Enter to continue...");
                    Console.ReadKey();
                    return;
                }

                // Ask for veterinarian ID
                Console.WriteLine("Enter veterinarian ID:");
                int vetId;
                while (true)
                {
                    var vetIdInput = Console.ReadLine();
                    if (int.TryParse(vetIdInput, out vetId))
                    {
                        var veterinarian = GestionPatient.veterinarians.FirstOrDefault(v => v.Id == vetId);
                        if (veterinarian != null)
                        {
                            Console.WriteLine($"Veterinarian {veterinarian.Name} has been assigned to this vaccination.");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Invalid veterinarian ID. Please try again.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a valid veterinarian ID.");
                    }
                }

                // Enter vaccine name
                Console.WriteLine("Enter vaccine name:");
                string vaccineName = Console.ReadLine()?.Trim() ?? string.Empty;

                if (string.IsNullOrWhiteSpace(vaccineName))
                {
                    Console.WriteLine("Vaccine name cannot be empty. Press enter to continue.");
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

                // Register the vaccination for the pet
                foundPet.AddVaccination(vaccineName, dateApplied);
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