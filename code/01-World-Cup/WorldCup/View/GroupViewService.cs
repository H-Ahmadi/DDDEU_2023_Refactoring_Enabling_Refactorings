using System.Text;
using WorldCup.Services;

namespace WorldCup.View;

public class GroupViewService
{
    public static void DrawGroup(long groupStageId)
    {
        var groupStage = DataAccessService.LoadStage(groupStageId);

        Console.WriteLine("+----------------+------+------+------+------+------+------+-------------+");
        Console.WriteLine("|      Team      |   P  |   W  |   D  |   L  |  GD  |  GS  |   Points    |");
        Console.WriteLine("+----------------+------+------+------+------+------+------+-------------+");

        var tableRows = new Dictionary<string, StageTableViewModel>();
        foreach (var team in groupStage.Teams)
            tableRows.Add(team.Name, new StageTableViewModel());

        foreach (var game in groupStage.Games)
        {
            var team1 = game.Team1;
            var team2 = game.Team2;
            var score1 = game.Score1.Value;
            var score2 = game.Score2.Value;

            tableRows[team1.Name].GamesPlayed++;
            tableRows[team2.Name].GamesPlayed++;

            tableRows[team1.Name].GoalScored += score1;
            tableRows[team1.Name].GoalDifference += score1 - score2;
            if (score1 > score2)
            {
                tableRows[team1.Name].Points += 3;
                tableRows[team1.Name].Win++;
                tableRows[team2.Name].Lost++;
            }
            else if (score1 == score2)
            {
                tableRows[team1.Name].Points += 1;
                tableRows[team1.Name].Draw++;
            }

            tableRows[team2.Name].GoalScored += score2;
            tableRows[team2.Name].GoalDifference += score2 - score1;
            if (score2 > score1)
            {
                tableRows[team2.Name].Points += 3;
                tableRows[team2.Name].Win++;
                tableRows[team1.Name].Lost++;

            }
            else if (score2 == score1)
            {
                tableRows[team2.Name].Points += 1;
                tableRows[team2.Name].Draw++;

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
                PadCenter(row.Key, 16), 
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
        public int GamesPlayed { get; set; }
        public int Win { get; set; }
        public int Draw { get; set; }
        public int Lost { get; set; }
        public int GoalDifference { get; set; }
        public int GoalScored { get; set; }
        public int Points { get; set; }
    }
}