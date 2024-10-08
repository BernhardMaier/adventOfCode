using AoC.SharedKernel.Contracts;

namespace AoC.SharedKernel.Interfaces;

public interface IPuzzleSolverFactory
{
  IPuzzleSolver CreatePuzzleSolver(PuzzleIdentifier puzzleIdentifier);
}