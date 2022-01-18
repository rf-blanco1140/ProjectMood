using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New FloatVariableReference", menuName = "ScriptableObjects/FloatVariableReference")]
public class FloatVariableReference : ScriptableObject
{
    public bool useConstant = true;
    public float constantValue;
    public FloatVariable variable;

    public float Value
    {
        get { return useConstant ? constantValue : variable.Value; }
        set { variable.Value = value; }
    }
}
