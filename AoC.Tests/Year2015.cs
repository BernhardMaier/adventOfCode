using AoC2015.PuzzleSolvers;
using FluentAssertions;
using Xunit.Sdk;

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
    
    [Theory]
    [InlineData("qjhvhtzxzqqjkmpb", true, true)]
    [InlineData("xxyxx", true, true)]
    [InlineData("uurcxstgmygtbstg", true, false)]
    [InlineData("ieodomkazucvgmuy", false, true)]
    public void Part02(
      string input,
      bool shouldHaveAtLeastTwoIdenticalLetterPairsThatDoNotOverlap,
      bool shouldHaveAtLeastOnLetterPairWithExactlyOneLetterBetweenThem)
    {
      var bunchOfLetters = PuzzleSolverFor20150502.BunchOfLetters.GetFrom(input);
      
      bunchOfLetters.HasAtLeastTwoIdenticalLetterPairsThatDoNotOverlap.Should().Be(shouldHaveAtLeastTwoIdenticalLetterPairsThatDoNotOverlap);
      bunchOfLetters.HasAtLeastOnLetterPairWithExactlyOneLetterBetweenThem.Should().Be(shouldHaveAtLeastOnLetterPairWithExactlyOneLetterBetweenThem);
      bunchOfLetters.IsNice.Should().Be(shouldHaveAtLeastTwoIdenticalLetterPairsThatDoNotOverlap && shouldHaveAtLeastOnLetterPairWithExactlyOneLetterBetweenThem);
    }
  }
}