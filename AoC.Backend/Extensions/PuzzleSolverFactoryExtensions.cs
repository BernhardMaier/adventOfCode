using AoC.SharedKernel.Contracts;
using AoC.SharedKernel.Interfaces;

namespace AoC.Backend.Extensions;

public static class PuzzleSolverFactoryExtensions
{
  public static PuzzleResult Solve(this IPuzzleSolverFactory puzzleSolverFactory, PuzzleIdentifier puzzleIdentifier) =>
    puzzleSolverFactory.CreatePuzzleSolver(puzzleIdentifier).Solve();
  
  public static IEnumerable<PuzzleResult> Solve(this IPuzzleSolverFactory puzzleSolverFactory, IEnumerable<PuzzleIdentifier> puzzleIdentifiers) =>
    puzzleIdentifiers.Select(puzzleSolverFactory.Solve);
}