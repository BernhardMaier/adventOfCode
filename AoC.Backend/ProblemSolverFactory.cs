using System.Reflection;
using AoC.SharedKernel.Contracts;
using AoC.SharedKernel.Interfaces;

namespace AoC.Backend;

public class ProblemSolverFactory(IInputProvider inputProvider)
{
  public IProblemSolver Create(PuzzleIdentifier puzzleIdentifier) =>
    Create(puzzleIdentifier.Year, puzzleIdentifier.Day, puzzleIdentifier.Part);

  private IProblemSolver Create(int year, int day, int part)
  {
    var suffix = $"{year:0000}{day:00}{part:00}";
    var typeName = $"AoC{year:0000}.ProblemSolvers.ProblemSolverFor{suffix}";
    var type = GetTypeByName(typeName);
    
    if (type == null)
      throw new InvalidOperationException($"Problem solver for {suffix} not found.");
    
    if (!typeof(IProblemSolver).IsAssignableFrom(type))
      throw new InvalidOperationException($"Problem solver for {suffix} is not assignable to IProblemSolver.");

    return (IProblemSolver)Activator.CreateInstance(type, inputProvider)!;
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