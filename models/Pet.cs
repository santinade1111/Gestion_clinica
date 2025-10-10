using Gestion_clinica.models;
namespace Gestion_clinica.Interfaces
{
    public class Pet : Animal
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
    }
}