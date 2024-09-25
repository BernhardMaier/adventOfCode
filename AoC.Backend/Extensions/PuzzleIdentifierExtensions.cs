using AoC.SharedKernel.Contracts;
using CSharpFunctionalExtensions;

namespace AoC.Backend.Extensions;

public static class PuzzleIdentifierExtensions
{
  public static Result<string> Solve(this PuzzleIdentifier puzzleIdentifier) =>
    new ProblemSolverFactory(new FileBasedInputProvider()).Create(puzzleIdentifier).Solve();
}