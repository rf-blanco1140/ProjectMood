using UnityEngine;

public class Room : MonoBehaviour
{
    public bool raiseRoom = true; // debug tool
    private Vector3 _goingUp;
    private Vector3 _goingDown;
    private float x;
    private float z;

    private void Awake()
    {
        x = transform.position.x;
        z = transform.position.z;
        
        _goingDown = new Vector3(x, -10, z);
        _goingUp = new Vector3(x, 0, z);
    }

    private void Update()
    {
        if (raiseRoom)
        {
            RaiseRoom();
        }
        else if (!raiseRoom)
        {
            LowerRoom();
        }
    }

    private void RaiseRoom()
    {
        transform.position = Vector3.Lerp(transform.position, _goingUp, Time.deltaTime);
    }
    private void LowerRoom()
    {
        transform.position = Vector3.Lerp(transform.position, _goingDown, Time.deltaTime);
    }

    private void ToggleBool()
    {
        raiseRoom = !raiseRoom;
    }
}
