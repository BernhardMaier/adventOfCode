using System.Security.Cryptography;
using System.Text;
using AoC.SharedKernel;
using AoC.SharedKernel.Interfaces;

namespace AoC2015.PuzzleSolvers;

// ReSharper disable once UnusedType.Global
public class PuzzleSolverFor20150401(IInputProvider inputProvider)
  : BasePuzzleSolver(inputProvider)
{
  protected override string Solve(string input)
  {
    var suffix = -1;
    while (++suffix <= 1000000000)
    {
      var md5Hash = Convert.ToHexString(MD5.HashData(Encoding.ASCII.GetBytes($"{input}{suffix}")));
      if (md5Hash.StartsWith("00000"))
        return suffix.ToString();
    }
    return "ERROR";
  }
}