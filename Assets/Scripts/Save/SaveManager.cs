using System.IO;
using UnityEngine;

namespace SaveCar
{
    public class SaveManager {
        private static VehiclesSaveData vehicleSave = null;
        public static void Save(Vehicle2 vehicle, int id){
            if (vehicleSave == null)
            {
                vehicleSave = new VehiclesDataAdapter(vehicle, id);
            }
            else
            {
                vehicleSave.vehicles[id-1] = new VehicleDataAdapter(vehicle, id);
            }
            string s = JsonUtility.ToJson(vehicleSave);
            string path = Application.persistentDataPath + "/saveCar.json";
            Debug.Log(s);
            Debug.Log(path);
            File.WriteAllText(path,s);
        }
    }
    
}