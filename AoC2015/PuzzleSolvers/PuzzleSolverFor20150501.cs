using AoC.SharedKernel;
using AoC.SharedKernel.Interfaces;

namespace AoC2015.PuzzleSolvers;

// ReSharper disable once UnusedType.Global
public class PuzzleSolverFor20150501(IInputProvider inputProvider)
  : BasePuzzleSolver(inputProvider)
{
  protected override string Solve(string input) =>
    input
      .ToLower()
      .Split("\r\n")
      .Count(text => text.IsNice())
      .ToString();
}

public static class ExtensionsFor20150501
{
  public static bool IsNice(this string s) =>
    s.HasAtLeastThreeVowels() &&
    s.HasAtLeastOneLetterThatAppearsTwiceInARow() &&
    s.HasNoForbiddenSubstrings();

  public static bool HasAtLeastThreeVowels(this string s) =>
    s.ToCharArray().Count(c => c is 'a' or 'e' or 'i' or 'o' or 'u') >= 3;

  public static bool HasAtLeastOneLetterThatAppearsTwiceInARow(this string s) =>
    s
      .ToCharArray()
      .Aggregate((List: new List<(string, string)>(), Previous: string.Empty), (state, current) =>
        (state.List.AddValue((state.Previous, current.ToString())), current.ToString()))
      .List
      .Any(pair => pair.Item1 == pair.Item2);

  public static bool HasNoForbiddenSubstrings(this string s) =>
    !(s.Contains("ab") || s.Contains("cd") || s.Contains("pq") || s.Contains("xy"));

  public static List<(string, string)> AddValue(this List<(string, string)> list, (string, string) value)
  {
    list.Add(value);
    return list;
  }
}