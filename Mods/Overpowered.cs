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
using StupidTemplate.Classes;
using UnityEngine.InputSystem;

namespace StupidTemplate.Mods
{
    internal class Overpowered
    {
        private static GameObject gunSphere;
        private static LineRenderer lineRenderer;
        private static float timeCounter = 0f;
        private static Vector3[] linePositions;
        private static Vector3 previousControllerPosition;
        private static float LagThing;
        public static float delayThing = 0f;
        
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
        public static void NoTagOnJoin()
        {
            PlayerPrefs.SetString("tutorial", "nope");
            PlayerPrefs.SetString("didTutorial", "nope");
            Hashtable hash = new Hashtable();
            hash.Add("didTutorial", false);
            PhotonNetwork.LocalPlayer.SetCustomProperties(hash, null, null);
            PlayerPrefs.Save();
        }
        public static void TagOnJoin()
        {
            PlayerPrefs.SetString("tutorial", "done");
            PlayerPrefs.SetString("didTutorial", "done");
            Hashtable hash = new Hashtable();
            hash.Add("didTutorial", true);
            PhotonNetwork.LocalPlayer.SetCustomProperties(hash, null, null);
            PlayerPrefs.Save();
        }
        public static void RegionEU()
        {
            PhotonNetwork.ConnectToRegion("eu");
        }
        public static void RegionUS()
        {
            PhotonNetwork.ConnectToRegion("us");
        }
        public static void RegionUSW()
        {
            PhotonNetwork.ConnectToRegion("usw");
        }
        public static void TagGun()
        {
            if (ControllerInputPoller.instance.rightControllerGripFloat > 0.1f || UnityInput.Current.GetMouseButton(1))
            {
                if (Physics.Raycast(GorillaLocomotion.GTPlayer.Instance.rightControllerTransform.position, -GorillaLocomotion.GTPlayer.Instance.rightControllerTransform.up, out var hitInfo))
                {
                    if (Mouse.current.rightButton.isPressed)
                    {
                        Camera cam = GameObject.Find("Shoulder Camera").GetComponent<Camera>();
                        Ray ray = cam.ScreenPointToRay(Mouse.current.position.ReadValue());
                        Physics.Raycast(ray, out hitInfo, 100);
                    }

                    if (gunSphere == null)
                    {
                        gunSphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                        gunSphere.transform.localScale = new Vector3(0f, 0f, 0f);
                        gunSphere.GetComponent<Renderer>().material.shader = Shader.Find("GorillaTag/UberShader");
                        gunSphere.GetComponent<Renderer>().material.color = Color.white;
                        GameObject.Destroy(gunSphere.GetComponent<BoxCollider>());
                        GameObject.Destroy(gunSphere.GetComponent<Rigidbody>());
                        GameObject.Destroy(gunSphere.GetComponent<Collider>());

                        lineRenderer = gunSphere.AddComponent<LineRenderer>();
                        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
                        lineRenderer.widthCurve = AnimationCurve.Linear(0, 0.01f, 1, 0.01f);
                        lineRenderer.startColor = Color.white;
                        lineRenderer.endColor = Color.white;

                        linePositions = new Vector3[50];
                        for (int i = 0; i < linePositions.Length; i++)
                        {
                            linePositions[i] = GorillaLocomotion.GTPlayer.Instance.rightControllerTransform.position;
                        }
                    }

                    gunSphere.transform.position = hitInfo.point;

                    timeCounter += Time.deltaTime;

                    Vector3 pos1 = GorillaLocomotion.GTPlayer.Instance.rightControllerTransform.position;
                    Vector3 direction = (hitInfo.point - pos1).normalized;
                    float distance = Vector3.Distance(pos1, hitInfo.point);

                    Vector3 controllerMovement = pos1 - previousControllerPosition;
                    previousControllerPosition = pos1;

                    if (ControllerInputPoller.instance.rightControllerIndexFloat > 0.1f || Mouse.current.leftButton.isPressed)
                    {
                        TagPlayer(hitInfo.collider.gameObject);
                    }

                    for (int i = 0; i < linePositions.Length; i++)
                    {
                        float t = i / (float)(linePositions.Length - 1);
                        Vector3 lerpedPosition = Vector3.Lerp(pos1, hitInfo.point, t);

                        linePositions[i] += controllerMovement * 0.5f;
                        linePositions[i] += UnityEngine.Random.insideUnitSphere * 0.01f;
                        linePositions[i] = Vector3.Lerp(linePositions[i], lerpedPosition, Time.deltaTime * 5f);
                    }

                    lineRenderer.positionCount = linePositions.Length;
                    lineRenderer.SetPositions(linePositions);

                    float pingPongTime = Mathf.PingPong(timeCounter, 1f);
                    Color lineColor = Color.Lerp(Color.white, Color.cyan, pingPongTime);
                    lineRenderer.startColor = lineColor;
                    lineRenderer.endColor = lineColor;
                }
            }

            if (gunSphere != null && (ControllerInputPoller.instance.rightControllerGripFloat <= 0.1f && !UnityInput.Current.GetMouseButton(1)))
            {
                GameObject.Destroy(gunSphere);
                GameObject.Destroy(lineRenderer);
                timeCounter = 0f;
                linePositions = null;
            }
        }
        public static void TagPlayer(GameObject hitObject)
        {
            if (hitObject.CompareTag("Player"))
            {
                GorillaLocomotion.GTPlayer.Instance.rightControllerTransform.position = hitObject.transform.position;
                NotifiLib.SendNotification("Tagged player?");
            }
        }
    }
}
