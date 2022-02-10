using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using RotaryHeart.Lib.SerializableDictionary;
using MoreMountains.Feedbacks;
public class BoardController : MonoBehaviour
{
    [SerializeField] private List<Transform> positions;
    [SerializeField] private GameObject cellPrefab;
    private bool isPlayerTurn;
    [SerializeField] private AI ai;
    [SerializeField] private GrandmaController grandmaReference;

    private GridCellController[,] grid;
    private Owner winner;
    [SerializeField] private GameObject playerVictoryMsg;
    [SerializeField] private GameObject playerDefeatMsg;
    [SerializeField] private GameObject tieMsg;

    [SerializeField] private GameObject textBubble;

    private LayerMask UI = 5;

    [SerializeField] private VoidEvent _onWinGame;
    [SerializeField] private FloatVariable social;
    [SerializeField] private MMFeedbacks failSFX;
    [SerializeField] private MMFeedbacks winSFX;

    [SerializeField] private MoodSystem moodSystemRef;


    private int numberTurns;

    private float exitTime;

    private void Start()
    {
        /**grid = new GridCellController[3, 3];
        int t = 0;

        for(int i= 0; i<3;i++)
        {
            for(int j=0; j<3; j++)
            {
                GridCellController newCell = Instantiate(cellPrefab).GetComponent<GridCellController>();
                newCell.transform.position = positions[t].transform.position;
                newCell.gameObject.AddComponent<BoxCollider2D>();
                newCell.GetComponent<BoxCollider2D>().size = new Vector2(0.42f,0.42f);
                newCell.gameObject.layer = UI;
                newCell.transform.parent = this.transform;
                grid[i, j] = newCell;
                t++;
                Debug.Log("D:");
            }
        }*/

        isPlayerTurn = true;
        exitTime = 3f;
        numberTurns = 0;
    }

    private void OnEnable()
    {
        ResetBoard();
    }

