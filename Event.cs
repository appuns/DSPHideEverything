using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSPHideEverything
{
    class Event
    {

        //DroneButtonイベント
        public static void OnDroneButtonClick()
        {
            Main.disableLogisticDrones.Value = !Main.disableLogisticDrones.Value;
            GameMain.mainPlayer.factoryModel.disableLogisticDrones = Main.disableLogisticDrones.Value;
            UI.DroneButton.GetComponent<UIButton>().highlighted = !Main.disableLogisticDrones.Value;
        }

        //VesselButtonイベント
        public static void OnVesselButtonClick()
        {
            Main.disableShips.Value = !Main.disableShips.Value;
            UI.VesselButton.GetComponent<UIButton>().highlighted = !Main.disableShips.Value;
        }

        //BeltButtonイベント
        //public void OnBeltButtonClick()
        //{
        //    disableConveyorBelts.Value = !disableConveyorBelts.Value;
        //    GameMain.mainPlayer.factoryModel.disableTraffics = disableConveyorBelts.Value;
        //    BeltButton.GetComponent<UIButton>().highlighted = !disableConveyorBelts.Value;
        //}
        //CargoButtonイベント
        //public void OnCargoButtonClick()
        //{
        //    disableCargoes.Value = !disableCargoes.Value;
        //    GameMain.mainPlayer.factoryModel.disableCargos = disableCargoes.Value;
        //    CargoButton.GetComponent<UIButton>().highlighted = !disableCargoes.Value;
        //}
        //SphereButtonイベント
        public static void OnSphereButtonClick()
        {
            Main.disableDysonSphere.Value = !Main.disableDysonSphere.Value;
            UI.SphereButton.GetComponent<UIButton>().highlighted = !Main.disableDysonSphere.Value;
        }

    }
}
