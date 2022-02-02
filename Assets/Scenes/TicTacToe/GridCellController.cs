using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridCellController : MonoBehaviour
{
    [SerializeField] private GameObject[] marks;
    [SerializeField]private Owner myOwner;
    private BoardController boardController;

    private void Start()
    {
        myOwner = Owner.None;
        boardController = GameObject.Find("Tic-tac-toe Grid").GetComponent<BoardController>();
    }

    private void OnMouseDown()
    {
        //safe that it was marked by the player
        if(myOwner == Owner.None)
        {
            boardController.AffectGrandma(GrandmaStats.Worried);
            SetNewOwner(Owner.Player);
            boardController.PlayAiTurn();
        }
        //mark this cell with the player's mark
        //Notify the board of what mark it received
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
            GetComponent<SpriteRenderer>().sprite = marks[0].GetComponent<SpriteRenderer>().sprite;
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = marks[1].GetComponent<SpriteRenderer>().sprite;
        }
    }
}
