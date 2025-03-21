using System;
using UnityEngine.Networking;
using static StupidTemplate.Menu.Main;
using static StupidTemplate.Settings;
using UnityEngine;
using System.Collections;
using StupidTemplate.Notifications;


namespace StupidTemplate.Mods
{
    internal class SettingsMods
    {
        public const string Version21 = "1.5.8";
        public static string url = "https://pastebin.com/raw/iwTifmTH";
        public static void EnterSettings()
        {
            buttonsType = 1;
        }

        public static void MenuSettings()
        {
            buttonsType = 2;
        }

        public static void MovementSettings()
        {
            buttonsType = 3;
        }

        public static void ProjectileSettings()
        {
            buttonsType = 4;
        }

        public static void RightHand()
        {
            rightHanded = true;
        }

        public static void LeftHand()
        {
            rightHanded = false;
        }

        public static void EnableFPSCounter()
        {
            fpsCounter = true;
        }

        public static void DisableFPSCounter()
        {
            fpsCounter = false;
        }

        public static void EnableNotifications()
        {
            disableNotifications = false;
        }

        public static void DisableNotifications()
        {
            disableNotifications = true;
        }

        public static void EnableDisconnectButton()
        {
            disconnectButton = true;
        }

        public static void DisableDisconnectButton()
        {
            disconnectButton = false;
        }
        public static void CheckVersion()
        {
            GameObject coroutineObject = new GameObject("CheckVersion");
            CoroutineRunner runner = coroutineObject.AddComponent<CoroutineRunner>();
            runner.StartCoroutine(CheckVer());
        }
        public static IEnumerator CheckVer()
        {
            using (UnityWebRequest webRequest = UnityWebRequest.Get(SettingsMods.url))
            {
                yield return webRequest.SendWebRequest();

                if (webRequest.result != UnityWebRequest.Result.Success)
                {
                    NotifiLib.SendNotification("<color=red>ERROR FETCHING DATA</color>");
                }
                else
                {
                    string text = webRequest.downloadHandler.text;
                    if (text == Version21)
                    {
                        NotifiLib.SendNotification("<color=green>LATEST VERSION</color>");
                    }
                    else
                    {
                        NotifiLib.SendNotification("<color=red>[WARNING] OUTDATED VERSION</color>");
                    }
                }
            }
        }
    }
    public class CoroutineRunner : MonoBehaviour
    {
        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
