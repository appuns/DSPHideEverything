using BepInEx;
using BepInEx.Configuration;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System.Reflection.Emit;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System;
using System.IO;
using BepInEx.Logging;
using HarmonyLib;
using System.Reflection;
using System.Security;
using System.Security.Permissions;
using static UnityEngine.GUILayout;
using UnityEngine.Rendering;
using Steamworks;
using rail;
using xiaoye97;

namespace DSPHideEverything
{
    [HarmonyPatch]
    class HarmonyPatches
    {
        //ダイソンスフィア描画のフック
        [HarmonyPrefix, HarmonyPatch(typeof(DysonSphere), "DrawModel")]

        public static bool DysonSphere_DrawModel_PrePatch()
        {
            if (Main.disableDysonSphere.Value && UIRoot.instance.uiGame.dysonEditor.active == false)
            {
                return false;
            }
            return true;

        }

        //ダイソンスウォーム描画のフック
        [HarmonyPrefix, HarmonyPatch(typeof(DysonSwarm), "DrawModel")]
        public static bool DysonSwarm_DrawModel_PrePatch()
        {
            if (Main.disableDysonSphere.Value)
            {
                return false;
            }
            else
                return true;

        }


        //ドローン描画のフック
        [HarmonyPrefix, HarmonyPatch(typeof(LogisticDroneRenderer), "Draw")]
        public static bool LogisticDroneRenderer_Draw_PrePatch()
        {
            if (Main.disableLogisticDrones.Value)
            {
                return false;
            }
            else
                return true;

        }


        //物流船描画のフック
        [HarmonyPrefix, HarmonyPatch(typeof(LogisticShipRenderer), "Draw")]
        public static bool LogisticShipRenderer_Draw_PrePatch()
        {
            if (Main.disableShips.Value)
            {
                return false;
            }
            return true;

        }

        //物流船in星図描画のフック
        [HarmonyPrefix, HarmonyPatch(typeof(LogisticShipUIRenderer), "Draw")]
        public static bool LogisticShipUIRenderer_Draw_PrePatch()
        {
            if (Main.disableShips.Value)
            {
                return false;
            }
            return true;
        }

        //物流船のラベル描画のフック
        [HarmonyPrefix, HarmonyPatch(typeof(UISpaceGuide), "_OnLateUpdate")]
        public static bool UISpaceGuider_OnLateUpdate_PrePatch()
        {
            if (Main.disableShips.Value)
            {
                UIRoot.instance.uiGame.spaceGuide.shipRenderer = null;
            }
            return true;

        }
    }
}
