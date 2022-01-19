using System;
using UnityEngine;

public class BonsaiManager : MonoBehaviour
{
    [SerializeField] private IntVariable _currentLeafAmount;
    private int _totalLeafAmount = 10; // make non static
    private int _maxLeafAmount = 8; // make non static
    private int _minLeafAmount = 5; // make non static

    private void Awake()
    {
        _currentLeafAmount.SetValue(_totalLeafAmount);
    }

    public void LeafCounter() 
    {
        Debug.Log(_currentLeafAmount.Value);
        if (_currentLeafAmount.Value >= _minLeafAmount && _currentLeafAmount.Value <= _maxLeafAmount)
        {
            //win 
            Debug.Log("Lagom cut!");
        }
        else
        {
            //lose
            Debug.Log("Not lagom enough :(");
        }
    }
}
