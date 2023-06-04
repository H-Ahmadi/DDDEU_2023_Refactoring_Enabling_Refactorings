namespace WorldCup.Model;

public class Game
{
    public Guid Id { get; set; }
    public Team Team1 { get; set; }
    public Team Team2 { get; set; }
    public int Score1 { get; set; }
    public int Score2 { get; set; }
    public Game(Team team1, Team team2)
    {
        this.Id = Id;
        Team1 = team1;
        Team2 = team2;
    }
    public void PlayGame(int score1, int score2)
    {
        Score1 = score1;
        Score2 = score2;
    }
}