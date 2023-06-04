namespace WorldCup.Model;

public class Team
{
    public long Id { get; set; }
    public string Name { get; set; }

    public Team(long id, string name)
    {
        Id = id;
        Name = name;
    }
    public Team()
    {
    }
}