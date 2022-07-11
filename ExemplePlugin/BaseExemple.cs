using System;
using Org.BouncyCastle.Math.EC;
using Rocket.Core.Plugins;
using Logger = Rocket.Core.Logging.Logger;

using Random = System.Random;

namespace ExemplePlugin
{
  public class Base : RocketPlugin
  {
    public static Base Instance;
    
    protected override void Load()
    {
      Logger.Log("#################################################################",ConsoleColor.Magenta);
      Logger.Log("######################    Test Plugin    ########################",ConsoleColor.Magenta);
      Logger.Log("#################################################################",ConsoleColor.Magenta);
      Logger.Log("",ConsoleColor.Magenta);
      Logger.Log("V1.0",ConsoleColor.Magenta);
      Logger.Log("Plugin by Rom",ConsoleColor.Magenta);
      Logger.Log("Sucessfuly Load Test Plugin",ConsoleColor.Green);
    }
  }
}