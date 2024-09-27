using AoC.SharedKernel.Contracts;
using AoC.SharedKernel.Interfaces;
using CSharpFunctionalExtensions;

namespace AoC.SharedKernel;

public abstract class BaseProblemSolver(IInputProvider inputProvider) : IProblemSolver
{
  protected abstract PuzzleIdentifier PuzzleIdentifier { get; }
  
  public PuzzleResult Solve() =>
    inputProvider.GetInput(PuzzleIdentifier).Map(Solve).Finally(MapToPuzzleResult);

  public Task<PuzzleResult> SolveAsync() =>
    inputProvider.GetInputAsync(PuzzleIdentifier).Map(Solve).Finally(MapToPuzzleResult);
  
  private PuzzleResult MapToPuzzleResult(Result<string> result) =>
    new(PuzzleIdentifier, result);

  protected abstract string Solve(string input);
}