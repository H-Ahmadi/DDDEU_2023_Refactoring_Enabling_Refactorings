using FluentAssertions;
using WorldCup.Model;
using WorldCup.Tests.TestDoubles;
using WorldCup.View;

namespace WorldCup.Tests;

//Approach 01 - Example-Based Testing
public class rendering_group_stage_tests_using_examples
{

    [Fact]
    public void Showing_a_single_group_stage_on_console()
    {
        var fakeConsole = new FakeConsole();

        var france = new Team("France");
        var australia = new Team("Australia");
        var denmark = new Team("Denmark");
        var tunisia = new Team("Tunisia");

        var group = new GroupStage()
        {
            Name = "FIFA WorldCup 2022 - Group D",
            Teams = new List<Team>() { france, australia, denmark, tunisia },
            Games = new List<Game>()
            {
                new Game(denmark, tunisia) { Score1 = 0, Score2 = 0 },
                new Game(france, australia) { Score1 = 4, Score2 = 1 },
                new Game(tunisia, australia) { Score1 = 0, Score2 = 1 },
                new Game(france, denmark) { Score1 = 2, Score2 = 1 },
                new Game(australia, denmark) { Score1 = 1, Score2 = 0 },
                new Game(tunisia, france) { Score1 = 1, Score2 = 0 },
            }
        };
        var service = new GroupViewService(fakeConsole);
        var expectedTable = "+------------------------------------+------+------+------+------+------+------+-------------+\r\n" +
                            "|                Team                |   P  |   W  |   D  |   L  |  GD  |  GS  |   Points    |\r\n" +
                            "+------------------------------------+------+------+------+------+------+------+-------------+\r\n" +
                            "|               France               |   3  |   2  |   0  |   1  |   3  |   6  |      6      |\r\n" +
                            "|              Australia             |   3  |   2  |   0  |   1  |  -1  |   3  |      6      |\r\n" +
                            "|               Tunisia              |   3  |   1  |   1  |   1  |   0  |   1  |      4      |\r\n" +
                            "|               Denmark              |   3  |   0  |   1  |   2  |  -2  |   1  |      1      |\r\n" +
                            "+------------------------------------+------+------+------+------+------+------+-------------+\r\n";

        service.ShowGroup(group);
        var actualRenderedTable = fakeConsole.GetOutput();

        actualRenderedTable.Should().Be(expectedTable);
    }
}