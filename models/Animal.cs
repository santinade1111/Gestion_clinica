public abstract class Animal
{
    public string Name { get; set; } = string.Empty;
    public int Age { get; set; } = 0;
    public string Specie { get; set; } = string.Empty;

    public virtual void MakeSound()
    {
    }

}

