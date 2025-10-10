public class PetRepository : IPetRepository
{
    private readonly List<Pet> _pets = new();

    public void Add(Pet pet)
    {
        _pets.Add(pet);
    }

    public void Delete(string name)
    {
        var pet = GetByName(name);
        if (pet != null)
        {
            _pets.Remove(pet);
        }
    }

    public List<Pet> GetAll() => _pets;

    public Pet GetByName(string name) => _pets.FirstOrDefault(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

    public void Update(Pet pet)
    {
        var existing = GetByName(pet.Name);
        if (existing != null)
        {
            existing.Age = pet.Age;
            existing.Specie = pet.Specie;
            existing.Race = pet.Race;
            existing.Owner = pet.Owner;
        }
    }
}
