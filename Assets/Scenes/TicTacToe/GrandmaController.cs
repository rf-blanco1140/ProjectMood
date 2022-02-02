using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public enum GrandmaStats
{
    Neutral, Vitorious, Lost, Confident, Worried
}

public class GrandmaController : MonoBehaviour
{
    [SerializeField] private Image myFace;
    [SerializeField] private Sprite[] spriteList;

    private void Start()
    {
        ChangeExpression(GrandmaStats.Neutral);
    }

    public void ChangeExpression(GrandmaStats newStat)
    {
        switch(newStat)
        {
            case GrandmaStats.Neutral:
                myFace.sprite = spriteList[0];
                break;
            case GrandmaStats.Vitorious:
                myFace.sprite = spriteList[1];
                break;
            case GrandmaStats.Lost:
                myFace.sprite = spriteList[2];
                break;
            case GrandmaStats.Confident:
                myFace.sprite = spriteList[3];
                break;
            case GrandmaStats.Worried:
                myFace.sprite = spriteList[4];
                break;
        }
    }
}
