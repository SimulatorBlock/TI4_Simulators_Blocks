using UnityEngine;

namespace SaveCar
{
    public class VehiclesDataAdapter : VehiclesSaveData{
        public VehiclesDataAdapter(Vehicle2 _vehicle, int _id){
            vehicles[_id-1] = new VehicleDataAdapter(_vehicle, _id);
        }
    }
}