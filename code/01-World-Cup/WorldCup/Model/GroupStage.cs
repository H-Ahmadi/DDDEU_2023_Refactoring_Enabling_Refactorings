namespace WorldCup.Model
{
    public class GroupStage
    {
        public string Name { get; set; }
        public List<Team> Teams { get; set; }
        public List<Game> Games { get; set; }
        public GroupStage()
        {
            Teams = new List<Team>();
            Games = new List<Game>();
        }

        public List<TableRow> GenerateTable()
        {
            var rows = Teams.ToDictionary(team => team.Name, team => new TableRow() { TeamName = team.Name });

            foreach (var game in Games)
            {
                var team1 = game.Team1;
                var team2 = game.Team2;
                var score1 = game.Score1.Value;
                var score2 = game.Score2.Value;

                rows[team1.Name].UpdateStats(score1, score2);
                rows[team2.Name].UpdateStats(score2, score1);
            }
            return rows.Values.OrderByDescending(row => row.Points)
                .ThenByDescending(row => row.GoalDifference)
                .ThenByDescending(row => row.GoalScored)
                .ToList();
        }
    }
}