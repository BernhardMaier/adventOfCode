using AoC.SharedKernel.Contracts;
using AoC.SharedKernel.Interfaces;
using CSharpFunctionalExtensions;

namespace AoC.SharedKernel;

public abstract class BasePuzzleSolver(IInputProvider inputProvider) : IPuzzleSolver
{
  private PuzzleIdentifier? _puzzleIdentifier;
  private PuzzleIdentifier PuzzleIdentifier => _puzzleIdentifier ??= Result.Success(GetType().Name)
    .Map(typeName => typeName.Replace("PuzzleSolverFor", ""))
    .Map(s => new PuzzleIdentifier(
      int.Parse(s[..4]),
      int.Parse(s.Substring(4, 2)),
      int.Parse(s.Substring(6, 2))))
    .Finally(result => result.IsFailure
      ? throw new Exception($"Puzzle identifier could not be created: {result}")
      : result.Value);

  public PuzzleResult Solve() =>
    inputProvider.GetInput(PuzzleIdentifier).Map(Solve).Finally(MapToPuzzleResult);

  public Task<PuzzleResult> SolveAsync() =>
    inputProvider.GetInputAsync(PuzzleIdentifier).Map(Solve).Finally(MapToPuzzleResult);
  
  private PuzzleResult MapToPuzzleResult(Result<string> result) =>
    new(PuzzleIdentifier, result);

  protected abstract string Solve(string input);
}