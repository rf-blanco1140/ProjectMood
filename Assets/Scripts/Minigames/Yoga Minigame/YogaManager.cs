using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class YogaManager : MonoBehaviour
{
    [SerializeField] private List<int> _poseID = new List<int>(0);
    [SerializeField] private IntVariable _pressedID;
    [SerializeField] private InstantiateYogaButton button;
    [SerializeField] private YogaManagerUI UI;
    [SerializeField] private YogaAnimations animations;

    [SerializeField] private VoidEvent _onWinGame;
    [SerializeField] private FloatVariable body;
    
    [SerializeField] private BoolVariable animationIsPlaying;
    private int _totalPoses = 5;

    private float currentPoints;
    private bool test;
    
    private void RandomizePoseID()
    {
        for (int i = 0; i < _totalPoses; i++)
        {        
            _poseID.Add(Random.Range(0,10));
        }
    }

    private IEnumerator PlayAnimation()
    {
        StartCoroutine(animations.PlayYogaAnimation(_pressedID.Value));
        yield return new WaitForSeconds(4);
        GoToNextPose();
    }
    
    private void LookForCorrectID() // redo ?
    {
        if (_poseID[0] == _pressedID.Value)
        {
            StartCoroutine(PlayAnimation());
            Debug.Log("correct");
        }
        else
        {
            Debug.Log("incorrect");
        }
    }

    private void GoToNextPose()
    {
        if (_poseID.Count <= 1)
        {
            Debug.Log("no more poses");
            StartCoroutine(OnFinish());
            return;
        }
        
        _poseID.RemoveAt(0);
    }
    
    private void OnEnable()
    {
        animationIsPlaying.boolValue = false;
        _poseID = new List<int>(0);
        RandomizePoseID();
        
        UI.DrawImages(_poseID);
        button.RemoveDuplicateButtons(_poseID);
    }

    public void OnButtonPressed()
    {
        LookForCorrectID();
            
        if (_poseID[0] == _pressedID.Value)
        {
            UI.OnButtonPressed();
        }
    }

    private IEnumerator OnFinish()
    {
        body.ApplyChange(20);
        _onWinGame.Raise();
        transform.parent.gameObject.SetActive(false);
        Debug.Log("won!");
        yield return new WaitForSeconds(1);
    }
}