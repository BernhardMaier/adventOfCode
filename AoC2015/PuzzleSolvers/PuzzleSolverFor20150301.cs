using AoC.SharedKernel;
using AoC.SharedKernel.Interfaces;

namespace AoC2015.PuzzleSolvers;

// ReSharper disable once UnusedType.Global
public class PuzzleSolverFor20150301(IInputProvider inputProvider)
  : BasePuzzleSolver(inputProvider)
{
  protected override string Solve(string input)
  {
    var houses = new Dictionary<(int x, int y), int>();
    var currentPosition = (0, 0);
    
    houses[currentPosition] = 1;

    foreach (var direction in input)
    {
      currentPosition = direction switch
      {
        '^' => (currentPosition.Item1, currentPosition.Item2 + 1),
        '>' => (currentPosition.Item1 + 1, currentPosition.Item2),
        'v' => (currentPosition.Item1, currentPosition.Item2 - 1),
        '<' => (currentPosition.Item1 - 1, currentPosition.Item2),
        _ => throw new ArgumentException($"Invalid direction: {direction}")
      };
      
      houses.TryAdd(currentPosition, 0);
      houses[currentPosition] += 1;
    }
    
    return houses.Keys.Count.ToString();
  }
}