using System.Text;
using WorldCup.DataAccess;
using WorldCup.Model;
using WorldCup.Services.OddsCalculation;

namespace WorldCup.View;

public class OddsView
{
    public void ShowOddsForGame(long id, OddsType oddsType)
    {
        var game = GameDataAccess.Retrieve(id);

        IOddsCalculator oddsCalculator = new HomeDrawAwayOddsCalculator();
        if (oddsType == OddsType.DoubleChance)
            oddsCalculator = new DoubleChanceCalculator();

        var odds = oddsCalculator.CalculateOdds(game);
        var tableRows = new Dictionary<string, double>();
        if (odds is HomeDrawAwayOdds data)
        {
            tableRows.Add("Home", data.Home);
            tableRows.Add("Draw", data.Draw);
            tableRows.Add("Away", data.Away);
        }
        else if (odds is DoubleChanceOdds doubleChanceData)
        {
            tableRows.Add("Home Or Draw", doubleChanceData.HomeOrDraw);
            tableRows.Add("Away Or Draw", doubleChanceData.AwayOrDraw);
        }

        Console.WriteLine("+-------------------------------------+------------+");
        Console.WriteLine("|                 Odds                +    Rate    +");
        Console.WriteLine("+-------------------------------------+------------+");
        foreach (var tableRow in tableRows)
            Console.WriteLine($"|{PadCenter(tableRow.Key, 37)}+{PadCenter(tableRow.Value.ToString("0.##"), 12)}+");
        Console.WriteLine("+-------------------------------------+------------+");
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
}



public enum OddsType
{
    HomeDrawAway, //1x2
    DoubleChance,
}