using AoC.SharedKernel;
using AoC.SharedKernel.Interfaces;

namespace AoC2015.ProblemSolvers;

// ReSharper disable once UnusedType.Global
public class ProblemSolverFor20150201(IInputProvider inputProvider)
  : BaseProblemSolver(inputProvider)
{
  protected override string Solve(string input) =>
    input
      .Split("\r\n")
      .Select(dimensions => dimensions
        .Split("x")
        .Select(int.Parse)
        .ToArray())
      .Select(dimensions => new Present(dimensions).RequiredPaper)
      .Sum()
      .ToString();

  private class Present(int[] dimensions)
  {
    private readonly int[] _areas =
    [
      dimensions[0]*dimensions[1],
      dimensions[1]*dimensions[2],
      dimensions[2]*dimensions[0]
    ];
    
    private int Slack => _areas.Order().First();
    private int SurfaceArea => 2 * _areas.Sum();
    public int RequiredPaper => SurfaceArea + Slack;
  }
}