
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BoardState: MonoBehaviour
{
    public int board_size = 19;
    public enum BoardCell{white, black, destroyed}
    public Dictionary<Vector2, BoardCell> board_state;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    

    public bool Place_Stone(Vector3 target){ // player: 0=white, 1=black
        if (board_state.ContainsKey(target)){
            return false;
        }
        else if(target.x > board_size-1 || target.y > board_size-1){
            return false;
        }
        else{
            board_state.Add(target, (BoardCell)player);
            //todo place stone tile
            return true;
        }
    }
}