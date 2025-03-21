using ExitGames.Client.Photon;
using GorillaTagScripts;
using Photon.Pun;
using UnityEngine;
using static StupidTemplate.Settings;
using static StupidTemplate.Menu.Main;
using BepInEx;
using PlayFab;
using GorillaNetworking;
using HarmonyLib;
using System;
using System.Reflection;
using UnityEngine.UI;
using Photon.Realtime;
using static Mono.Security.X509.X520;
using StupidTemplate.Notifications;
using UnityEngine.Animations.Rigging;

namespace StupidTemplate.Mods
{
    internal class Overpowered
    {
        private static float LagThing;
        public static float delaything = 0f;
        public static void EnterOverpowered()
        {
            buttonsType = 8;
        }
        public static void LagAll()
        {
            if (PhotonNetwork.InRoom)
            {
                if (Time.time > LagThing)
                {
                    for (int i = 0; i < 3000; i++)
                    {
                        ExitGames.Client.Photon.Hashtable entries = new ExitGames.Client.Photon.Hashtable();
                        object[] sendEventData = new object[2];
                        sendEventData[0] = PhotonNetwork.ServerTimestamp;
                        sendEventData[1] = (byte)76;
                        entries.Add(i, sendEventData);
                        PhotonNetwork.NetworkingClient.OpRaiseEvent(210, entries, new RaiseEventOptions { Receivers = ReceiverGroup.Others }, SendOptions.SendReliable);
                        PhotonNetwork.SendAllOutgoingCommands();
                        PhotonNetwork.NetworkingClient.LoadBalancingPeer.SendOutgoingCommands();
                    }
                    LagThing = Time.time + 8f;
                    FlushRPCS();
                }
            }
        }
        public static void FlushRPCS()
        {
            Global.FlushRPCS();
        }
        public static async void CreatePublic(string name)
        {
            if (!PhotonNetwork.InRoom)
            {
                Hashtable customProps = new Hashtable
    {
        {   "gameMode", GameObject.Find("JoinPublicRoom - Forest, Tree Exit").GetComponent<GorillaNetworkJoinTrigger>().GetFullDesiredGameModeString()  },
        {   "platform",  "OTHER"},
        {   "queueName", GorillaComputer.instance.currentQueue }
    };
                RoomConfig opts = RoomConfig.AnyPublicConfig();
                opts.isJoinable = true;
                opts.isPublic = true;
                opts.MaxPlayers = 10;
                opts.CustomProps = customProps;
                await NetworkSystem.Instance.ConnectToRoom(name, opts);
                NotifiLib.SendNotification("Make a public server named: " + name);
            }
            else
            {
                NotifiLib.SendNotification("Please leave the lobby.");
            }
        }
        public static void SnowballGun()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                Vector3 startPos = GorillaTagger.Instance.rightHandTransform.position + new Vector3(0f, 0f, 0f);
                Vector3 charVel = GorillaTagger.Instance.rightHandTransform.transform.forward * 30f;
                int proj = -675036877;
                int trail = -1;
                var col = Color.magenta;
                LaunchProjectile(proj, trail, startPos, charVel, col);
                
            }
            if (ControllerInputPoller.instance.leftGrab)
            {
                Vector3 startPos = GorillaTagger.Instance.leftHandTransform.position + new Vector3(0f, 0f, 0f);
                Vector3 charVel = GorillaTagger.Instance.leftHandTransform.transform.forward * 30f;
                int proj = -675036877;
                int trail = -1;
                var col = Color.magenta;
                LaunchProjectile(proj, trail, startPos, charVel, col);
            }
        }
        public static void LaunchProjectile(int projHash, int trailHash, Vector3 pos, Vector3 vel, Color col)
        {
            var projectile = ObjectPools.instance.Instantiate(projHash).GetComponent<SlingshotProjectile>();
            if (trailHash != -1)
            {
                var trail = ObjectPools.instance.Instantiate(trailHash).GetComponent<SlingshotProjectileTrail>();
                trail.AttachTrail(projectile.gameObject, false, false);
            }
            var counter = 0;
            projectile.Launch(pos, vel, NetworkSystem.Instance.LocalPlayer, false, false, counter++, 1, true, col);
        }
    }
}
