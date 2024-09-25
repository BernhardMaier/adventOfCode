using CSharpFunctionalExtensions;

namespace AoC.Backend.Extensions;

public static class ResultExtensions
{
  public static void PrintResultWith(this Result<string> result, Action<string> printAction) =>
    printAction(result.IsSuccess ? result.Value : result.Error);
}