    private void ResetBoard()
    {
        if(winner!=Owner.None)
        {
            winner = Owner.None;
            AffectGrandma(GrandmaStats.Neutral);
            playerVictoryMsg.SetActive(false);
            playerDefeatMsg.SetActive(false);
            tieMsg.SetActive(false);
            textBubble.SetActive(false);
            isPlayerTurn = true;
            exitTime = 3f;
            numberTurns = 0;

            for (int i=0;i<3;i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    //grid[i, j].GetComponent<GridCellController>().SetNewOwner(Owner.None);
                    GridCellController toDie = grid[i, j];
                    Destroy(toDie.gameObject);
                }
            }
        }
        else
        {
            winner = Owner.None;
            AffectGrandma(GrandmaStats.Neutral);
            playerVictoryMsg.SetActive(false);
            playerDefeatMsg.SetActive(false);
            tieMsg.SetActive(false);
            textBubble.SetActive(false);
            isPlayerTurn = true;
            exitTime = 3f;
            numberTurns = 0;

            grid = new GridCellController[3, 3];
            int t = 0;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    GridCellController newCell = Instantiate(cellPrefab).GetComponent<GridCellController>();
                    newCell.transform.position = positions[t].transform.position;
                    newCell.gameObject.AddComponent<BoxCollider2D>();
                    newCell.GetComponent<BoxCollider2D>().size = new Vector2(0.42f, 0.42f);
                    newCell.gameObject.layer = UI;
                    newCell.transform.parent = this.transform;

                    grid[i, j] = newCell;
                    t++;
                }
            }
        }
    }

    private Owner WinCheck()
    {
        Owner ret = Owner.None;
        
        Owner ownerCheck = Owner.None;

        //Check for tie
        if(numberTurns>=9)
        {
            ret = Owner.Tie;
            return ret;
        }

        //Check columns
        for (int i=0;i<3;i++)
        {
            for(int j=0;j<3;j++)
            {
                if (j==0)
                {
                    if(grid[i, j].GetOwner() != Owner.None)
                    {
                        ownerCheck = grid[i, j].GetOwner();
                    }
                }
                else if(grid[i,j].GetOwner() != ownerCheck)
                {
                    ownerCheck = Owner.None;
                    j = 4;
                }
            }
            if(ownerCheck!=Owner.None)
            {
                ret = ownerCheck;
                return ret;
            }
        }

        //Check rows
        ownerCheck = Owner.None;
        for (int j = 0; j < 3; j++)
        {
            for (int i = 0; i < 3; i++)
            {
                if (i == 0)
                {
                    if (grid[i, j].GetOwner() != Owner.None)
                    {
                        ownerCheck = grid[i, j].GetOwner();
                    }
                }
                else if (grid[i, j].GetOwner() != ownerCheck)
                {
                    ownerCheck = Owner.None;
                    i = 3;
                }
            }
            if (ownerCheck != Owner.None)
            {
                ret = ownerCheck;
                return ret;
            }
        }

        //Check diagonals
        ownerCheck = Owner.None;
        for (int i = 0; i < 3; i++)
        {
            if (i == 0)
            {
                if (grid[i, i].GetOwner() != Owner.None)
                {
                    ownerCheck = grid[i, i].GetOwner();
                }
            }
            else if (grid[i, i].GetOwner() != ownerCheck)
            {
                ownerCheck = Owner.None;
                i = 3;
            }
            if(i==2)
            {
                ret = ownerCheck;
            }
        }
        if (ret != Owner.None)
        {
            return ret;
        }

        ownerCheck = Owner.None;
        for (int i = 0; i < 3; i++)
        {
            if (i == 0)
            {
                if (grid[2-i, i].GetOwner() != Owner.None)
                {
                    ownerCheck = grid[2-i, i].GetOwner();
                }
            }
            else if (grid[2-i, i].GetOwner() != ownerCheck)
            {
                ownerCheck = Owner.None;
                i = 3;
            }
            if (i == 2)
            {
                ret = ownerCheck;
            }
        }
        if (ret != Owner.None)
        {
            return ret;
        }

        return ret;
    }

    private void FinishGame()
    {
        textBubble.SetActive(true);
        if(winner == Owner.Player)
        {
            winSFX.PlayFeedbacks();
            AffectGrandma(GrandmaStats.Lost);
            playerVictoryMsg.SetActive(true);
        }
        else if(winner == Owner.Tie)
        {
            failSFX.PlayFeedbacks();
            AffectGrandma(GrandmaStats.Lost);
            tieMsg.SetActive(true);
        }
        else
        {
            failSFX.PlayFeedbacks();
            AffectGrandma(GrandmaStats.Vitorious);
            playerDefeatMsg.SetActive(true);
        }
        //Debug.Log("a winner is " + winner);
        AudioManager.instance.ReturnToDefault();
        social.ApplyChange(30);
        _onWinGame.Raise();

        moodSystemRef.PlayIncreaseStatAnim(Stats.Social);
    }

    private void Update()
    {
        if(winner!= Owner.None)
        {
            exitTime -= Time.deltaTime;
            if(exitTime<=0)
            {
                ResetBoard();
                transform.parent.gameObject.SetActive(false);
            }
        }
    }

    public bool IsCellAvaliable(int i, int j)
    {
        return (grid[i, j].GetOwner() == Owner.None);
    }

    public GridCellController GetCell(int i, int j)
    {
        return grid[i, j];
    }

    public void PlayAiTurn()
    {
        isPlayerTurn = false;

        winner = WinCheck();
        if (winner != Owner.None)
        {
            FinishGame();
        }
        else
        {
            ai.ChoseCell();
        }
        numberTurns++;
    }

    public void EndAiTurn()
    {
        winner = WinCheck();
        //Debug.Log("W: " + winner);
        if (winner != Owner.None)
        {
            FinishGame();
        }
        else
        {
            isPlayerTurn = true;
        }
        numberTurns++;
    }

    public void AffectGrandma(GrandmaStats newStat)
    {
        grandmaReference.ChangeExpression(newStat);
    }

    public bool GetIsPlayerTurn()
    {
        return isPlayerTurn;
    }
}
