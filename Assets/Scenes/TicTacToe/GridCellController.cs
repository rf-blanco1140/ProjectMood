using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Feedbacks;

public class GridCellController : MonoBehaviour
{
    [SerializeField] private GameObject[] marks;
    [SerializeField]private Owner myOwner;
    private BoardController boardController;
    [SerializeField] private MMFeedbacks placeBlockSFX;

    private void Start()
    {
        myOwner = Owner.None;
        boardController = GameObject.Find("Tic-tac-toe Grid").GetComponent<BoardController>();
    }

    private void OnMouseDown()
    {
        if(boardController.GetIsPlayerTurn())
        {
            if(myOwner == Owner.None)
            {
                boardController.AffectGrandma(GrandmaStats.Worried);
                SetNewOwner(Owner.Player);
                boardController.PlayAiTurn();
            }
        }
    }

    public Owner GetOwner()
    {
        return myOwner;
    }

    public void SetNewOwner(Owner newOwner)
    {
        myOwner = newOwner;
        if(myOwner==Owner.Player)
        {
            placeBlockSFX.PlayFeedbacks();
            GetComponent<SpriteRenderer>().sprite = marks[0].GetComponent<SpriteRenderer>().sprite;
        }
        else
        {
            placeBlockSFX.PlayFeedbacks();
            GetComponent<SpriteRenderer>().sprite = marks[1].GetComponent<SpriteRenderer>().sprite;
        }
    }
}
