using AoC.SharedKernel.Contracts;
using CSharpFunctionalExtensions;

namespace AoC.SharedKernel.Interfaces;

public interface IProblemSolver
{
  PuzzleResult Solve();
  Task<PuzzleResult> SolveAsync();
}