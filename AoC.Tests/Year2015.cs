using AoC2015.PuzzleSolvers;
using FluentAssertions;

namespace AoC.Tests;

public class Year2015
{
  public class Day05
  {
    [Fact]
    public void Part01()
    {
      var input = "ugknbfddgicrmopn";
      input.HasAtLeastThreeVowels().Should().BeTrue();
      input.HasAtLeastOneLetterThatAppearsTwiceInARow().Should().BeTrue();
      input.HasNoForbiddenSubstrings().Should().BeTrue();
      input.IsNice().Should().BeTrue();
    }
  }
}