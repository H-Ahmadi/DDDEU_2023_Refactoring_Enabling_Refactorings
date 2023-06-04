namespace WorldCup.Model
{
    public class GroupStage
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public List<Team> Teams { get; set; }
        public List<Game> Games { get; set; }
        public GroupStage()
        {
            Teams = new List<Team>();
            Games = new List<Game>();
        }
    }
}