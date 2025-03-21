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
    internal class Cosmetics
    {
        public static void EnterCosmetics()
        {
            buttonsType = 11;
        }
        public static async void EarlyAccessBadge()
        {
            CosmeticsController.instance.ProcessExternalUnlock("LBAAE.", true, false);
            CosmeticsController.instance.UpdateMyCosmetics();
            await Task.Delay(3000);
            CosmeticsController.instance.UpdateWardrobeModelsAndButtons();
        }
        public static async void FingerPainter()
        {
            CosmeticsController.instance.ProcessExternalUnlock("LBADE.", true, false);
            CosmeticsController.instance.UpdateMyCosmetics();
            await Task.Delay(3000);
            CosmeticsController.instance.UpdateWardrobeModelsAndButtons();
        }
        public static async void Illustator()
        {
            CosmeticsController.instance.ProcessExternalUnlock("LBAGS.", true, false);
            CosmeticsController.instance.UpdateMyCosmetics();
            await Task.Delay(3000);
            CosmeticsController.instance.UpdateWardrobeModelsAndButtons();
        }
        public static async void Stick()
        {
            CosmeticsController.instance.ProcessExternalUnlock("LBAAK.", true, false);
            CosmeticsController.instance.UpdateMyCosmetics();
            await Task.Delay(3000);
            CosmeticsController.instance.UpdateWardrobeModelsAndButtons();
        }
        public static async void AdminBadge()
        {
            CosmeticsController.instance.ProcessExternalUnlock("LBAAD.", true, false);
            CosmeticsController.instance.UpdateMyCosmetics();
            await Task.Delay(3000);
            CosmeticsController.instance.UpdateWardrobeModelsAndButtons();
        }
    }
}
