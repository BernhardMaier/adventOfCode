using AoC.SharedKernel.Contracts;

namespace AoC.SharedKernel.Interfaces;

public interface IPuzzleSolver
{
  PuzzleResult Solve();
  Task<PuzzleResult> SolveAsync();
}