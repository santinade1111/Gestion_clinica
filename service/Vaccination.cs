using System;
using Gestion_clinica;

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

                // Buscar la mascota en todos los pacientes
            var foundPet = GestionPaciente.patients
                    .SelectMany(p => p.Pets)
                    .FirstOrDefault(pet => pet.Name.Equals(petName, StringComparison.OrdinalIgnoreCase));

                if (foundPet != null)
                {
                    Console.WriteLine($"Pet '{foundPet.Name}' found. Vaccination applied successfully!");
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