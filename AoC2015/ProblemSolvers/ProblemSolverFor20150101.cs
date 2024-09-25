using AoC.SharedKernel;
using AoC.SharedKernel.Contracts;
using AoC.SharedKernel.Interfaces;

namespace AoC2015.ProblemSolvers;

// ReSharper disable once UnusedType.Global
public class ProblemSolverFor20150101(IInputProvider inputProvider)
  : BaseProblemSolver(inputProvider)
{
  protected override PuzzleIdentifier PuzzleIdentifier => new(2015, 1, 1);

  protected override string Solve(string input)
  {
    var ups = input.Count(c => c == '(');
    var downs = input.Count(c => c == ')');
    return (ups-downs).ToString();
  }
}