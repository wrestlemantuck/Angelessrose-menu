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
        public static float TPDelay = 0f;
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
        public static void Platforms()

        {
            if (PlatformsType == "Normal")
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
            else if (PlatformsType == "Invis")
            {
                if (ControllerInputPoller.instance.leftGrab && leftplat == null)
                {
                    leftplat = CreateInvisCubePlatformOnHand(GorillaTagger.Instance.leftHandTransform);
                }

                if (ControllerInputPoller.instance.rightGrab && rightplat == null)
                {
                    rightplat = CreateInvisCubePlatformOnHand(GorillaTagger.Instance.rightHandTransform);
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
        private static GameObject CreateInvisCubePlatformOnHand(Transform handTransform)
        {
            GameObject plat = GameObject.CreatePrimitive(PrimitiveType.Cube);
            plat.transform.localScale = new Vector3(0.025f, 0.3f, 0.4f);

            plat.transform.position = handTransform.position;
            plat.transform.rotation = handTransform.rotation;

            plat.GetComponent<Renderer>().enabled = false;

            return plat;
        }
        public static void SuperSlowFly()
        {
            if (ControllerInputPoller.instance.rightControllerPrimaryButton)
            {
                GorillaLocomotion.GTPlayer.Instance.transform.position += GorillaLocomotion.GTPlayer.Instance.rightControllerTransform.transform.forward * Time.deltaTime * 5f;
                GorillaLocomotion.GTPlayer.Instance.bodyCollider.attachedRigidbody.velocity = Vector3.zero;
            }
        }
        public static void SlowFly()
        {
            if (ControllerInputPoller.instance.rightControllerPrimaryButton)
            {
                GorillaLocomotion.GTPlayer.Instance.transform.position += GorillaLocomotion.GTPlayer.Instance.rightControllerTransform.transform.forward * Time.deltaTime * 10f;
                GorillaLocomotion.GTPlayer.Instance.bodyCollider.attachedRigidbody.velocity = Vector3.zero;
            }
        }
        public static void NormalFly()
        {
            if (ControllerInputPoller.instance.rightControllerPrimaryButton)
            {
                GorillaLocomotion.GTPlayer.Instance.transform.position += GorillaLocomotion.GTPlayer.Instance.rightControllerTransform.transform.forward * Time.deltaTime * 17f;
                GorillaLocomotion.GTPlayer.Instance.bodyCollider.attachedRigidbody.velocity = Vector3.zero;
            }
        }
        public static void UpAndDown()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                GorillaLocomotion.GTPlayer.Instance.GetComponent<Rigidbody>().AddForce(new Vector3(0f, -15f, 0f), ForceMode.Acceleration);
            }
            if (ControllerInputPoller.instance.rightControllerIndexFloat > 0.1f)
            {
                GorillaLocomotion.GTPlayer.Instance.GetComponent<Rigidbody>().AddForce(new Vector3(0f, 15f, 0f), ForceMode.Acceleration);
            }
        }
        public static void TpGun()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                Ray ray = new Ray(GorillaTagger.Instance.rightHandTransform.position, GorillaTagger.Instance.rightHandTransform.forward);
                Debug.DrawRay(ray.origin, ray.direction * 100f, Color.green);

                if (ControllerInputPoller.instance.rightControllerIndexFloat > 0.5f && TPDelay <= 0f)
                {
                    RaycastHit hit;
                    if (Physics.Raycast(ray, out hit, 100f))
                    {
                        GorillaTagger.Instance.transform.position = hit.point + Vector3.up * 1f;
                        TPDelay = 0.1f;
                    }
                }
            }

            if (TPDelay > 0f)
            {
                TPDelay -= Time.deltaTime;
            }
        }

    }
}
