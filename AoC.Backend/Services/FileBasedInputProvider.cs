using AoC.SharedKernel.Contracts;
using AoC.SharedKernel.Interfaces;
using CSharpFunctionalExtensions;

namespace AoC.Backend.Services;

public class FileBasedInputProvider : IInputProvider
{
  public Result<string> GetInput(PuzzleIdentifier puzzleIdentifier)
  {
    try
    {
      return GetFilePathFor(puzzleIdentifier)
        .Map(File.ReadAllText);
    }
    catch (Exception e)
    {
      return Result.Failure<string>(e.Message);
    }
  }

  public async Task<Result<string>> GetInputAsync(PuzzleIdentifier puzzleIdentifier)
  {
    try
    {
      return await GetFilePathFor(puzzleIdentifier)
        .Map(async filePath => await File.ReadAllTextAsync(filePath));
    }
    catch (Exception e)
    {
      return Result.Failure<string>(e.Message);
    }
  }

  private static Result<string> GetFilePathFor(PuzzleIdentifier puzzleIdentifier)
  {
    var fileName = $"{puzzleIdentifier.Year:0000}_{puzzleIdentifier.Day:00}.txt";
    var filePath = Path.Combine(Environment.CurrentDirectory, "InputFiles", fileName);

    return filePath;
  }
}