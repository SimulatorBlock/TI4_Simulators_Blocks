using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelColliderConfigure : MonoBehaviour
{
    [SerializeField] private PieceData pieceData;
    public int currentDirection = -1;

    // private float rayDistance = 1.0f;

    private void Start()
    {
        // AddWheelCollider();
        ConfigureMesh();
    }
    private void AddWheelCollider(){
        WheelCollider wheelCollider = this.transform.gameObject.AddComponent<WheelCollider>();
        wheelCollider.mass = 100.0f;
        wheelCollider.radius = 0.75f;
        wheelCollider.forceAppPointDistance = 0.5f;
        wheelCollider.suspensionDistance = 0.2f;
        WheelFrictionCurve fowardFriction = wheelCollider.forwardFriction;
        fowardFriction.stiffness = 2.0f;
        wheelCollider.forwardFriction = fowardFriction;
        WheelFrictionCurve sidewaysFriction = wheelCollider.sidewaysFriction;
        sidewaysFriction.stiffness = 2.0f;
        wheelCollider.sidewaysFriction = sidewaysFriction;
        // JointSpring suspensionSpring = wheelCollider.suspensionSpring;
        // suspensionSpring.spring = 90000.0f;
        // suspensionSpring.damper = 9000.0f;
    }
    private void ConfigureMesh(){
        WheelMesh wheelMesh = Instantiate<WheelMesh>(pieceData.GetWheelBlock.GetComponent<WheelMesh>(),this.transform.position, this.transform.rotation);
        wheelMesh.SetWheelCollider(this.GetComponent<WheelCollider>());
        wheelMesh.transform.SetParent(this.gameObject.transform.parent.parent);
        Quaternion _rotation = new Quaternion();
        switch (currentDirection)
        {
            case 0://forward
                _rotation.eulerAngles = new Vector3(0.0f, 90.0f, 0.0f);
                break;
            case 1://back
                _rotation.eulerAngles = new Vector3(0.0f, 270.0f, 0.0f);
                break;
            case 2://left
                _rotation.eulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
                break;
            case 3://right
                _rotation.eulerAngles = new Vector3(0.0f, 180.0f, 0.0f);
                break;
            case 4://up
                _rotation.eulerAngles = new Vector3(0.0f, 0.0f, 270.0f);
                break;
            case 5://down
                _rotation.eulerAngles = new Vector3(0.0f, 0.0f, 90.0f);
                break;
            default:
                break;
        }
        wheelMesh.transform.GetChild(1).GetChild(1).transform.rotation = _rotation;
    }
}
