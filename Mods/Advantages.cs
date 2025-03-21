using ExitGames.Client.Photon;
using GorillaTagScripts;
using Photon.Pun;
using UnityEngine;
using static StupidTemplate.Settings;
using static StupidTemplate.Menu.Main;
using BepInEx;
using StupidTemplate.Notifications;
using System.Threading.Tasks;
using GorillaLocomotion;

namespace StupidTemplate.Mods
{
    internal class Advantages
    {
        public static void EnterAdvanages()
        {
            buttonsType = 5;
        }
        public static void NoTagFreeze()
        {
            GorillaLocomotion.GTPlayer.Instance.disableMovement = false;
        }
        public static void WASDFly()
        {
            GorillaTagger.Instance.leftHandTransform.position = GameObject.Find("head").gameObject.transform.position;
            GorillaTagger.Instance.rightHandTransform.position = GameObject.Find("head").gameObject.transform.position;
            if (UnityInput.Current.GetKey(KeyCode.W))
            {
                GorillaLocomotion.GTPlayer.Instance.transform.position += GorillaLocomotion.GTPlayer.Instance.headCollider.transform.forward * Time.deltaTime * 5f;
            }
            if (UnityInput.Current.GetKey(KeyCode.A))
            {
                GorillaLocomotion.GTPlayer.Instance.transform.position += GorillaLocomotion.GTPlayer.Instance.headCollider.transform.right * Time.deltaTime * -5f;
            }
            if (UnityInput.Current.GetKey(KeyCode.S))
            {
                GorillaLocomotion.GTPlayer.Instance.transform.position += GorillaLocomotion.GTPlayer.Instance.headCollider.transform.forward * Time.deltaTime * -5f;
            }
            if (UnityInput.Current.GetKey(KeyCode.D))
            {
                GorillaLocomotion.GTPlayer.Instance.transform.position += GorillaLocomotion.GTPlayer.Instance.headCollider.transform.right * Time.deltaTime * 5f;
            }
            if (UnityInput.Current.GetKey(KeyCode.Space))
            {
                GorillaLocomotion.GTPlayer.Instance.transform.position += GorillaLocomotion.GTPlayer.Instance.headCollider.transform.up * Time.deltaTime * 5f;
            }

            if (UnityInput.Current.GetKey(KeyCode.LeftControl))
            {
                GorillaLocomotion.GTPlayer.Instance.transform.position += GorillaLocomotion.GTPlayer.Instance.headCollider.transform.up * Time.deltaTime * -5f;
            }

            GorillaLocomotion.GTPlayer.Instance.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
        public static void LowGrav()
        {
            {
                if (GorillaLocomotion.GTPlayer.Instance != null)
                {
                    Rigidbody player = GorillaLocomotion.GTPlayer.Instance.GetComponent<Rigidbody>();

                    Vector3 currentVelocity = player.velocity;
                    player.velocity = new Vector3(currentVelocity.x, currentVelocity.y * 0.85f, currentVelocity.z);
                }
            }
        }
        public static void HighGrav()
        {
            if (GorillaLocomotion.GTPlayer.Instance != null)
            {
                Rigidbody player = GorillaLocomotion.GTPlayer.Instance.GetComponent<Rigidbody>();
                Vector3 currentVelocity = player.velocity;
                player.velocity = new Vector3(currentVelocity.x, currentVelocity.y - 0.05f, currentVelocity.z);
            }
        }
        public static void EnableLongArms()
        {
            GorillaLocomotion.GTPlayer.Instance.transform.localScale = new Vector3(1.3f, 1.3f, 1.3f);
        }
        public static void DisableLongArms()
        {
            GorillaLocomotion.GTPlayer.Instance.transform.localScale = new Vector3(1f, 1f, 1f);
        }
        public static void WeakSpeedBoost()
        {
            GorillaLocomotion.GTPlayer.Instance.maxJumpSpeed = 8.7f;
            GorillaLocomotion.GTPlayer.Instance.velocityLimit = 1.2f;
        }
        public static void GhostMonke()
        {
            if (ControllerInputPoller.instance.rightControllerSecondaryButton)
            {
                GorillaTagger.Instance.offlineVRRig.enabled = false;
            }
            else
            {
                GorillaTagger.Instance.offlineVRRig.enabled = true;
            }
        }
        public static void NormalSpeedBoost()
        {
            GorillaLocomotion.GTPlayer.Instance.maxJumpSpeed = 9.9f;
            GorillaLocomotion.GTPlayer.Instance.velocityLimit = 1.3f;
        }
        public static void BlatantSpeedBoost()
        {
            GorillaLocomotion.GTPlayer.Instance.maxJumpSpeed = 11.7f;
            GorillaLocomotion.GTPlayer.Instance.velocityLimit = 1.4f;
        }
        public static void TagAll()
        {
            foreach (var vrrig in GorillaParent.instance.vrrigs)
                if (!vrrig.mainSkin.material.name.Contains("fected") && GorillaTagger.Instance.offlineVRRig.mainSkin.material.name.Contains("fected"))
                {
                    GorillaTagger.Instance.offlineVRRig.transform.position = Vector3.zero;
                    GorillaTagger.Instance.offlineVRRig.enabled = false;
                    GorillaTagger.Instance.offlineVRRig.transform.position = vrrig.transform.position;
                    GorillaTagger.Instance.leftHandTransform.position = vrrig.transform.position;
                    GorillaTagger.Instance.offlineVRRig.enabled = true;
                }
        }
        public static async void FakeLag()
        {
            GorillaTagger.Instance.offlineVRRig.enabled = false;
            await Task.Delay(150);
            GorillaTagger.Instance.offlineVRRig.enabled = true;
        }
    }
}
