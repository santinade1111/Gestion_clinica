using Gestion_clinica.models;
namespace Gestion_clinica.Interfaces
{
    public class Pet : Animal, IRegistrable<Pet>
    {
        public string Race { get; set; }
        public string Owner { get; set; }

        public Pet(string name, int age, string specie, string race, string owner)
        {
            Race = race;
            Owner = owner;
        }

        public void Register(Pet pet)
        {
            Console.WriteLine($"Pet registered: {pet.Name}, Age: {pet.Age}, Specie: {pet.Specie}, Race: {pet.Race}, Owner: {pet.Owner}");
        }

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
    }
}