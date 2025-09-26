public class Patient
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public string Symptom { get; set; }
    public List<Pet> Pets { get; set; }

    public Patient(int id, string name, int age, string symptom)
    {
        Id = id;
        Name = name;
        Age = age;
        Symptom = symptom;
        Pets = new List<Pet>();
    }
}