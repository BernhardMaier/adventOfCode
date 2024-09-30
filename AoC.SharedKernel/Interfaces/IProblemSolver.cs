using AoC.SharedKernel.Contracts;

namespace AoC.SharedKernel.Interfaces;

public interface IProblemSolver
{
  PuzzleResult Solve();
  Task<PuzzleResult> SolveAsync();
}