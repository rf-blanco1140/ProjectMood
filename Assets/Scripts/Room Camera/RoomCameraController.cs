using UnityEngine;

public class RoomCameraController : MonoBehaviour
{
    [SerializeField] private BoolVariable movingCamera;
    [SerializeField] private Vector3Variable nodePosition;
    [SerializeField] private Vector3Variable nodeRotation;
    private Quaternion _nodeQuaternion;
   
    private void Update()
    {
        if (movingCamera.boolValue && nodePosition != null)
        {
            transform.position = Vector3.Lerp(transform.position, nodePosition.Value, Time.deltaTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, VectorToQuaternion(nodeRotation.Value), Time.deltaTime);
        }
        else return;
    }

    private Quaternion VectorToQuaternion(Vector3 vector)
    {
        _nodeQuaternion = Quaternion.Euler(vector);
        return _nodeQuaternion;
    }
}
