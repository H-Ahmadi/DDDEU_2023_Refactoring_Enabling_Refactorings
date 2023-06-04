using WorldCup.Core;
using WorldCup.Model;

namespace WorldCup.Services.OddsCalculation;

public class DoubleChanceCalculator : IOddsCalculator
{
    public Odds CalculateOdds(Game game)
    {
        var odds = new HomeDrawAwayOddsCalculator().CalculateOdds(game) as HomeDrawAwayOdds;

        var doubleChanceRate = GetDoubleChanceRateFromConfigFile();

        return new DoubleChanceOdds()
        {
            HomeOrDraw = (odds.Home + odds.Draw) / doubleChanceRate,
            AwayOrDraw = (odds.Away + odds.Draw) / doubleChanceRate,
        };
    }

    private double GetDoubleChanceRateFromConfigFile()
    {
        throw new RefactoringViolationException();
    }
}




