using AoC.SharedKernel.Contracts;
using AoC.SharedKernel.Interfaces;
using CSharpFunctionalExtensions;

namespace AoC.SharedKernel;

public abstract class BaseProblemSolver(IInputProvider inputProvider) : IProblemSolver
{
  protected abstract PuzzleIdentifier PuzzleIdentifier { get; }
  
  public Result<string> Solve() =>
    inputProvider.GetInput(PuzzleIdentifier).Map(Solve);
  
  public Task<Result<string>> SolveAsync() =>
    inputProvider.GetInputAsync(PuzzleIdentifier).Map(Solve);
  
  protected abstract string Solve(string input);
}