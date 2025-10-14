using Gestion_clinica.models;

public interface IPetRepository
{
    Pet GetByName(string name);
    List<Pet> GetAll();
    void Add(Pet pet);
    void Update(Pet pet);
    void Delete(string name);
    Pet? GetById(int id);
}
