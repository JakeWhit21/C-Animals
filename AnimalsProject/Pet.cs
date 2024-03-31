namespace AnimalsProject;


public abstract class Pet
{
    protected string name;

    public Pet(string name)
    {
        this.name = name;
    }

    public string GetName()
    {
        return name;
    }
}

