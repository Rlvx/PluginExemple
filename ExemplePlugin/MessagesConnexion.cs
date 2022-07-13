using Rocket.Unturned.Chat;
using Rocket.Unturned.Player;

namespace ExemplePlugin
{
    public class MessagesConnexion
    {
        public static void Events_OnPlayerConnected(UnturnedPlayer player)
        {
            player.Events.OnUpdateGesture += Destroy.Events_OnPlayerGesture;
            UnturnedChat.Say($"{player.CharacterName} s'est connecté !");
        }

        public static void Events_OnPlayerDisconnected(UnturnedPlayer player)
        {
            UnturnedChat.Say($"{player.CharacterName} s'est déconnecté !");
        }
    }
}