namespace WorldCup.Model;

public class TableRow
{
    public string TeamName { get; set; }
    public int GamesPlayed { get; set; }
    public int Win { get; set; }
    public int Draw { get; set; }
    public int Lost { get; set; }
    public int GoalDifference { get; set; }
    public int GoalScored { get; set; }
    public int Points { get; set; }
    public void UpdateStats(int scoreFor, int scoreAgainst)
    {
        GamesPlayed++;
        GoalScored += scoreFor;
        GoalDifference += scoreFor - scoreAgainst;

        if (scoreFor > scoreAgainst)
        {
            Points += 3;
            Win++;
        }
        else if (scoreFor == scoreAgainst)
        {
            Points += 1;
            Draw++;
        }
        else
            Lost++;
    }
}