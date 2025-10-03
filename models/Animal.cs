public class Animal
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string Specie { get; set; }

    public Animal(string name, int age, string specie)
    {
        Name = name;
        Age = age;
        Specie = specie;
    }

    public virtual void MakeSound()
    {
    }

}

