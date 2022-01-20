using UnityEngine;

public class CameraMoveTrigger : MonoBehaviour
{
    [SerializeField] private GameObject node;
    [SerializeField] private Vector3Variable _nodeValue;
    [SerializeField] private Vector3Variable _nodeRotationValue;
    [SerializeField] private BoolVariable movingCamera;
    private Vector3 _nodePosition;
    private Quaternion _nodeRotation;
    private void Awake()
    {
        _nodePosition = node.transform.position;
        _nodeRotation = node.transform.rotation;
    }

    private void OnTriggerEnter(Collider other)
    {
        movingCamera.boolValue = true;
        _nodeValue.Value = _nodePosition;
        _nodeRotationValue.Value = _nodeRotation.eulerAngles;
    }
}
