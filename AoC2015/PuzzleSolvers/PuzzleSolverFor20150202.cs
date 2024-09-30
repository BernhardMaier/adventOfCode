using AoC.SharedKernel;
using AoC.SharedKernel.Interfaces;

namespace AoC2015.PuzzleSolvers;

// ReSharper disable once UnusedType.Global
public class PuzzleSolverFor20150202(IInputProvider inputProvider)
  : BasePuzzleSolver(inputProvider)
{
  protected override string Solve(string input) =>
    input
      .Split("\r\n")
      .Select(dimensions => dimensions
        .Split("x")
        .Select(int.Parse)
        .ToArray())
      .Select(dimensions => new Present(dimensions).RequiredRibbon)
      .Sum()
      .ToString();

  private class Present(int[] dimensions)
  {
    private int RibbonForWrapping => dimensions.Order().Take(2).Select(x => 2*x).Sum();
    private int RibbonForBow => dimensions.Aggregate(1, (a, b) => a * b);
    public int RequiredRibbon => RibbonForWrapping + RibbonForBow;
  }
}