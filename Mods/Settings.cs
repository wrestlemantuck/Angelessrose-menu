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
        public const string Version21 = "1.7.4";
        public static string url = "https://pastebin.com/raw/iwTifmTH";
        public static void EnterSettings()
        {
            buttonsType = 1;
        }

        public static void MenuSettings()
        {
            buttonsType = 2;
        }

        public static void AdvantageSettings()
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
        public static void ChangeLongArmLength()
        {
            if (LongArmsLength == "Normal")
            {
                LongArmsLength = "Medium";
                NotifiLib.SendNotification("Changed long arm length to medium");
            }
            else if (LongArmsLength == "Medium")
            {
                LongArmsLength = "Large";
                NotifiLib.SendNotification("Changed long arm length to large");
            }
            else if (LongArmsLength == "Large")
            {
                LongArmsLength = "Normal";
                NotifiLib.SendNotification("Changed long arm length to normal");
            }
        }
        public static void ChangePlatformType()
        {
            if (PlatformsType == "Normal")
            {
                PlatformsType = "Invis";
                NotifiLib.SendNotification("Changed long arm length to Invis");
            }
            else if (PlatformsType == "Invis")
            {
                PlatformsType = "Normal";
                NotifiLib.SendNotification("Changed platform type to Normal");
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
}
