using System.Text.RegularExpressions;
using WorldCup.DataAccess;
using WorldCup.Model;
using WorldCup.Model.Enums;

namespace WorldCup.View;

public class FifaRankingService
{
    public void UpdateRankingForTeams(Game game, Stages stage)
    {
        UpdateRankForTeam(game.Team1, game.Team2, game.Score1, game.Score2, stage);
        UpdateRankForTeam(game.Team2, game.Team1, game.Score2, game.Score1, stage);
    }

    private void UpdateRankForTeam(Team team, Team opponent, int goalsScored, int goalsAgainst, Stages stage)
    {
        var matchResultPoints = 0.0;
        var opponentStrengthPoints = 0.0;
        var matchImportancePoints = 0.0;
        var confederationWeighting = 0.0;

        if (goalsScored > goalsAgainst)
        {
            matchResultPoints += 2.0;
        }
        else if (goalsScored == goalsAgainst)
        {
            matchResultPoints += 1.0;
        }

        if (stage == Stages.Group)
        {
            matchImportancePoints += 0.5;
        }
        else if (stage == Stages.Knockout)
        {
            matchImportancePoints += 1.0;
        }
        else if (stage == Stages.Final)
        {
            matchImportancePoints += 2.0;
        }

        var confederation = ConfederationService.FindConfederationForTeam(team.Id);

        switch (confederation)
        {
            case Confederations.AFC:
                confederationWeighting = 1.0;
                break;
            case Confederations.CAF:
                confederationWeighting = 0.9;
                break;
            case Confederations.CONCACAF:
                confederationWeighting = 0.8;
                break;
            case Confederations.CONMEBOL:
                confederationWeighting = 1.2;
                break;
            case Confederations.OFC:
                confederationWeighting = 0.7;
                break;
            case Confederations.UEFA:
                confederationWeighting = 1.5;
                break;
            default:
                confederationWeighting = 1.0;
                break;
        }

        var opponentRanking = RankingDataAccess.GetTeamRanking(opponent.Id);
        if (opponentRanking <= 100)
        {
            opponentStrengthPoints = 1.0;
        }
        else if (opponentRanking <= 200)
        {
            opponentStrengthPoints = 1.1;
        }
        else if (opponentRanking <= 300)
        {
            opponentStrengthPoints = 1.2;
        }
        else if (opponentRanking <= 400)
        {
            opponentStrengthPoints = 1.3;
        }
        else if (opponentRanking <= 500)
        {
            opponentStrengthPoints = 1.4;
        }
        else
        {
            opponentStrengthPoints = 1.5;
        }

        var rankingPoints = matchResultPoints + opponentStrengthPoints + matchImportancePoints;
        rankingPoints *= confederationWeighting;

        RankingDataAccess.UpdateRankForTeam(team.Id, rankingPoints);
    }
}