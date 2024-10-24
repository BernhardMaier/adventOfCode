using System.Text.RegularExpressions;
using AoC.SharedKernel;
using AoC.SharedKernel.Interfaces;

namespace AoC2015.PuzzleSolvers;

// ReSharper disable once UnusedType.Global
public class PuzzleSolverFor20150502(IInputProvider inputProvider)
  : BasePuzzleSolver(inputProvider)
{
  protected override string Solve(string input) =>
    input
      .ToLower()
      .Split("\r\n")
      //.Count(text => BunchOfLetters.GetFrom(text).IsNice)
      .Count(text => text.IsNiceFromAi())
      .ToString();
  
  public class BunchOfLetters
  {
    private readonly char[] _letters;

    private IEnumerable<IGrouping<LetterPair, LetterPair>>? _groupedPairs;
    private IEnumerable<IGrouping<LetterPair, LetterPair>> GroupedPairs => _groupedPairs ??= Pairs.GroupBy(x => x);
    
    private IReadOnlyCollection<LetterPair>? _pairs;
    private IReadOnlyCollection<LetterPair> Pairs => _pairs ??= _letters
      .Aggregate((List: new List<(string, string)>(), Previous: string.Empty), (state, current) =>
        (state.List.Concat([(state.Previous, current.ToString())]).ToList(), current.ToString()))
      .List
      .Select(tuple => new LetterPair(tuple.Item1, tuple.Item2))
      .ToList();
    
    private IReadOnlyCollection<LetterTriple>? _triples;
    private IReadOnlyCollection<LetterTriple> Triples => _triples ??= _letters
      .Aggregate((List: new List<(string, string, string)>(), Previous: string.Empty, PrePrevious: string.Empty), (state, current) =>
        (state.List.Concat([(state.PrePrevious, state.Previous, current.ToString())]).ToList(), current.ToString(), state.Previous))
      .List
      .Select(tuple => new LetterTriple(tuple.Item1, tuple.Item2, tuple.Item3))
      .ToList();

    private BunchOfLetters(string s) => _letters = s.ToCharArray();
    
    public static BunchOfLetters GetFrom(string s) => new(s);

    public bool IsNice =>
      HasAtLeastTwoIdenticalLetterPairsThatDoNotOverlap &&
      HasAtLeastOnLetterPairWithExactlyOneLetterBetweenThem;

    public bool HasAtLeastTwoIdenticalLetterPairsThatDoNotOverlap => GroupedPairs
      .Any(grouping => grouping.Count() > 1) && Triples.All(triple => triple.HasDifferentLetters);

    public bool HasAtLeastOnLetterPairWithExactlyOneLetterBetweenThem => Triples
      .Any(triple => triple.IsALetterPairWithExactlyOneLetterBetweenThem);
  }

  private record LetterPair(string First, string Second);

  private record LetterTriple(string First, string Second, string Third)
  {
    public bool HasDifferentLetters => First != Second || Second != Third;
    public bool IsALetterPairWithExactlyOneLetterBetweenThem => First == Third;
  }
}

public static class ExtensionsFor20150502
{
  public static bool IsNiceFromAi(this string str)
  {
    var hasPair = Regex.IsMatch(str, @"(..).*\1");
    var hasRepeatWithOneBetween = Regex.IsMatch(str, @"(.).\1");

    return hasPair && hasRepeatWithOneBetween;
  }
}
