using CSharpFunctionalExtensions;

namespace AoC.SharedKernel.Interfaces;

public interface IProblemSolver
{
  Result<string> Solve();
  Task<Result<string>> SolveAsync();
}