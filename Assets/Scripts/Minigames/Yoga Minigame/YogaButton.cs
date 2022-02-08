using UnityEngine;

public class YogaButton : MonoBehaviour
{
    [SerializeField] private IntVariable _pressedID;
    [SerializeField] private VoidEvent OnButtonPressed;
    [SerializeField] private BoolVariable animationIsPlaying;
    
    public int i;
    private void OnMouseDown()
    {
        if(animationIsPlaying.boolValue) return;

        _pressedID.SetValue(i);
        OnButtonPressed.Raise();
    }
}