using AoC.SharedKernel.Contracts;

namespace AoC.Backend.Extensions;

public static class PuzzleResultExtensions
{
  public static void PrintWith(this IEnumerable<PuzzleResult> results, Action<string> printAction) =>
    results.ToList().ForEach(result => result.PrintWith(printAction));

  public static void PrintWith(this PuzzleResult result, Action<string> printAction) =>
    printAction(result.GetStringToPrint());

  private static string GetStringToPrint(this PuzzleResult result) =>
    $"{result.Id.Year}/{result.Id.Day}/{result.Id.Part}: {(result.Result.IsSuccess
      ? result.Result.Value : result.Result.Error)}";
}