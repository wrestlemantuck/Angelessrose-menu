using ExitGames.Client.Photon;
using GorillaTagScripts;
using Photon.Pun;
using UnityEngine;
using static StupidTemplate.Settings;
using static StupidTemplate.Menu.Main;
using BepInEx;
using StupidTemplate.Notifications;
using System.Threading.Tasks;
using GorillaNetworking;

namespace StupidTemplate.Mods
{
    internal class Other
    {
    public static void EnterOther()
    {
        buttonsType = 12;
    }
    public static void JoinRandomLobby()
    {
        if (PhotonNetwork.InRoom)
        {
            PhotonNetwork.LeaveRoom();
        }

        PhotonNetwork.JoinRandomRoom();
    }
    }
}