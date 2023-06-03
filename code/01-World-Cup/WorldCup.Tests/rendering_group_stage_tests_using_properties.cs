using FizzWare.NBuilder;
using FluentAssertions;
using FsCheck;
using FsCheck.Xunit;
using Microsoft.FSharp.Collections;
using System.Collections.Generic;
using WorldCup.Model;
using WorldCup.Tests.TestDoubles;
using WorldCup.View;

namespace WorldCup.Tests;

//Approach 02 - Property-Based Testing
public class rendering_group_stage_tests_using_properties
{
    private readonly Arbitrary<FSharpList<PositiveInt>> _twelveScoresGenerator;
    public rendering_group_stage_tests_using_properties()
    {
        _twelveScoresGenerator = Gen.ListOf(12, Arb.Generate<PositiveInt>()).ToArbitrary();
    }

    [Property]
    public Property Showing_a_single_group_stage_on_console()
    {
        return Prop.ForAll(
            _twelveScoresGenerator,
                twelveScores =>
            {
                var stackOfScores = new Stack<int>(twelveScores.Select(a=> a.Item).ToList());
                var teams = new List<Team>() { new("France"), new("Australia"), new("Denmark"), new("Tunisia") };
                var games = teams
                    .SelectMany((team, index) => teams.Skip(index + 1).Select(rival => new { team, rival }))
                    .Select(a => new Game(a.team, a.rival) { Score1 = stackOfScores.Pop(), Score2 = stackOfScores.Pop() })
                    .ToList();
                var group = new GroupStage()
                {
                    Name = "Imaginary FIFA WorldCup - Group X",
                    Games = games,
                    Teams = teams.ToList(),
                };
                var consoleForOldCode = new FakeConsole();
                var consoleForNewCode = new FakeConsole();

                new GroupViewService(consoleForNewCode).ShowGroup(group);
                new GroupViewService(consoleForOldCode).RenderGroup(group);

                return (consoleForNewCode.GetOutput() == consoleForOldCode.GetOutput()).ToProperty();
            });
    }
}