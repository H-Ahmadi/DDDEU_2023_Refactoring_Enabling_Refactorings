using System.Text;
using WorldCup.DataAccess;
using WorldCup.Model;

namespace WorldCup.View;

public class GroupViewService
{
    private readonly IConsole _console;
    public GroupViewService(IConsole console)
    {
        _console = console;
    }
    public GroupViewService() : this(new SystemConsole()) { }
    public void ShowGroup(long groupStageId)
    {
        var groupStage = GroupStageStorage.LoadGroupStage(groupStageId);

        ShowGroup(groupStage);
    }
    public void ShowGroup(GroupStage groupStage)
    {
        _console.WriteLine("+------------------------------------+------+------+------+------+------+------+-------------+");
        _console.WriteLine("|                Team                |   P  |   W  |   D  |   L  |  GD  |  GS  |   Points    |");
        _console.WriteLine("+------------------------------------+------+------+------+------+------+------+-------------+");

        var rows = groupStage.GenerateTable();

        foreach (var row in rows)
        {
            _console.WriteLine("|{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|",
                PadCenter(row.TeamName, 36),
                PadCenter(row.GamesPlayed.ToString(), 6),
                PadCenter(row.Win.ToString(), 6),
                PadCenter(row.Draw.ToString(), 6),
                PadCenter(row.Lost.ToString(), 6),
                PadCenter(row.GoalDifference.ToString(), 6),
                PadCenter(row.GoalScored.ToString(), 6),
                PadCenter(row.Points.ToString(), 13)
            );
        }

        _console.WriteLine("+------------------------------------+------+------+------+------+------+------+-------------+");
    }

    // This method serves as a placeholder for the refactored code, currently calling the old code
    public void RenderGroup(GroupStage groupStage)
    {
        ShowGroup(groupStage);
    }

    private static string PadCenter(string text, int newWidth)
    {
        const char filler = ' ';
        var length = text.Length;
        var charactersToPad = newWidth - length;
        if (charactersToPad < 0) 
            throw new ArgumentException("New width must be greater than string length.", "newWidth");
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