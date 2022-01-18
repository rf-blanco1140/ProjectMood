using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New IntVariableReference", menuName = "ScriptableObjects/IntVariableReference")]
public class IntVariableReference : ScriptableObject
{
    public bool useConstant = true;
    public int constantValue;
    public IntVariable variable;

    public int Value
    {
        get { return useConstant ? constantValue : variable.Value; }
        set { variable.Value = value; }
    }
}
