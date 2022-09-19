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
        // if (Input.GetKeyDown(KeyCode.D)) InstantiateVehicle(2);
        // if (Input.GetKeyDown(KeyCode.F)) InstantiateVehicle(3);
    }

    private void InstantiateVehicle(int vehicleId)
    {
        if (vehicleObject) Destroy(vehicleObject);

        Vector3 position = new(0, 0, -22);
        vehicleObject = Instantiate(vehicles[vehicleId], position, Quaternion.identity);
        VehicleHelper.Vehicle = vehicleId;
    }
}
