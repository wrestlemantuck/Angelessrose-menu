using StupidTemplate.Notifications;
using Photon.Pun;
using Photon.Realtime;
using Photon.Voice.Unity;
using Photon.Voice.Unity.UtilityScripts;
using POpusCodec.Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using UnityEngine;
using static StupidTemplate.Classes.RigManager;
using static StupidTemplate.Menu.Main;

namespace StupidTemplate.Mods
{
    internal class Visual
    {
        public static void EnterVisual()
        {
            buttonsType = 6;
        }
        public static void NightTime()
        {
            BetterDayNightManager.instance.SetTimeOfDay(0);
        }

        public static void EveningTime()
        {
            BetterDayNightManager.instance.SetTimeOfDay(7);
        }

        public static void MorningTime()
        {
            BetterDayNightManager.instance.SetTimeOfDay(1);
        }

        public static void DayTime()
        {
            BetterDayNightManager.instance.SetTimeOfDay(3);
        }
        public static void RectangleESP()
        {
            foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
            {
                bool flag = vrrig != null && !vrrig.isOfflineVRRig && !vrrig.isMyPlayer;
                if (flag)
                {
                    Vector3 pos = vrrig.transform.position;
                    float height = 1.8f;
                    float width = 0.6f;
                    Vector3 top = pos + new Vector3(0, height / 2, 0);
                    Vector3 bottom = pos - new Vector3(0, height / 2, 0);
                    Vector3 topLeft = top + vrrig.transform.right * -width / 2;
                    Vector3 topRight = top + vrrig.transform.right * width / 2;
                    Vector3 bottomLeft = bottom + vrrig.transform.right * -width / 2;
                    Vector3 bottomRight = bottom + vrrig.transform.right * width / 2;
                    GameObject boxObj = new GameObject("rectangle");
                    LineRenderer line = boxObj.AddComponent<LineRenderer>();

                    line.positionCount = 5;
                    line.useWorldSpace = true;
                    line.startWidth = 0.015f;
                    line.endWidth = 0.015f;
                    line.material.shader = Shader.Find("GUI/Text Shader");
                    if (vrrig.mainSkin.material.name.Contains("fected"))
                    {
                        line.startColor = Color.red;
                        line.endColor = Color.red;
                    }
                    else
                    {
                        line.startColor = Color.green;
                        line.endColor = Color.green;
                    }
                    line.SetPosition(0, topLeft);
                    line.SetPosition(1, topRight);
                    line.SetPosition(2, bottomRight);
                    line.SetPosition(3, bottomLeft);
                    line.SetPosition(4, topLeft);
                    UnityEngine.Object.Destroy(boxObj, Time.deltaTime);
                }
            }
        }
    }
}
