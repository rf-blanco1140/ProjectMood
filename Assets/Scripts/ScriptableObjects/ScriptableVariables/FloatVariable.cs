using UnityEngine;

[CreateAssetMenu(fileName = "New FloatVariable", menuName = "ScriptableObjects/FloatVariable")]
public class FloatVariable : ScriptableObject
{
    [SerializeField] private float _value;
    private float _currentValue;

    public float Value
    {
        get { return _currentValue; }
        set { _currentValue = value; }
    }

    public virtual void ApplyChange(int change)
    {
        _currentValue += change;
    }

    public virtual void SetValue(int newValue)
    {
        _currentValue = newValue;
    }

    private void OnEnable()
    {
        _currentValue = _value;
    }
}

