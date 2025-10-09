using Gestion_clinica.models;
namespace Gestion_clinica.Interfaces
{
    public class Pet : Animal, IRegistrable<Pet>
    {
        public string Race { get; set; }
        public string Owner { get; set; }
        public List<VaccinationRecord> VaccinationHistory { get; set; }

        public Pet(string name, int age, string specie, string race, string owner)
        {
            Name = name;
            Age = age;
            Specie = specie;
            Race = race;
            Owner = owner;
            VaccinationHistory = new List<VaccinationRecord>();
        }

        public void Register(Pet pet)
        {
            Console.WriteLine($"Pet registered: {pet.Name}, Age: {pet.Age}, Specie: {pet.Specie}, Race: {pet.Race}, Owner: {pet.Owner}");
        }

        // sound to pets
        public override void MakeSound()
        {
            switch (Race.ToLower())
            {
                case "dog":
                    Console.WriteLine("Guau! Guau!");
                    break;
                case "cat":
                    Console.WriteLine("Miau! Miau!");
                    break;
                case "bird":
                    Console.WriteLine("Pío! Pío!");
                    break;
                default:
                    Console.WriteLine("Unknown pet sound.");
                    break;
            }
        }

        // add vaccination to pet
        public void AddVaccination(string vaccineName)
        {
            // keep existing behavior for backward compatibility: use now
            AddVaccination(vaccineName, DateTime.Now);
        }

        // overload to allow specifying the date of application
        public void AddVaccination(string vaccineName, DateTime dateApplied)
        {
            var vaccinationRecord = new VaccinationRecord(vaccineName, dateApplied);
            VaccinationHistory.Add(vaccinationRecord);
            Console.WriteLine($"Date of application of the '{vaccineName}' vaccine for the pet {Name}: {vaccinationRecord.DateApplied:dd/MM/yyyy}");
        }

        public void ShowVaccinationHistory()
        {
            Console.WriteLine($"Vaccination History for {Name}:");
            if (VaccinationHistory.Count == 0)
            {
                Console.WriteLine("No vaccinations applied yet.");
            }
            else
            {
                foreach (var record in VaccinationHistory)
                {
                    Console.WriteLine($"- {record.VaccineName} on {record.DateApplied:dd/MM/yyyy}");
                }
            }
        }
    }
}