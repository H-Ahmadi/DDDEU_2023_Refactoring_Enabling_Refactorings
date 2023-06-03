using ApprovalTests;
using ApprovalTests.Namers;
using ApprovalTests.Reporters;
using FluentAssertions;
using WorldCup.Model;
using WorldCup.Tests.TestDoubles;
using WorldCup.View;

namespace WorldCup.Tests;

//Approach 03 - Approval Testing
public class rendering_group_stage_tests_using_approvals
{

    [UseReporter(typeof(DiffReporter))]
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
        service.ShowGroup(group);
        
        var output = fakeConsole.GetOutput();
        Approvals.Verify(output);

    }
}