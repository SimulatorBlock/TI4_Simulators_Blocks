using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelColliderConfigure : MonoBehaviour
{
    [SerializeField] private PieceData pieceData;

    // private float rayDistance = 1.0f;

    private void Start()
    {
        AddWheelCollider();
        ConfigureMesh();
    }
    private void AddWheelCollider(){
        WheelCollider wheelCollider = this.transform.gameObject.AddComponent<WheelCollider>();
        wheelCollider.mass = 100.0f;
        wheelCollider.radius = 0.75f;
        wheelCollider.forceAppPointDistance = 0.5f;
        wheelCollider.suspensionDistance = 0.0f;
        WheelFrictionCurve fowardFriction = wheelCollider.forwardFriction;
        fowardFriction.stiffness = 2.0f;
        wheelCollider.forwardFriction = fowardFriction;
        WheelFrictionCurve sidewaysFriction = wheelCollider.sidewaysFriction;
        sidewaysFriction.stiffness = 2.0f;
        wheelCollider.sidewaysFriction = sidewaysFriction;
    }
    private void ConfigureMesh(){
        WheelMesh wheelMesh = Instantiate<WheelMesh>(pieceData.GetWheelBlock.GetComponent<WheelMesh>(),this.transform.position, this.transform.rotation);
        wheelMesh.SetWheelCollider(this.GetComponent<WheelCollider>());
        wheelMesh.transform.SetParent(this.gameObject.transform.parent.parent);
    }
}
