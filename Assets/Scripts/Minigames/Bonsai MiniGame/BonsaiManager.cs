using System;
using TMPro;
using UnityEngine;

public class BonsaiManager : MonoBehaviour
{
    private Transform[] _allChildren;
    [SerializeField] private TextMeshProUGUI _currentText;
    [SerializeField] private TextMeshProUGUI _maxText;
    [SerializeField] private TextMeshProUGUI _minText;
    [SerializeField] private FloatVariable mind;
    

    [SerializeField] private IntVariable _currentLeafAmount;
    private int _totalLeafAmount = 0; // make non static
    private int _maxLeafAmount = 50; // make non static
    private int _minLeafAmount = 40; // make non static


    private void OnEnable()
    {
        Transform[] allChildren = transform.GetComponentsInChildren<Transform>(true);
        _allChildren = allChildren;

        for (int i = 0; i < allChildren.Length; i++)
        {
            _allChildren[i].gameObject.SetActive(true);
        }

        _totalLeafAmount = _allChildren.Length - 1;

        _currentLeafAmount.SetValue(_totalLeafAmount);

        UpdateCurrentLeaf();

        _maxText.text = "Max No of Leafs: " + _maxLeafAmount.ToString();
        _minText.text = "Min No of Leafs: " + _minLeafAmount.ToString();


    }

    public void UpdateCurrentLeaf()
    {
        _currentText.text = "Current No of Leafs: " + _currentLeafAmount.Value.ToString();
        if (_currentLeafAmount.Value >= _minLeafAmount && _currentLeafAmount.Value <= _maxLeafAmount)
        {
            _currentText.color = Color.green;
        }
        else
        {
            _currentText.color = Color.red;
        }
       
    }

    public void OnFinish() 
    {
        if(_currentLeafAmount.Value >= _minLeafAmount && _currentLeafAmount.Value <= _maxLeafAmount)
        {
           
            Debug.Log("Win");
            mind.ApplyChange(10);
            transform.parent.gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("Not Win");
            transform.parent.gameObject.SetActive(false);
        }
        AudioManager.instance.ReturnToDefault();
    }
}
