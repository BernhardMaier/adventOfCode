using AoC.SharedKernel.Contracts;
using CSharpFunctionalExtensions;

namespace AoC.SharedKernel.Interfaces;

public interface IInputProvider
{
  Result<string> GetInput(PuzzleIdentifier puzzleIdentifier);
  Task<Result<string>> GetInputAsync(PuzzleIdentifier puzzleIdentifier);
}