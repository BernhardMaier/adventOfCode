using System.Diagnostics;
using AoC.Backend.Extensions;
using AoC.SharedKernel.Contracts;
using AoC.SharedKernel.Interfaces;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace AoC.Backend;

public class Worker(
  IPuzzleSolverFactory puzzleSolverFactory,
  ILogger<Worker> logger,
  IHost host) : BackgroundService
{
  protected override Task ExecuteAsync(CancellationToken stoppingToken)
  {
    PuzzleIdentifier[] puzzles =
    [
      new (2015, 5, 2),
    ];

    var stopwatch = new Stopwatch();
    stopwatch.Start();
    puzzleSolverFactory.Solve(puzzles).PrintWith(Log);
    stopwatch.Stop();
    logger.LogInformation("Duration: {Duration}", stopwatch.Elapsed);
    
    return host.StopAsync(stoppingToken);
  }
  
  private void Log(string message) => logger.LogInformation("{Message}", message);
}