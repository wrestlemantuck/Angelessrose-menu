using Photon.Pun;
using StupidTemplate.Notifications;
using static StupidTemplate.Menu.Main;

namespace StupidTemplate.Mods
{
    internal class Global
    {
        public static void ReturnHome()
        {
            buttonsType = 0;
        }
        public static void FlushRPCS()
        {
            NotifiLib.SendNotification("Not working yet");
        }
    }
}
