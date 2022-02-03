using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class YogaManager : MonoBehaviour
{
    // pose appears on top
    // buttons on bottom
    // press correct one
    // ints
    [SerializeField] private VoidEvent _onWinGame;
    [SerializeField] private FloatVariable body;
    
    private List<int> _poseID = new List<int>(); // 5 poses
    public int _pressedID;

    public void CopyList(List<int> list)
    {
        foreach (var ID in _poseID)
        {
            list.Add(ID);
        }
    }

    private void RandomizePoseID()
    {
        _poseID.Add(Random.Range(0,4));
        _poseID.Add(Random.Range(0,4));
        _poseID.Add(Random.Range(0,4));
        _poseID.Add(Random.Range(0,4));
        _poseID.Add(Random.Range(0,4));
        _poseID.Add(0);
    }

    public void LookForCorrectID()
    {
        if (_poseID[0] == _pressedID)
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
            OnFinish();
            return;
        }
        
        Debug.Log($"poseID before {_poseID[0]}");
        _poseID.RemoveAt(0);
        Debug.Log($"poseID after {_poseID[0]}");
    }
    
    private void OnEnable()
    {
        RandomizePoseID();
        _pressedID = 0;
    }

    private void OnFinish()
    {
        body.ApplyChange(20);
        _onWinGame.Raise();
        transform.parent.gameObject.SetActive(false);
    }
}