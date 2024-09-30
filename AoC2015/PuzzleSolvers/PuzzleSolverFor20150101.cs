using AoC.SharedKernel;
using AoC.SharedKernel.Interfaces;

namespace AoC2015.PuzzleSolvers;

// ReSharper disable once UnusedType.Global
public class PuzzleSolverFor20150101(IInputProvider inputProvider)
  : BasePuzzleSolver(inputProvider)
{
  protected override string Solve(string input)
  {
    var ups = input.Count(c => c == '(');
    var downs = input.Count(c => c == ')');
    return (ups-downs).ToString();
  }
}