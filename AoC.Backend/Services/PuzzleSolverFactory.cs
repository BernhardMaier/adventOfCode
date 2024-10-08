using System.Reflection;
using AoC.SharedKernel.Contracts;
using AoC.SharedKernel.Interfaces;

namespace AoC.Backend.Services;

public class PuzzleSolverFactory(IInputProvider inputProvider) : IPuzzleSolverFactory
{
  public IPuzzleSolver CreatePuzzleSolver(PuzzleIdentifier puzzleIdentifier) =>
    CreatePuzzleSolver(puzzleIdentifier.Year, puzzleIdentifier.Day, puzzleIdentifier.Part);

  private IPuzzleSolver CreatePuzzleSolver(int year, int day, int part)
  {
    var suffix = $"{year:0000}{day:00}{part:00}";
    var typeName = $"AoC{year:0000}.PuzzleSolvers.PuzzleSolverFor{suffix}";
    var type = GetTypeByName(typeName);
    
    if (type == null)
      throw new InvalidOperationException($"Puzzle solver for {suffix} not found.");
    
    if (!typeof(IPuzzleSolver).IsAssignableFrom(type))
      throw new InvalidOperationException($"Puzzle solver for {suffix} is not assignable to IPuzzleSolver.");

    return (IPuzzleSolver)Activator.CreateInstance(type, inputProvider)!;
  }
  
  private static Type? GetTypeByName(string typeName)
  {
    var loadedAssemblies = AppDomain.CurrentDomain.GetAssemblies().ToList();
    var loadedPaths = loadedAssemblies.Select(a => a.Location);
    return loadedAssemblies
      .Concat(Directory
        .GetFiles(AppDomain.CurrentDomain.BaseDirectory, "*.dll")
        .Where(path => !loadedPaths.Contains(path, StringComparer.InvariantCultureIgnoreCase))
        .Select(path => AppDomain.CurrentDomain.Load(AssemblyName.GetAssemblyName(path))))
      .SelectMany(assembly => assembly.GetTypes())
      .FirstOrDefault(t => t.FullName == typeName);
  }
}