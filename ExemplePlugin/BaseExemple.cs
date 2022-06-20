using System;
using System.Collections;
using Rocket.Core.Plugins;
using Logger = Rocket.Core.Logging.Logger;
using Rocket.Unturned;
using Rocket.Unturned.Chat;
using Rocket.Unturned.Player;
using Color = UnityEngine.Color;
using SDG.Unturned;
using UnityEngine;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Threading;
using System.Timers;
using Rocket.API;
using Rocket.Unturned.Commands;
using Rocket.Unturned.Enumerations;
using Rocket.Unturned.Events;
using Steamworks;
using SDG.Framework.Utilities;
using UnityEngine.UI;
using Random = System.Random;

namespace ExemplePlugin
{
  public class Class1
  {
    protected void Load()
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