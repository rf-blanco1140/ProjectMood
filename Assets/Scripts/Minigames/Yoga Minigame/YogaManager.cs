using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class YogaManager : MonoBehaviour
{
    [SerializeField] private List<int> _poseID = new List<int>(0);
    [SerializeField] private IntVariable _pressedID;
    [SerializeField] private InstantiateYogaButton button;
    [SerializeField] private YogaManagerUI UI;
    
    private int _totalPoses = 5;

    private void RandomizePoseID()
    {
        for (int i = 0; i < _totalPoses; i++)
        {        
            _poseID.Add(Random.Range(0,10));
        }
    }

    private void LookForCorrectID()
    {
        if (_poseID[0] == _pressedID.Value)
        {
            GoToNextPose(); 
            Debug.Log("correct");
            // + points
        }
        else
        {
            GoToNextPose();
            Debug.Log("incorrect");
            // - points
        }
    }

    private void GoToNextPose()
    {
        if (_poseID.Count <= 1)
        {
            Debug.Log("no more poses");
            //OnFinish();
            // ienumerator for finish ?
            return;
        }
        
        _poseID.RemoveAt(0);
    }
    
    private void OnEnable()
    {
        _poseID = new List<int>(0);
        RandomizePoseID();
        
        UI.DrawImages(_poseID);
        button.RemoveDuplicateButtons(_poseID);
    }

    public void OnButtonPressed()
    {
        LookForCorrectID();
    }

    /*private void OnFinish()
    {
        body.ApplyChange(20);
        _onWinGame.Raise();
        transform.parent.gameObject.SetActive(false);
    }*/
}