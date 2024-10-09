using AoC.SharedKernel;
using AoC.SharedKernel.Interfaces;

namespace AoC2015.PuzzleSolvers;

// ReSharper disable once UnusedType.Global
public class PuzzleSolverFor20150302(IInputProvider inputProvider)
  : BasePuzzleSolver(inputProvider)
{
  protected override string Solve(string input)
  {
    var houses = new Dictionary<(int x, int y), int>();
    var initialPosition = (0, 0);
    houses[initialPosition] = 2;

    var currentSantaPosition = initialPosition;
    var currentRoboPosition = initialPosition;
    var turnCounter = 0;
    
    foreach (var direction in input)
    {
      if (++turnCounter % 2 == 1)
        currentSantaPosition = ProcessDirectionInstruction(currentSantaPosition, direction, houses);
      else
        currentRoboPosition = ProcessDirectionInstruction(currentRoboPosition, direction, houses);
    }
    
    return houses.Keys.Count.ToString();
  }

  private static (int, int) ProcessDirectionInstruction((int, int) currentPosition, char direction, Dictionary<(int x, int y), int> houses)
  {
    var newPosition = direction switch
    {
      '^' => (currentPosition.Item1, currentPosition.Item2 + 1),
      '>' => (currentPosition.Item1 + 1, currentPosition.Item2),
      'v' => (currentPosition.Item1, currentPosition.Item2 - 1),
      '<' => (currentPosition.Item1 - 1, currentPosition.Item2),
      _ => throw new ArgumentException($"Invalid direction: {direction}")
    };
      
    houses.TryAdd(newPosition, 0);
    houses[newPosition] += 1;
    
    return newPosition;
  }
}