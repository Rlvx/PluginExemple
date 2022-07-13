using Rocket.Unturned.Chat;
using Rocket.Unturned.Player;
using SDG.Unturned;
using UnityEngine;

namespace ExemplePlugin
{
    public class Tazer
    {
        public static void Test()
        {
            UnturnedChat.Say("oui");
        }
        
        public static void Events_OnPlayerAllowedToDamagePlayer(Player instigator, Player victim, ref bool isallowed)
        {
            UnturnedPlayer attaquant = UnturnedPlayer.FromPlayer(instigator);
            UnturnedPlayer victime = UnturnedPlayer.FromPlayer(victim);

            if (attaquant.Player.equipment.itemID == 43378)
            {
                isallowed = false;
                victime.Player.life.serverModifyHallucination(1);
                victime.Player.animator.sendGesture(EPlayerGesture.ARREST_START,true);
                UnturnedChat.Say(victime,"Vous avez été arrêté",Color.red);
                
                //c'est un tazer
            }
            else
            {
                //ce n'est pas un tazer
            }
        }
    }
}