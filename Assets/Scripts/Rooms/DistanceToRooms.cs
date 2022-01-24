using UnityEngine;

public class DistanceToRooms : MonoBehaviour
{
    [SerializeField] private GameObject[] rooms;
    //[SerializeField] private float _distance;
    private float _squareDistance;
    [SerializeField] private float _minDistance;
    private Vector3 _offSet;


    private void Update()
    {
        DistanceToRoom();
    }

    private void DistanceToRoom()
    {
        foreach (var room in rooms)
        {
            _offSet = room.transform.position - transform.position;
            _squareDistance = _offSet.sqrMagnitude;

            if (_squareDistance < (_minDistance * _minDistance))
            {
                if(TryGetComponent(out Room roomss))
                {
                    roomss.raiseRoom = true;
                }
                Debug.Log(room);   
            }
            if(TryGetComponent(out Room roomsss))
            {
                roomsss.raiseRoom = false;
            }
            
        }
    }
}
