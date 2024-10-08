using AoC.Backend.Services;
using AoC.SharedKernel.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace AoC.Backend.Extensions;

public static class ServiceProviderExtensions
{
  public static IServiceCollection AddAdventOfCodeServices(this IServiceCollection services) =>
    services
      .AddSingleton<IInputProvider, FileBasedInputProvider>()
      .AddSingleton<IPuzzleSolverFactory, PuzzleSolverFactory>();
}