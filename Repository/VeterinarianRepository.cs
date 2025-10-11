using Gestion_clinica.models;

public class VeterinarianRepository : IVeterinarianRepository
{
    private readonly List<Veterinarian> _vets = new();

    public void Add(Veterinarian vet)
    {
        _vets.Add(vet);
    }

    public void Delete(int id)
    {
        var vet = GetById(id);
        if (vet != null)
        {
            _vets.Remove(vet);
        }
    }

    public List<Veterinarian> GetAll() => _vets;

    public Veterinarian GetById(int id) => _vets.FirstOrDefault(v => v.Id == id);

    public void Update(Veterinarian vet)
    {
        var existing = GetById(vet.Id);
        if (existing != null)
        {
            existing.Name = vet.Name;
            existing.Specialty = vet.Specialty;
        }
    }
}
