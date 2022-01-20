using System;
using UnityEngine;

public class BonsaiManager : MonoBehaviour
{
    private Transform[] _allChildren;
    [SerializeField] private IntVariable _currentLeafAmount;
    private int _totalLeafAmount = 15; // make non static
    //private int _maxLeafAmount = 12; // make non static
    private int _minLeafAmount = 10; // make non static


    private void OnEnable()
    {
        Transform[] allChildren = transform.parent.gameObject.transform.GetComponentsInChildren<Transform>(true);
        _allChildren = allChildren;
        for (int i = 0; i < allChildren.Length; i++)
        {
            allChildren[i].gameObject.SetActive(true);
        }

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
