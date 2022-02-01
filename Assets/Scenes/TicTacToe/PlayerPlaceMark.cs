using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlaceMark : MonoBehaviour
{
    private bool isPlayerTurn;
    
    //0 means the player uses the o and 1 means the plasyer uses the x
    private int playerMarkID;
    
    // marks sprite list

    private void OnMouseDown()
    {
        //checks if is the player's turn
        //Check if the space is occupied by another mark
        //if not occupied, notifies that spot that it is going to be marked x or o
        //Moves to the next turn
    }
}
