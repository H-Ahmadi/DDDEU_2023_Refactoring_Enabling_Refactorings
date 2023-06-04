using WorldCup.DataAccess;
using WorldCup.Model;

namespace WorldCup.Services.OddsCalculation;

public class HomeDrawAwayOddsCalculator : IOddsCalculator
{
    public Odds CalculateOdds(Game game)
    {
        double homeTeamRanking = RankingDataAccess.GetTeamRanking(game.Team1.Id);
        double awayTeamRanking = RankingDataAccess.GetTeamRanking(game.Team2.Id);

        var odds = new HomeDrawAwayOdds()
        {
            Home = awayTeamRanking / homeTeamRanking + 1,
            Away = homeTeamRanking / awayTeamRanking + 1
        };
        odds.Draw = (odds.Home + odds.Away) / 2;
        return odds;
    }
}