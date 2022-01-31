using UnityEngine;

[CreateAssetMenu(fileName = "New FloatVariable", menuName = "ScriptableObjects/FloatVariable")]
public class FloatVariable : ScriptableObject
{
    [SerializeField] private float _value;
    [SerializeField] private float _currentValue;
    [SerializeField] private float _maxValue;
    [SerializeField] private float _minValue = 0;

    public float Value
    {
        get { return _currentValue; }
        set { _currentValue = value; }
    }

    public virtual void ApplyChange(float change)
    {
        if((_currentValue + change) >= _maxValue)
        {
            _currentValue = _maxValue;
        }
        else if((_currentValue + change) <= _minValue)
        {
            _currentValue = _minValue;
        }
        else
        {
            _currentValue += change;
        }
    }

    public virtual void SetValue(float newValue)
    {
        _currentValue = newValue;
    }

    private void OnEnable()
    {
        _currentValue = _value;
    }
}

