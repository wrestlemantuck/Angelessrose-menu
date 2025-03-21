using ExitGames.Client.Photon;
using GorillaTagScripts;
using Photon.Pun;
using UnityEngine;
using static StupidTemplate.Settings;
using static StupidTemplate.Menu.Main;
using BepInEx;
using StupidTemplate.Notifications;
using System.Collections;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

namespace StupidTemplate.Mods
{
    internal class Movement
    {
        private static GameObject leftplat = null;
        private static GameObject rightplat = null;
        public static void EnterMovement()
        {
            buttonsType = 10;
        }
        public static GameObject createdwater = null;
        public static void EnableSwimEverywhere()
        {
            if (createdwater == null)
            {
                GameObject caveWaterVolume = GameObject.Find("Environment Objects/LocalObjects_Prefab/ForestToBeach/ForestToBeach_Prefab_V4/CaveWaterVolume");
                if (caveWaterVolume != null)
                {
                    createdwater = UnityEngine.Object.Instantiate<GameObject>(caveWaterVolume);
                    createdwater.transform.localScale = new Vector3(5f, 5f, 5f);
                    createdwater.GetComponent<Renderer>().enabled = false;
                }
            }
            else
            {
                createdwater.transform.position = GorillaTagger.Instance.headCollider.transform.position + new Vector3(0f, 2.5f, 0f);
            }

            GorillaLocomotion.GTPlayer.Instance.audioManager.UnsetMixerSnapshot(0.1f);
        }

        public static void DisableSwimEverywhere()
        {
            if (createdwater != null)
            {
                UnityEngine.Object.Destroy(createdwater);
                createdwater = null;
            }
        }
        public static void CubePlatforms()

        {
            if (ControllerInputPoller.instance.leftGrab && leftplat == null)
            {
                leftplat = CreateCubePlatformOnHand(GorillaTagger.Instance.leftHandTransform);
            }

            if (ControllerInputPoller.instance.rightGrab && rightplat == null)
            {
                rightplat = CreateCubePlatformOnHand(GorillaTagger.Instance.rightHandTransform);
            }

            if (ControllerInputPoller.instance.rightGrabRelease && rightplat != null)
            {
                rightplat.Disable();
                rightplat = null;

            }

            if (ControllerInputPoller.instance.leftGrabRelease && leftplat != null)
            {
                leftplat.Disable();
                leftplat = null;
            }
        }
        private static GameObject CreateCubePlatformOnHand(Transform handTransform)
        {
            GameObject plat = GameObject.CreatePrimitive(PrimitiveType.Cube);
            plat.transform.localScale = new Vector3(0.025f, 0.3f, 0.4f);

            plat.transform.position = handTransform.position;
            plat.transform.rotation = handTransform.rotation;

            float h = (Time.frameCount / 180f) % 1f;
            plat.GetComponent<Renderer>().material.color = Color.black;
            return plat;
        }
        public static void SpherePlatforms()

        {
            if (ControllerInputPoller.instance.leftGrab && leftplat == null)
            {
                leftplat = CreateSpherePlatformOnHand(GorillaTagger.Instance.leftHandTransform);
            }

            if (ControllerInputPoller.instance.rightGrab && rightplat == null)
            {
                rightplat = CreateSpherePlatformOnHand(GorillaTagger.Instance.rightHandTransform);
            }

            if (ControllerInputPoller.instance.rightGrabRelease && rightplat != null)
            {
                rightplat.Disable();
                rightplat = null;

            }

            if (ControllerInputPoller.instance.leftGrabRelease && leftplat != null)
            {
                leftplat.Disable();
                leftplat = null;
            }
        }
        private static GameObject CreateSpherePlatformOnHand(Transform handTransform)
        {
            GameObject plat = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            plat.transform.localScale = new Vector3(0.333f, 0.333f, 0.333f);

            plat.transform.position = handTransform.position;
            plat.transform.rotation = handTransform.rotation;

            float h = (Time.frameCount / 180f) % 1f;
            plat.GetComponent<Renderer>().material.color = Color.black;
            return plat;
        }
        public static void SlowFly()
        {
            if (ControllerInputPoller.instance.rightControllerPrimaryButton)
            {
                Vector3 righthandpos = GorillaTagger.Instance.rightHandTransform.position;
                Vector3 playerpos = GorillaLocomotion.GTPlayer.Instance.transform.position;
                Vector3 direction = (righthandpos - playerpos).normalized;

                Vector3 movement = direction * Time.deltaTime * 3;

                Rigidbody playerRigidbody = GorillaLocomotion.GTPlayer.Instance.GetComponent<Rigidbody>();
                playerRigidbody.velocity = movement;
            }
        }
    }
}
