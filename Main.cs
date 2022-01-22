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

    [BepInPlugin("Appun.DSP.plugin.HideEverything", "DSPHideEverything", "0.1.1")]
    [BepInProcess("DSPGAME.exe")]



    public class Main : BaseUnityPlugin
    {
        public static ConfigEntry<bool> disableLogisticDrones;
        public static ConfigEntry<bool> disableShips;
        //public static ConfigEntry<bool> disableShipUI;
        //public static ConfigEntry<bool> disableUISpaceGuide;
        //public static ConfigEntry<bool> disableConveyorBelts;
        //public static ConfigEntry<bool> disableCargoes;
        public static ConfigEntry<bool> disableDysonSphere;


        public void Start()
        {
            LogManager.Logger = Logger;
            Harmony.CreateAndPatchAll(Assembly.GetExecutingAssembly());

            //configの設定
            disableLogisticDrones = Config.Bind("General", "disableLogisticDrones", false, "hide Logistic Drones");
            disableShips = Config.Bind("General", "disableShips", false, "hide Logistic Vessels");
            //disableConveyorBelts = Config.Bind("General", "disableConveyor", false, "hide ConveyorBelts");
            //disableCargoes = Config.Bind("General", "disableCargo", false, "hide Cargoes");
            disableDysonSphere = Config.Bind("General", "disableDysonSphere", false, "hide Dyson Sphere");
            //            disableShipUI = Config.Bind("General", "disableShipUI", true, "hide Logistic Vessels in Starmap");
            //            disableUISpaceGuide = Config.Bind("General", "disableUISpaceGuide", true, "hide Labels on Logistic Vessels");

            UI.LoadIcon();
            UI.BuilDUI();

        }



    }
}