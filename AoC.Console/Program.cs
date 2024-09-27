using AoC.Backend.Extensions;
using AoC.SharedKernel.Contracts;

PuzzleIdentifier[] puzzles =
[
  new (2015, 1, 1),
  new (2015, 1, 2),
];

puzzles.Solve().PrintWith(Console.WriteLine);
//Console.ReadLine();