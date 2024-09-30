using AoC.SharedKernel;
using AoC.SharedKernel.Interfaces;

namespace AoC2015.PuzzleSolvers;

// ReSharper disable once UnusedType.Global
public class PuzzleSolverFor20150102(IInputProvider inputProvider)
  : BasePuzzleSolver(inputProvider)
{
  protected override string Solve(string input)
  {
    var ups = 0;
    var downs = 0;
    for (var i = 0; i < input.Length; i++)
    {
      if (input[i] == '(') ups++;
      if (input[i] == ')') downs++;
      if (ups - downs == -1) return (i + 1).ToString();
    }
    return "ERROR";
  }
}