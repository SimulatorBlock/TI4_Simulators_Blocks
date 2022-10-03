using UnityEngine;

public class VehicleChanger : MonoBehaviour
{
    [SerializeField] private GameObject vehicleObject;
    [SerializeField] private GameObject[] vehicles;

    private void Start()
    {
        int vehicleId = VehicleHelper.Vehicle;
        InstantiateVehicle(vehicleId);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) InstantiateVehicle(0);
        if (Input.GetKeyDown(KeyCode.Alpha2)) InstantiateVehicle(1);
        if (Input.GetKeyDown(KeyCode.Alpha3)) InstantiateVehicle(2);
        if (Input.GetKeyDown(KeyCode.Alpha4)) InstantiateVehicle(3);
        if (Input.GetKeyDown(KeyCode.Alpha5)) InstantiateVehicle(4);
        if (Input.GetKeyDown(KeyCode.Alpha6)) InstantiateVehicle(5);
        if (Input.GetKeyDown(KeyCode.Alpha7)) InstantiateVehicle(6);
        if (Input.GetKeyDown(KeyCode.Alpha8)) InstantiateVehicle(7);
    }

    private void InstantiateVehicle(int vehicleId)
    {
        if (vehicleObject) Destroy(vehicleObject);

        Vector3 position = new(0, 1, -20);
        vehicleObject = Instantiate(vehicles[vehicleId], position, Quaternion.identity);
        VehicleHelper.Vehicle = vehicleId;
    }
}
