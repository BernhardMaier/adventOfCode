﻿using AoC.Backend.Extensions;
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
      new (2015, 1, 1),
      new (2015, 1, 2),
      new (2015, 2, 1),
      new (2015, 2, 2),
    ];

    puzzleSolverFactory.Solve(puzzles).PrintWith(Log);
    
    return host.StopAsync(stoppingToken);
  }
  
  private void Log(string message) => logger.LogInformation("{Message}", message);
}