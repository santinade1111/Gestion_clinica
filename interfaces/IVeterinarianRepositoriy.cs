using Gestion_clinica.models;

public interface IVeterinarianRepository
{
    Veterinarian GetById(int id);
    List<Veterinarian> GetAll();
    void Add(Veterinarian vet);
    void Update(Veterinarian vet);
    void Delete(int id);
    bool VeterinarianExists(int id);
    
}
