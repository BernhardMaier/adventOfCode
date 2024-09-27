using CSharpFunctionalExtensions;

namespace AoC.SharedKernel.Contracts;

public record PuzzleResult(PuzzleIdentifier Id, Result<string> Result);