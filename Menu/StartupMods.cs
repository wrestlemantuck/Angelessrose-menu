using BepInEx;
using HarmonyLib;
using StupidTemplate.Classes;
using StupidTemplate.Notifications;
using System;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using static StupidTemplate.Menu.Buttons;
using static StupidTemplate.Settings;
using TMPro;
using StupidTemplate.Mods;
using System.Threading.Tasks;

namespace StupidTemplate.Menu
{
    internal class StartupMods : MonoBehaviour
    {
        async void Start()
        {
            await Task.Delay(2000);
            CustomMOTD();
            SettingsMods.CheckVer();
        }
        public static void CustomMOTD()
        {
            GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/motd (1)").GetComponent<TextMeshPro>().text = "Thank you for using Angelessrose menu";
            GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/motdtext").GetComponent<TextMeshPro>().text = "All stuff made by wrestle";
        }
    }
}
