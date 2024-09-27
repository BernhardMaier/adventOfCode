using AoC.SharedKernel.Contracts;

namespace AoC.Backend.Extensions;

public static class PuzzleIdentifierExtensions
{
  public static PuzzleResult Solve(this PuzzleIdentifier puzzleIdentifier) =>
    new ProblemSolverFactory(new FileBasedInputProvider()).Create(puzzleIdentifier).Solve();
  
  public static IEnumerable<PuzzleResult> Solve(this IEnumerable<PuzzleIdentifier> puzzleIdentifiers) =>
    puzzleIdentifiers.Select(id => id.Solve());
}