using AoC.Backend.Extensions;
using AoC.SharedKernel.Contracts;

var result = new PuzzleIdentifier(2015, 1, 2).Solve();
Console.WriteLine(result.IsSuccess ? result.Value : result.Error);
//Console.ReadLine();