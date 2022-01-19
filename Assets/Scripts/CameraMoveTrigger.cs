using UnityEngine;

public class CameraMoveTrigger : MonoBehaviour
{
    [SerializeField] private GameObject node;
    [SerializeField] private Vector3Variable _nodeValue;
    [SerializeField] private BoolVariable movingCamera;
    private Vector3 _nodePosition;
    private void Awake()
    {
        _nodePosition = node.transform.position;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            movingCamera.boolValue = true;
            _nodeValue.Value = _nodePosition;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        movingCamera.boolValue = true;
        _nodeValue.Value = _nodePosition;
    }
}
