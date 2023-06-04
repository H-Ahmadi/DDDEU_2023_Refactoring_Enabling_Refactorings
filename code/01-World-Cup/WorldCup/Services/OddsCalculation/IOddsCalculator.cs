using WorldCup.Model;

namespace WorldCup.Services.OddsCalculation;

public interface IOddsCalculator
{
    Odds CalculateOdds(Game game);
}