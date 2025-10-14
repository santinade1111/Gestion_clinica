using Gestion_clinica.models;

public interface IPetRepository
{
    Pet GetByName(string name);
    List<Pet> GetAll();
    void Add(Pet pet);
    void Update(Pet pet);
    void Delete(int id);
    Pet? GetById(int id);
}
