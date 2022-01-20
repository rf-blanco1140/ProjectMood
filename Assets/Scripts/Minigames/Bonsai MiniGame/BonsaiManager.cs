using System;
using UnityEngine;

public class BonsaiManager : MonoBehaviour
{
    [SerializeField] private IntVariable _currentLeafAmount;
    private int _totalLeafAmount = 15; // make non static
    //private int _maxLeafAmount = 12; // make non static
    private int _minLeafAmount = 9; // make non static

    private void Awake()
    {
        _currentLeafAmount.SetValue(_totalLeafAmount);
    }

    public void LeafCounter() 
    {
        if(_currentLeafAmount.Value == _minLeafAmount)
        {
            Debug.Log("Win");
            transform.parent.gameObject.SetActive(false);
        }


        //temprary comment out before the logic is done.

        //Debug.Log(_currentLeafAmount.Value);
        //if (_currentLeafAmount.Value >= _minLeafAmount && _currentLeafAmount.Value <= _maxLeafAmount)
        //{
        //    //win 
        //    Debug.Log("Lagom cut!");
        //    transform.parent.gameObject.SetActive(false);
        //}
        //else
        //{
        //    //lose
        //    Debug.Log("Not lagom enough :(");
        //}
    }
}
