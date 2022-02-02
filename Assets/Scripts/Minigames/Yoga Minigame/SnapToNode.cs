using UnityEngine;

public class SnapToNode : MonoBehaviour
{
    // if distance between transform is less than w/e
    // set transform = nodeposition
    [SerializeField] private GameObject node;
    private float _distanceToNode = 0f;
    private float _maxDistance = 2f;
    
    private void Update()
    {
        _distanceToNode = Vector3.Distance(node.transform.position, transform.position);
        Debug.Log(_distanceToNode);
        if (_distanceToNode <= _maxDistance)
        {
            SnapTo(node);
        }
    }

    private void SnapTo(GameObject node)
    {
        transform.position = node.transform.position;
    }
}