using Gestion_clinica.models;
public class PetRepository : IPetRepository
{
    private readonly List<Pet> _pets = new();

    private int _nextId = 1;

    public void Add(Pet pet)
    {
        pet.Id = _nextId++;
        _pets.Add(pet);
    }

    public void Delete(int id)
    {
        var pet = _pets.FirstOrDefault(p => p.Id == id);
        if (pet != null)
            _pets.Remove(pet);
    }

    public bool PetExists(int id)
    {
        return _pets.Any(p => p.Id == id);
    }


    public List<Pet> GetAll() => _pets;

    public Pet GetByName(string name) => _pets.FirstOrDefault(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

    public void Update(Pet pet)
    {
        var existing = _pets.FirstOrDefault(p => p.Id == pet.Id);
        if (existing != null)
        {
            existing.Name = pet.Name;
            existing.Age = pet.Age;
            existing.Specie = pet.Specie;
            existing.Race = pet.Race;
            existing.OwnerId = pet.OwnerId;
        }
    }

    public Pet? GetById(int id)
    {
        return _pets.FirstOrDefault(p => p.Id == id);
    }
}
