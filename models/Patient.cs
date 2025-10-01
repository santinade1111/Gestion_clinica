public class Patient
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public string Symptom { get; set; }
    public int Phone { get; set; }
    public string Address { get; set; }
    public List<Pet> Pets { get; set; }

    public Patient(int id, string name, int age, string symptom , int phone, string address)
    {
        Id = id;
        Name = name;
        Age = age;
        Symptom = symptom;
        Phone = phone;
        Address = address;
        Pets = new List<Pet>();
    }
}