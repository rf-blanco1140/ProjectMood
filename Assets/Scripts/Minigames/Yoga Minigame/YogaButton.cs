using UnityEngine;

public class YogaButton : MonoBehaviour
{
    [SerializeField] private IntVariable _pressedID;
    [SerializeField] private VoidEvent OnButtonPressed;
    public int i;
    private void OnMouseDown()
    {
        _pressedID.SetValue(i);
        OnButtonPressed.Raise();
        
        // not presseable while animation plays 
        // if(bool ? ) return
    }
}