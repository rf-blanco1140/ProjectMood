using UnityEngine;

public class WashingMinigameManager : MonoBehaviour
{
    [SerializeField] private Transform[] dirt;
    [SerializeField] private Material dirtMaterial;
    [SerializeField] private VoidEvent _onWinGame;
    [SerializeField] private FloatVariable hygiene;
    
    private void OnEnable()
    {
        for (int i = 0; i < dirt.Length; i++)
        {
            dirt[i].GetComponent<Renderer>().material = dirtMaterial;
        }
    }
    
    private void OnFinish()
    {
        hygiene.ApplyChange(20);
        _onWinGame.Raise();
        transform.parent.gameObject.SetActive(false);
    }


    public void GetAverageTransparency(int additive)
    {
        int _totalDirtTransparency = 0;
        _totalDirtTransparency += additive;
        
        if (_totalDirtTransparency >= dirt.Length - 1)
        {
            OnFinish();
        }
    }
}