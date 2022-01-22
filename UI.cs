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
    class UI : MonoBehaviour
{
        public static GameObject DroneButton;
        public static GameObject VesselButton;
        //public static GameObject BeltButton;
        //public static GameObject CargoButton;
        public static GameObject SphereButton;
        public static GameObject EtcButton;

        public static Sprite DroneIcon;
        public static Sprite VesselIcon;
        //private Sprite CargoIcon;
        //private Sprite BeltIcon;
        public static Sprite SphereIcon;

        //アイコンのロード
        public static void LoadIcon()
        {
            try
            {
                var assetBundle = AssetBundle.LoadFromStream(Assembly.GetExecutingAssembly().GetManifestResourceStream("DSPHideEverything.dsphideeverythingicon"));
                if (assetBundle == null)
                {
                    LogManager.Logger.LogInfo("Icon loaded.");
                }
                else
                {
                    DroneIcon = assetBundle.LoadAsset<Sprite>("drone");
                    VesselIcon = assetBundle.LoadAsset<Sprite>("vessel");
                    //CargoIcon = assetBundle.LoadAsset<Sprite>("cargo");
                    //BeltIcon = assetBundle.LoadAsset<Sprite>("belt");
                    SphereIcon = assetBundle.LoadAsset<Sprite>("dysonsphere");

                    assetBundle.Unload(false);
                }

            }
            catch (Exception e)
            {
                LogManager.Logger.LogInfo("e.Message " + e.Message);
                LogManager.Logger.LogInfo("e.StackTrace " + e.StackTrace);

            }
        }


