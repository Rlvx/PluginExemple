

using System.Collections.Generic;
using Rocket.API;
using Rocket.Unturned.Chat;
using Rocket.Unturned.Player;
using SDG.Unturned;
using UnityEngine;

namespace TextEffect
{
    public class Freeze : IRocketCommand
    {
        public AllowedCaller AllowedCaller
        {
            get { return AllowedCaller.Player; }
        }
        public string Name
        {
            get { return "speed"; }
        }
        public string Help
        {
            get { return "test"; }
        }
        public string Syntax
        {
            get { return "/speed"; }
        }
        public List<string> Aliases
        {
            get { return new List<string>(); }
        }
        public List<string> Permissions
        {
            get
            {
                return new List<string>();
            }
        }
        
        public void Execute(IRocketPlayer caller, params string[] command)
        {
            
            UnturnedPlayer player = (UnturnedPlayer) caller;
            
            if (command.Length != 1)
            {
                UnturnedChat.Say(caller,"Syntaxe : /speed [speed]",Color.magenta);
                return;
            }
            
            if (!float.TryParse(command[0], out float speed))
            {
                UnturnedChat.Say(caller,"argument doit être un flottant",Color.magenta);
                return;
            }
            
            foreach (var VARIABLE in Provider.clients)
            {
                UnturnedPlayer loop_player = UnturnedPlayer.FromSteamPlayer(VARIABLE);
                loop_player.Player.movement.sendPluginSpeedMultiplier(speed);
            }
        }
    }
}