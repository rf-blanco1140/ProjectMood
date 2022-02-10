using UnityEngine;
using UnityEngine.UI;

public class Ending : MonoBehaviour
{
    [SerializeField] private GameObject endings;
    [SerializeField] private Sprite[] endingImages;
    [SerializeField] private EndOfDaySummary summary;
    [SerializeField] private GameObject endingCanvas;
    
    public void GetAverageForEnding()
    {       
        float i = summary.GetAverageMood();
        if(i >= 75) PickEnding(0);
        if(i >= 50 && i <= 74) PickEnding(1);
        if(i >= 25 && i <= 49) PickEnding(2);
        if(i <= 24) PickEnding(3);
    }
    
    private void PickEnding(int i)
    {
        endingCanvas.SetActive(true);
        endings.GetComponent<Image>().sprite = endingImages[i];
    }
}