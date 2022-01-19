using UnityEngine;
[CreateAssetMenu(fileName = "New BoolVariable", menuName = "ScriptableObjects/BoolVariable")]
public class BoolVariable : ScriptableObject 
{
    public bool boolValue;

    public bool SetActive()
    {
        boolValue = true;
        return boolValue;
    }
    
    public bool SetInactive()
    {
        boolValue = false;
        return boolValue;
    }

    public bool ReturnBoolValue()
    {
        return boolValue;
    }
}
