using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    [SerializeField] private BoardController boardController;

    public void ChoseCell()
    {
        int t = 0;
        bool validOption = false;
        while(!validOption)
        {
            int i = Random.Range(0, 3);
            int j = Random.Range(0, 3);
            if(boardController.IsCellAvaliable(i,j))
            {
                validOption = true;
                boardController.GetCell(i,j).SetNewOwner(Owner.AI);
            }
            t++;
            if(t>100)
            {

                validOption = true;
            }
        }
    }

    private void EmergencyMeassures()
    {

    }
}
