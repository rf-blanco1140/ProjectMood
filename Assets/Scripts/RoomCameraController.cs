using UnityEngine;

public class RoomCameraController : MonoBehaviour
{
    [SerializeField] private BoolVariable movingCamera;
    [SerializeField] private Vector3Variable nodePosition;
    
    private void Update()
    {
        if (movingCamera.boolValue && nodePosition != null)
        {
            transform.position = Vector3.Lerp(transform.position, nodePosition.Value, Time.deltaTime);
        }
        else return;
    }
}
