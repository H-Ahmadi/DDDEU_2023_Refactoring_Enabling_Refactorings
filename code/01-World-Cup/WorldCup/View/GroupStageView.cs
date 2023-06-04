using System.Text;
using WorldCup.DataAccess;

namespace WorldCup.View;

public class GroupStageView
{
    public void ShowGroup(long groupStageId)
    {
        var groupStage = GroupStageDataAccess.LoadGroupStage(groupStageId);

        Console.WriteLine("+----------------+------+------+------+------+------+------+-------------+");
        Console.WriteLine("|      Team      |   P  |   W  |   D  |   L  |  GD  |  GS  |   Points    |");
        Console.WriteLine("+----------------+------+------+------+------+------+------+-------------+");

        var tableRows = new Dictionary<long, StageTableViewModel>();
        foreach (var team in groupStage.Teams)
            tableRows.Add(team.Id, new StageTableViewModel(){ TeamName = team.Name});

        foreach (var game in groupStage.Games)
        {
            var team1 = game.Team1;
            var team2 = game.Team2;
            var score1 = game.Score1;
            var score2 = game.Score2;

            tableRows[team1.Id].GamesPlayed++;
            tableRows[team2.Id].GamesPlayed++;

            tableRows[team1.Id].GoalScored += score1;
            tableRows[team1.Id].GoalDifference += score1 - score2;
            if (score1 > score2)
            {
                tableRows[team1.Id].Points += 3;
                tableRows[team1.Id].Win++;
                tableRows[team2.Id].Lost++;
            }
            else if (score1 == score2)
            {
                tableRows[team1.Id].Points += 1;
                tableRows[team1.Id].Draw++;
            }

            tableRows[team2.Id].GoalScored += score2;
            tableRows[team2.Id].GoalDifference += score2 - score1;
            if (score2 > score1)
            {
                tableRows[team2.Id].Points += 3;
                tableRows[team2.Id].Win++;
                tableRows[team1.Id].Lost++;

            }
            else if (score2 == score1)
            {
                tableRows[team2.Id].Points += 1;
                tableRows[team2.Id].Draw++;

            }
        }

        var rows = tableRows.ToList();
        rows.Sort((team1, team2) =>
        {
            if (team1.Value.Points != team2.Value.Points)
                return team2.Value.Points.CompareTo(team1.Value.Points);
            else if (team1.Value.GoalDifference != team2.Value.GoalDifference)
                return team2.Value.GoalDifference.CompareTo(team1.Value.GoalDifference);
            else
                return team2.Value.GoalScored.CompareTo(team1.Value.GoalScored);

            //The rest of the rules have been omitted for simplicity (such as head-to-head results and Fair Play Fair Play Points).
        });

        foreach (var row in rows)
        {
            Console.WriteLine("|{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|", 
                PadCenter(row.Value.TeamName, 16), 
                PadCenter(row.Value.GamesPlayed.ToString(), 6),
                PadCenter(row.Value.Win.ToString(), 6),
                PadCenter(row.Value.Draw.ToString(), 6),
                PadCenter(row.Value.Lost.ToString(), 6),
                PadCenter(row.Value.GoalDifference.ToString(), 6), 
                PadCenter(row.Value.GoalScored.ToString(), 6),
                PadCenter(row.Value.Points.ToString(), 13)
                );

        }
        Console.WriteLine("+----------------+------+------+------+------+------+------+-------------+");
    }

    private static string PadCenter(string text, int newWidth)
    {
        const char filler = ' ';
        var length = text.Length;
        var charactersToPad = newWidth - length;
        if (charactersToPad < 0) throw new ArgumentException("New width must be greater than string length.", "newWidth");
        var padLeft = charactersToPad / 2 + charactersToPad % 2;
        //add a space to the left if the string is an odd number
        var padRight = charactersToPad / 2;

        var resultBuilder = new StringBuilder(newWidth);
        for (var i = 0; i < padLeft; i++) resultBuilder.Insert(i, filler);
        for (var i = 0; i < length; i++) resultBuilder.Insert(i + padLeft, text[i]);
        for (var i = newWidth - padRight; i < newWidth; i++) resultBuilder.Insert(i, filler);
        return resultBuilder.ToString();
    }

    public class StageTableViewModel
    {
        public string TeamName { get; set; }
        public int GamesPlayed { get; set; }
        public int Win { get; set; }
        public int Draw { get; set; }
        public int Lost { get; set; }
        public int GoalDifference { get; set; }
        public int GoalScored { get; set; }
        public int Points { get; set; }
    }
}