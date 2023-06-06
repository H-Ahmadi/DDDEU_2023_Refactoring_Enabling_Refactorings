using WorldCup.DataAccess;
using WorldCup.Model;
using WorldCup.Model.Enums;
using WorldCup.View;

namespace WorldCup.Services;

public static class GameService
{
    public static Guid AddGame(AddGameDto dto)
    {
        //Update the group
        var group = GroupStageDataAccess.LoadGroupStage(dto.GroupId);
        var homeTeam = TeamDataAccess.LoadTeam(dto.HomeTeamId);
        var awayTeam = TeamDataAccess.LoadTeam(dto.AwayTeamId);
        var game = new Game(homeTeam, awayTeam);
        game.Score1 = dto.HomeScores;
        game.Score2 = dto.AwayScores;

        group.Games.Add(game);
        GroupStageDataAccess.UpdateGroup(group);

        //Update FIFA ranking
        var rankingService = new FifaRankingService();
        rankingService.UpdateRankingForTeams(game, Stages.Group);

        return game.Id;
    }
}

public class AddGameDto
{
    public long GroupId { get; set; }
    public long HomeTeamId { get; set; }
    public long AwayTeamId { get; set; }
    public int HomeScores { get; set; }
    public int AwayScores { get; set; }
}