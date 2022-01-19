using UnityEngine;
[CreateAssetMenu(fileName = "New Vector3Variable", menuName = "ScriptableObjects/Vector3Variable")]
public class Vector3Variable : ScriptableObject
{
    [SerializeField] private Vector3 _value;
    private Vector3 _currentValue;

    public Vector3 Value
    {
        get { return _currentValue; }
        set { _currentValue = value; }
    }

    private void OnEnable()
    {
        _currentValue = _value;
    }
}
