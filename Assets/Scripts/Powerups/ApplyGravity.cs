using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;

public class Gravity:MonoBehaviour
{
    public Dictionary<Vector3Int, BoardCell> ApplyGravity(Dictionary<Vector3Int, BoardCell> input, int current_player)
        {
            BoardState board = GameObject.Find("GameController").GetComponent<BoardState>();
            int boardSize = board.getBoardSize();
            int minVal = -boardSize/2;
            int maxVal = boardSize/2;
            Dictionary<Vector3Int, BoardCell> output = new();
            List<Vector3Int> pieceList = new List<Vector3Int>(input.Keys);
            for (int xVal = minVal; xVal <= maxVal; xVal++){
                var pieces = from piece in pieceList where piece.x == xVal select piece;
                pieces = pieces.OrderBy(p=>p.y);
                var yVal = minVal;
                foreach(var piece in pieces){
                    var space = new Vector3Int(xVal, yVal, 0);
                    yVal = yVal + 1;
                    output.Add(space, input[piece]);
                }

            }
            return output;
    }

    public void testGravity()
    {
        Debug.Log("applying gravity");
        Dictionary<Vector3Int, BoardCell> board_state = GameObject.Find("GameController").GetComponent<BoardState>().board_state;
        GameObject.Find("GameController").GetComponent<BoardState>().board_state = ApplyGravity(board_state, 0);
        
        GameObject.Find("Stone_Tilemap").GetComponent<DrawStones>().redraw_stones();
    }
}
