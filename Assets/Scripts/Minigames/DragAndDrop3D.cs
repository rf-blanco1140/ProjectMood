using System;
using UnityEngine;

public class DragAndDrop3D : MonoBehaviour
{
    [SerializeField] private Camera miniGameCamera;
    private Vector3 _offSet;
    private float _mouseZCoord;
    private void OnMouseDrag()
    {
        transform.position = GetMouseWorldPos() + _offSet;
    }

    private void OnMouseDown()
    {
        _mouseZCoord = miniGameCamera.WorldToScreenPoint(gameObject.transform.position).z;
        _offSet = gameObject.transform.position - GetMouseWorldPos();
    }

    private Vector3 GetMouseWorldPos()
    {
        Vector3 _mousePoint = Input.mousePosition;
        _mousePoint.z = _mouseZCoord;
        return miniGameCamera.ScreenToWorldPoint(_mousePoint);
    }
}