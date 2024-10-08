using AoC.Backend;
using AoC.Backend.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

Host.CreateDefaultBuilder(args)
  .ConfigureServices((_, services) => services
    .AddHostedService<Worker>()
    .AddAdventOfCodeServices())
  .Build()
  .Run();