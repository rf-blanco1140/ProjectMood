using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    [SerializeField] private BoardController boardController;

    public void ChoseCell()
    {
        StartCoroutine(ThinkingDelay());
    }

    private IEnumerator ThinkingDelay()
    {
        float seconds = Random.Range(1f, 1.75f);
        yield return new WaitForSeconds(seconds);
        int t = 0;
        bool validOption = false;
        while (!validOption)
        {
            int i = Random.Range(0, 3);
            int j = Random.Range(0, 3);
            if (boardController.IsCellAvaliable(i, j))
            {
                validOption = true;
                boardController.GetCell(i, j).SetNewOwner(Owner.AI);
                boardController.AffectGrandma(GrandmaStats.Confident);
                //Debug.LogError("cell [" + i + "," + j + "] owner is: " + boardController.GetCell(i, j).GetOwner());
            }
            t++;
            if (t > 100)
            {
                validOption = true;
            }
        }

        boardController.EndAiTurn();
    }
}
