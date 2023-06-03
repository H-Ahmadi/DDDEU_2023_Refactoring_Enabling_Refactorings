namespace WorldCup.Model;

public class Team
{
    public string Name { get; set; }
    public Team() { }
    public Team(string name)
    {
        Name = name;
    }
}