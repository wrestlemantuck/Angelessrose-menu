using ExitGames.Client.Photon;
using GorillaTagScripts;
using Photon.Pun;
using UnityEngine;
using static StupidTemplate.Settings;
using static StupidTemplate.Menu.Main;
using BepInEx;
using StupidTemplate.Notifications;
using GorillaNetworking;
using Photon.Realtime;

namespace StupidTemplate.Mods
{
    internal class Saftey
    {
        public static void EnterSaftey()
        {
            buttonsType = 9;
        }
        public static void AntiReport()
        {
            try
            {
                foreach (GorillaPlayerScoreboardLine line in GorillaScoreboardTotalUpdater.allScoreboardLines)
                {
                    if (line.linePlayer == NetworkSystem.Instance.LocalPlayer)
                    {
                        Transform report = line.reportButton.gameObject.transform;

                        foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
                        {
                            if (vrrig != GorillaTagger.Instance.offlineVRRig)
                            {
                                float distanceRight = Vector3.Distance(vrrig.rightHandTransform.position, report.position);
                                float distanceLeft = Vector3.Distance(vrrig.leftHandTransform.position, report.position);

                                if (distanceRight < 0.5f || distanceLeft < 0.5f)
                                {
                                    PhotonNetwork.Disconnect();
                                    NotifiLib.SendNotification("[ANTI-REPORT] Someone attempted to report you.");
                                }
                            }
                        }
                    }
                }
            }
            catch
            {
                NotifiLib.SendNotification("Error enabling anti report, Are you in a lobby?");
            }
        }
        public static void NoFingerMovement()
        {
            ControllerInputPoller.instance.leftControllerGripFloat = 0f;
            ControllerInputPoller.instance.rightControllerGripFloat = 0f;
            ControllerInputPoller.instance.leftControllerIndexFloat = 0f;
            ControllerInputPoller.instance.rightControllerIndexFloat = 0f;
            ControllerInputPoller.instance.leftControllerPrimaryButton = false;
            ControllerInputPoller.instance.leftControllerSecondaryButton = false;
            ControllerInputPoller.instance.rightControllerPrimaryButton = false;
            ControllerInputPoller.instance.rightControllerSecondaryButton = false;
            ControllerInputPoller.instance.leftControllerPrimaryButtonTouch = false;
            ControllerInputPoller.instance.leftControllerSecondaryButtonTouch = false;
            ControllerInputPoller.instance.rightControllerPrimaryButtonTouch = false;
            ControllerInputPoller.instance.rightControllerSecondaryButtonTouch = false;
        }
        public static void SpoofName()
        {
            string[] names = new string[]
{
            "SHIBAGT", "PBBV", "J3VU", "BEES", "NAMO", "MANGO",
            "FROSTY", "FRISH", "LITTLETIMMY", "SILLYBILLY", "TIMMY",
            "MINIGAMES", "JMANCURLY", "VMT", "ELLIOT", "POLAR",
            "GORILLAGT", "MONKE", "DUCKY", "EDDIE", "SKETCH",
            "gorilla9261", "GORILLA", "MONKE", "IDK", "DAISY09",
            "ILOVEGTAG", "IAIOGMPA", "99OFPMS", "PMUDSP", "WQY90SMS",
            "9IWMGO", "19DMSOPYP", "OAMGIPAD", "IAMGORILLA", "HAHA",
            "JUKED", "RANDOMGUY"
};

            string pickedname = names[Random.Range(0, names.Length)];

            PhotonNetwork.LocalPlayer.NickName = pickedname;
            GorillaComputer.instance.currentName = pickedname;
            GorillaComputer.instance.savedName = pickedname;
            PlayerPrefs.SetString("GorillaLocomotion.PlayerName", pickedname);
            PlayerPrefs.Save();
            NotifiLib.SendNotification("<color=green>[SPOOF NAME] SUCCESSFULLY SPOOFED NAME</color>");
        }
        public static void SpamSpoofName()
        {
            string[] names = new string[]
{
            "SHIBAGT", "PBBV", "J3VU", "BEES", "NAMO", "MANGO",
            "FROSTY", "FRISH", "LITTLETIMMY", "SILLYBILLY", "TIMMY",
            "MINIGAMES", "JMANCURLY", "VMT", "ELLIOT", "POLAR",
            "GORILLAGT", "MONKE", "DUCKY", "EDDIE", "SKETCH",
            "gorilla9261", "GORILLA", "MONKE", "IDK", "DAISY09",
            "ILOVEGTAG", "IAIOGMPA", "99OFPMS", "PMUDSP", "WQY90SMS",
            "9IWMGO", "19DMSOPYP", "OAMGIPAD", "IAMGORILLA", "HAHA",
            "JUKED", "RANDOMGUY"
};

            string pickedname = names[Random.Range(0, names.Length)];

            PhotonNetwork.LocalPlayer.NickName = pickedname;
            GorillaComputer.instance.currentName = pickedname;
            GorillaComputer.instance.savedName = pickedname;
            PlayerPrefs.SetString("GorillaLocomotion.PlayerName", pickedname);
            PlayerPrefs.Save();
            NotifiLib.SendNotification("<color=green>[SPAM SPOOF NAME] SUCCESSFULLY SPOOFED NAME (RECOMMEND TURNING OFF NOTIFS)</color>");
        }
        public static void Reconnect()
        {
            if (PhotonNetwork.InRoom)
            {
                string roomName = PhotonNetwork.CurrentRoom.Name;
                PhotonNetwork.Disconnect();

                while (PhotonNetwork.IsConnected)
                    System.Threading.Thread.Sleep(100);

                PhotonNetwork.ConnectUsingSettings();

                while (!PhotonNetwork.IsConnectedAndReady)
                    System.Threading.Thread.Sleep(100);

                PhotonNetwork.JoinRoom(roomName);
            }
        }
    }
}
