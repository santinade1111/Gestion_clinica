namespace Gestion_clinica.models

{
    public class Pet : Animal
    {
        public int Id { get; set; }
        public string Race { get; set; }
        public int OwnerId { get; set; }
        

        public List<VaccinationRecord> VaccinationHistory { get; set; }

        public Pet(string name, int age, string specie, string race, int ownerId)
        {
            Name = name;
            Age = age;
            Specie = specie;
            Race = race;
            OwnerId = ownerId;
            VaccinationHistory = new List<VaccinationRecord>();
        }
    }
}