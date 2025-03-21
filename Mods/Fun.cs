using ExitGames.Client.Photon;
using GorillaTagScripts;
using Photon.Pun;
using UnityEngine;
using static StupidTemplate.Settings;
using static StupidTemplate.Menu.Main;
using BepInEx;
using HarmonyLib;

namespace StupidTemplate.Mods
{
    internal class Fun
    {
        public static Vector3 startpos;
        public static void EnterFun()
        {
            buttonsType = 7;
        }
        public static void ShowHoverboard()
        {
            GameObject Hoverboard = GameObject.Find("Player Objects/Local VRRig/Local Gorilla Player/RigAnchor/rig/body/HoverboardVisual");
            if (Hoverboard != null)
            {
                Hoverboard.SetActive(true);
            }
        }
        public static void HideHoverboard()
        {
            GameObject Hoverboard = GameObject.Find("Player Objects/Local VRRig/Local Gorilla Player/RigAnchor/rig/body/HoverboardVisual");
            if (Hoverboard != null)
            {
                Hoverboard.SetActive(false);
            }
        }
        public static void AutoMiddleFinger()
        {
            ControllerInputPoller.instance.leftControllerGripFloat = 0f;
            ControllerInputPoller.instance.rightControllerGripFloat = 0f;
            ControllerInputPoller.instance.leftControllerIndexFloat = 5f;
            ControllerInputPoller.instance.rightControllerIndexFloat = 5f;
            ControllerInputPoller.instance.leftControllerPrimaryButton = true;
            ControllerInputPoller.instance.leftControllerSecondaryButton = false;
            ControllerInputPoller.instance.rightControllerPrimaryButton = true;
            ControllerInputPoller.instance.rightControllerSecondaryButton = false;
            ControllerInputPoller.instance.leftControllerPrimaryButtonTouch = false;
            ControllerInputPoller.instance.leftControllerSecondaryButtonTouch = false;
            ControllerInputPoller.instance.rightControllerPrimaryButtonTouch = false;
            ControllerInputPoller.instance.rightControllerSecondaryButtonTouch = false;
        }
        public static void NormalHoverboard()
        {
                Traverse traverse = Traverse.Create(typeof(HoverboardVisual));
                traverse.Field("maxSpeed").SetValue(10);
                traverse.Field("pushMultiplyer").SetValue(12f);
                traverse.Field("movementCoolRate").SetValue(1.4f);
        }
        public static void FastHoverboard()
        {
            Traverse traverse = Traverse.Create(typeof(HoverboardVisual));
            traverse.Field("maxSpeed").SetValue(999);
            traverse.Field("pushMultiplyer").SetValue(999f);
            traverse.Field("movementCoolRate").SetValue(0);
        }
        public static void NoTapCooldown()
        {
            GorillaTagger.Instance.tapCoolDown = 0f;
        }
        public static void NormalTapCooldown()
        {
            GorillaTagger.Instance.tapCoolDown = 0.5f;
        }
        public static void LoudHandTaps()
        {
            GorillaTagger.Instance.handTapVolume = 5f;
        }
        public static void NormalHandTaps()
        {
            GorillaTagger.Instance.handTapVolume = 0.07f;
        }
        public static void NoHandTaps()
        {
            GorillaTagger.Instance.handTapVolume = 0f;
        }
        public static void GrabBug()
        {
            GameObject floatingBug = GameObject.Find("Floating Bug Holdable");
            if (floatingBug == null) return;

            if (ControllerInputPoller.instance.rightGrab)
            {
                floatingBug.transform.position = GorillaTagger.Instance.rightHandTransform.position;
            }
            if (ControllerInputPoller.instance.leftGrab)
            {
                floatingBug.transform.position = GorillaTagger.Instance.leftHandTransform.position;
            }
        }
    }
}
