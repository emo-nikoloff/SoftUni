using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Championship.Tests;

public class ChampionshipTests
{
    private League league;

    private Team team;

    [SetUp]
    public void Setup()
    {
        league = new();
        team = new("Dorostol");
    }

    [Test]
    public void ConstructorShouldInitializeCorrectly()
    {
        Assert.That(league.Teams, Is.Not.Null);
        Assert.That(league.Capacity, Is.EqualTo(10));
    }

    [Test]
    public void AddTeamMethodShouldThrowInvalidOperationExceptionIfLeagueIsFull()
    {
        for (int i = 0; i < 10; i++)
        {
            league.AddTeam(new Team($"Team {i}"));
        }

        Assert.That(() =>
        {
            league.AddTeam(team);
        }, Throws.InvalidOperationException);
    }

    [Test]
    public void AddTeamMethodShouldThrowInvalidOperationExceptionIfTeamExists()
    {
        league.AddTeam(team);

        Assert.That(() =>
        {
            league.AddTeam(team);
        }, Throws.InvalidOperationException);
    }

    [Test]
    public void AddTeamMethodShouldAddTeamCorrectly()
    {
        league.AddTeam(team);

        Assert.That(league.Teams.Count, Is.EqualTo(1));
    }

    [Test]
    public void RemoveTeamMethodShouldReturnFalseIfTeamIsNull()
    {
        Assert.That(league.RemoveTeam(team.Name), Is.False);
    }

    [Test]
    public void RemoveTeamMethodShouldReturnTrueIfTeamExistsAndRemoveTeamCorrectly()
    {
        league.AddTeam(team);

        Assert.That(league.RemoveTeam(team.Name), Is.True);
        Assert.That(league.Teams, Is.Empty);
    }

    [Test]
    public void PlayMatchMethodShouldThrowInvalidOperationExceptionIfEitherTeamIsNull()
    {
        Assert.That(() =>
        {
            league.PlayMatch("Dorostol", "CSKA", 3, 0);
        }, Throws.InvalidOperationException);
    }

    [Test]
    public void PlayMatch_ShouldUpdateStatsCorrectly_WhenHomeTeamWins()
    {
        Team levski = new("Levski");
        Team cska = new("CSKA");

        league.AddTeam(levski);
        league.AddTeam(cska);

        league.PlayMatch("Levski", "CSKA", 2, 1);

        Assert.That(levski.Wins, Is.EqualTo(1));
        Assert.That(levski.Points, Is.EqualTo(3));
        Assert.That(cska.Loses, Is.EqualTo(1));
        Assert.That(cska.Points, Is.EqualTo(0));
    }

    [Test]
    public void PlayMatch_ShouldUpdateStatsCorrectly_WhenAwayTeamWins()
    {
        Team levski = new("Levski");
        Team cska = new("CSKA");

        league.AddTeam(levski);
        league.AddTeam(cska);

        league.PlayMatch("Levski", "CSKA", 0, 2);

        Assert.That(levski.Loses, Is.EqualTo(1));
        Assert.That(levski.Points, Is.EqualTo(0));
        Assert.That(cska.Wins, Is.EqualTo(1));
        Assert.That(cska.Points, Is.EqualTo(3));
    }

    [Test]
    public void PlayMatch_ShouldUpdateStatsCorrectly_WhenMatchIsDraw()
    {
        Team levski = new("Levski");
        Team cska = new("CSKA");

        league.AddTeam(levski);
        league.AddTeam(cska);

        league.PlayMatch("Levski", "CSKA", 1, 1);

        Assert.That(levski.Draws, Is.EqualTo(1));
        Assert.That(levski.Points, Is.EqualTo(1));
        Assert.That(cska.Draws, Is.EqualTo(1));
        Assert.That(cska.Points, Is.EqualTo(1));
    }

    [Test]
    public void GetTeamInfoMethodShouldThrowInvalidOperationExceptionIfTeamIsNull()
    {
        Assert.That(() =>
        {
            league.GetTeamInfo(team.Name);
        }, Throws.InvalidOperationException);
    }

    [Test]
    public void GetTeamInfoMethodShouldReturnTeamInfoCorrectly()
    {
        league.AddTeam(team);

        team.Win();
        team.Draw();

        string expectedResult = "Dorostol - 4 points (1W 1D 0L)";
        string actualResult = league.GetTeamInfo(team.Name);

        Assert.That(expectedResult, Is.EqualTo(actualResult));
    }
}
