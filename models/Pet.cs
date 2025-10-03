using Gestion_clinica.models;
namespace Gestion_clinica.Interfaces
{
    public class Pet : Animal, IRegistrable
    {
        public string Race { get; set; }
        public string Owner { get; set; }

        public Pet(string name, int age, string specie, string race, string owner)
            : base(name, age, specie)
        {
            Race = race;
            Owner = owner;
        }

        public void Register()
        {
            Console.WriteLine($"Pet registered: {Name}, Age: {Age}, Specie: {Specie}, Race: {Race}, Owner: {Owner}");
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