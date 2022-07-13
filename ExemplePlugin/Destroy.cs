using System;
using Rocket.Unturned.Chat;
using Rocket.Unturned.Events;
using Rocket.Unturned.Player;
using SDG.Framework.Utilities;
using SDG.Unturned;
using UnityEngine;

namespace ExemplePlugin
{
    public class Destroy
    {
        public static void Events_OnPlayerGesture(UnturnedPlayer player, UnturnedPlayerEvents.PlayerGesture gesture)
        {
            switch (gesture)
            {
                case UnturnedPlayerEvents.PlayerGesture.PunchLeft:
                    if (PhysicsUtility.raycast(new Ray(player.Player.look.aim.position, player.Player.look.aim.forward), out RaycastHit hit, Mathf.Infinity, RayMasks.BARRICADE_INTERACT))
                    {
                        BarricadeManager.damage(hit.transform,100,100,false);
                    }else
                    {
                        UnturnedChat.Say(player.CSteamID,"rien en face de toi",Color.red);
                    }
                    
                    if (PhysicsUtility.raycast(new Ray(player.Player.look.aim.position, player.Player.look.aim.forward), out RaycastHit hit_vehicle, Mathf.Infinity, RayMasks.VEHICLE))
                    {
                        if (hit_vehicle.transform.TryGetComponent(out InteractableVehicle v))
                        {
                            UnturnedChat.Say(player,"[-] Destroy vehicle");
                            VehicleManager.askVehicleDestroy(v);
                        }
                        else
                        {
                            UnturnedChat.Say(player,"[-] No vehicle detect");
                        }
                    }else
                    {
                        UnturnedChat.Say(player.CSteamID,"rien en face de toi",Color.red);
                    }
                    break;
                 
                    
            }
        }
    }
}