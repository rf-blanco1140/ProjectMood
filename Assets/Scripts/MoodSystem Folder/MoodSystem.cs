using UnityEngine;

public class MoodSystem : MonoBehaviour
{
    [SerializeField] private FloatVariable mind;
    [SerializeField] private FloatVariable social;
    [SerializeField] private FloatVariable hygiene;
    [SerializeField] private FloatVariable body;
    [SerializeField] private FloatVariable appetite;

    [SerializeField] private float _dropValue = 7.5f;
    [SerializeField] private float _startValue = 100f;
    
    private void Start()
    {
        mind.SetValue(_startValue);
        social.SetValue(_startValue);
        hygiene.SetValue(_startValue);
        body.SetValue(_startValue);
        appetite.SetValue(_startValue);
    }

    // drop over time
    public void DropResources()
    {
        mind.Value -= _dropValue;
        social.Value -= _dropValue;
        hygiene.Value -= _dropValue;
        body.Value -= _dropValue;
        appetite.Value -= _dropValue;
        Debug.Log(social.Value);
    }
}
