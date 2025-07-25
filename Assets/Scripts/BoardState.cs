
using System.Collections.Generic;
using UnityEngine;

public class BoardState: MonoBehaviour
{
    public int Board_Size = 19;
    public enum BoardCell{white, black, destroyed}
    public Dictionary<Vector2, BoardCell> Board_State;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }


    public bool Place_Stone(Vector2 target, int player){ // player: 0=white, 1=black
        if (Board_State.ContainsKey(target)){
            return false;
        }
        else if(target.x > Board_Size-1 || target.y > Board_Size-1){
            return false;
        }
        else{
            Board_State.Add(target, (BoardCell)player);
            //todo place stone tile
            return true;
        }

    }
}