        public static void BuilDUI()
        {

            //functinパネルのサイズ変更
            GameObject.Find("UI Root/Overlay Canvas/In Game/Game Menu/detail-func-group").GetComponent<RectTransform>().sizeDelta = new Vector2(350, 208); // 350 168

            //ドローンボタンの作成
            DroneButton = Instantiate(GameObject.Find("UI Root/Overlay Canvas/In Game/Game Menu/detail-func-group/dfunc-1"), GameObject.Find("UI Root/Overlay Canvas/In Game/Game Menu/detail-func-group").transform) as GameObject;
            DroneButton.name = "DroneButton";
            DroneButton.transform.localPosition = new Vector3(-275, 123, 0);
            DroneButton.GetComponent<UIButton>().tips.tipTitle = "Logistic Drones".Translate();
            DroneButton.GetComponent<UIButton>().tips.tipText = "Click to turn ON / OFF drawing of Logistic Drones".Translate();
            DroneButton.transform.Find("icon").GetComponent<Image>().sprite = DroneIcon;
            DroneButton.GetComponent<UIButton>().highlighted = !Main.disableLogisticDrones.Value;
            //ボタンイベントの作成
            DroneButton.GetComponent<UIButton>().button.onClick.AddListener(new UnityAction(Event.OnDroneButtonClick));

            //物流船ボタンの作成
            VesselButton = Instantiate(GameObject.Find("UI Root/Overlay Canvas/In Game/Game Menu/detail-func-group/dfunc-1"), GameObject.Find("UI Root/Overlay Canvas/In Game/Game Menu/detail-func-group").transform) as GameObject;
            VesselButton.name = "VesselButton";
            VesselButton.transform.localPosition = new Vector3(-235, 123, 0);
            VesselButton.GetComponent<UIButton>().tips.tipTitle = "Logistic Vessels".Translate();
            VesselButton.GetComponent<UIButton>().tips.tipText = "Click to turn ON / OFF drawing of Logistic Vessels".Translate();
            VesselButton.transform.Find("icon").GetComponent<Image>().sprite = VesselIcon;
            VesselButton.GetComponent<UIButton>().highlighted = !Main.disableShips.Value;
            //ボタンイベントの作成
            VesselButton.GetComponent<UIButton>().button.onClick.AddListener(new UnityAction(Event.OnVesselButtonClick));

            //ベルトボタンの作成
            //BeltButton = Instantiate(GameObject.Find("UI Root/Overlay Canvas/In Game/Game Menu/detail-func-group/dfunc-1"), GameObject.Find("UI Root/Overlay Canvas/In Game/Game Menu/detail-func-group").transform) as GameObject;
            //BeltButton.name = "BeltButton";
            //BeltButton.transform.localPosition = new Vector3(-195, 123, 0);
            //BeltButton.GetComponent<UIButton>().tips.tipTitle = "Conveyor belts".Translate();
            //BeltButton.GetComponent<UIButton>().tips.tipText = "Click to turn ON / OFF drawing of Conveyor belts".Translate();
            //BeltButton.transform.Find("icon").GetComponent<Image>().sprite = BeltIcon;
            //BeltButton.GetComponent<UIButton>().highlighted = !disableConveyorBelts.Value;
            //ボタンイベントの作成
            //BeltButton.GetComponent<UIButton>().button.onClick.AddListener(new UnityAction(OnBeltButtonClick));


            //カーゴボタンの作成
            //CargoButton = Instantiate(GameObject.Find("UI Root/Overlay Canvas/In Game/Game Menu/detail-func-group/dfunc-1"), GameObject.Find("UI Root/Overlay Canvas/In Game/Game Menu/detail-func-group").transform) as GameObject;
            //CargoButton.name = "CargoButton";
            //CargoButton.transform.localPosition = new Vector3(-155, 123, 0);
            //CargoButton.GetComponent<UIButton>().tips.tipTitle = "Cargoes".Translate();
            //CargoButton.GetComponent<UIButton>().tips.tipText = "Click to turn ON / OFF drawing of Cargoes".Translate();
            //CargoButton.transform.Find("icon").GetComponent<Image>().sprite = CargoIcon;
            //CargoButton.GetComponent<UIButton>().highlighted = !disableCargoes.Value;d
            //ボタンイベントの作成
            //CargoButton.GetComponent<UIButton>().button.onClick.AddListener(new UnityAction(OnCargoButtonClick));

            //ダイソンスフィアボタンの作成
            SphereButton = Instantiate(GameObject.Find("UI Root/Overlay Canvas/In Game/Game Menu/detail-func-group/dfunc-1"), GameObject.Find("UI Root/Overlay Canvas/In Game/Game Menu/detail-func-group").transform) as GameObject;
            SphereButton.name = "SphereButton";
            SphereButton.transform.localPosition = new Vector3(-195, 123, 0);
            SphereButton.GetComponent<UIButton>().tips.tipTitle = "Dyson Sphere".Translate();
            SphereButton.GetComponent<UIButton>().tips.tipText = "Click to turn ON / OFF drawing of Dyson Sphere".Translate();
            SphereButton.transform.Find("icon").GetComponent<Image>().sprite = SphereIcon;
            SphereButton.GetComponent<UIButton>().highlighted = !Main.disableDysonSphere.Value;
            //ボタンイベントの作成
            SphereButton.GetComponent<UIButton>().button.onClick.AddListener(new UnityAction(Event.OnSphereButtonClick));

            //その他ボタンの作成
            //EtcButton = Instantiate(GameObject.Find("UI Root/Overlay Canvas/In Game/Game Menu/detail-func-group/dfunc-1"), GameObject.Find("UI Root/Overlay Canvas/In Game/Game Menu/detail-func-group").transform) as GameObject;
            //EtcButton.name = "EtcButton";
            //EtcButton.transform.localPosition = new Vector3(-155, 123, 0);
            //EtcButton.GetComponent<UIButton>().tips.tipTitle = "etc.".Translate();
            //EtcButton.GetComponent<UIButton>().tips.tipText = "Click to turn ON / OFF drawing of other objects".Translate();
            //Destroy(EtcButton.transform.Find("icon").gameObject);
            //var buttonText = Instantiate(GameObject.Find("UI Root/Overlay Canvas/In Game/Windows/Mini Lab Panel/bg/supply-button/button-text"), EtcButton.transform) as GameObject;

            //Destroy(buttonText.GetComponent<Localizer>());

            //buttonText.GetComponent<Text>().text = "etc.".Translate();
            //buttonText.transform.localPosition = new Vector3(16, -22, 0);
            //EtcButton.transform.Find("icon").GetComponent<Image>().sprite = CargoIcon;
            //EtcButton.GetComponent<UIButton>().highlighted = !disableCargoes.Value;
            //ボタンイベントの作成
            //EtcButton.GetComponent<UIButton>().button.onClick.AddListener(new UnityAction(OnCargoButtonClick));

        }

    }
}
