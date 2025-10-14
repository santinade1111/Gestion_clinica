using Gestion_clinica.models;
namespace Gestion_clinica.models
{
    public class Veterinarian : IRegistrable<Veterinarian>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Specialty { get; set; }
        public Veterinarian() { }

        public Veterinarian(int id, string name, string specialty)
        {
            Id = id;
            Name = name;
            Specialty = specialty;
        }

        public void Register(Veterinarian veterinarian)
        {
            Console.WriteLine($"Veterinarian registrared successfully: {veterinarian.Name}, {veterinarian.Specialty}");
        }
    }
}