using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using RotaryHeart.Lib.SerializableDictionary;
public class BoardController : MonoBehaviour
{
    [SerializeField] private List<Transform> positions;
    [SerializeField] private GameObject cellPrefab;
    private bool isPlayerTurn;
    [SerializeField] private AI ai;

    private GridCellController[,] grid;
    private Owner winner;


    private void Start()
    {
        grid = new GridCellController[3, 3];
        int t = 0;

        for(int i= 0; i<3;i++)
        {
            for(int j=0; j<3; j++)
            {
                GridCellController newCell = Instantiate(cellPrefab).GetComponent<GridCellController>();
                newCell.transform.position = positions[t].transform.position;
                newCell.gameObject.AddComponent<BoxCollider2D>();
                newCell.GetComponent<BoxCollider2D>().size = new Vector2(0.42f,0.42f);
                grid[i, j] = newCell;
                t++;
            } 
        }

        isPlayerTurn = true;
    }

    private Owner WinCheck()
    {
        Owner ret = Owner.None;
        
        Owner ownerCheck = Owner.None;

        //check rows
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
                    i = 4;
                }
            }
            if(ownerCheck!=Owner.None)
            {
                Debug.Log("1");
                ret = ownerCheck;
                return ret;
            }
        }

        //Check columns
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
                Debug.Log("2");
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
            Debug.Log("3");
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
            Debug.Log("4");
            return ret;
        }

        return ret;
    }

    private void FinishGame()
    {
        Debug.Log("a winner is " + winner);
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
            isPlayerTurn = true;
        }
    }
}
