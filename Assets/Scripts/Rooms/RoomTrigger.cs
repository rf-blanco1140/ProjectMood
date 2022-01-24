using UnityEngine;

public class RoomTrigger : MonoBehaviour
{
    [SerializeField] private GameObject roomToRaise;
    [SerializeField] private GameObject roomToLower;
    private void OnTriggerEnter(Collider other)
    {
        ToggleRoomElevation(roomToRaise,true);
    }

    private void OnTriggerExit(Collider other)
    {
        ToggleRoomElevation(roomToLower,false);
    }

    private void ToggleRoomElevation(GameObject roomObject,bool raised)
    {
        roomObject.GetComponent<Room>().raiseRoom = raised;
    }
}
