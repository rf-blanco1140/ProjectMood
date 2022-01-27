using UnityEngine;

[CreateAssetMenu(fileName = "New FloatVariable", menuName = "ScriptableObjects/FloatVariable")]
public class FloatVariable : ScriptableObject
{
    [SerializeField] private float _value;
    [SerializeField] private float _currentValue;
    [SerializeField] private float _maxValue;

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

