using System.Collections.Generic;
using UnityEngine;

public class ExpandBoard : MonoBehaviour
{
    public Dictionary<Vector3Int, BoardCell> Expand(
        Dictionary<Vector3Int, BoardCell> input, int current_player)
    {
        BoardState board = GameObject.Find("GameController").GetComponent<BoardState>();
        GridBuilder grid = GameObject.Find("Board_Tilemap").GetComponent<GridBuilder>();
        Camera camera    = GameObject.Find("Main Camera").GetComponent<Camera>();
        if(board.increaseBoardSize())
        {
            grid.redrawGrid();
            if(camera.orthographicSize == 10)
            {
                camera.orthographicSize = 17;
            }
            else
            {
                camera.orthographicSize += 2;
            }
        }
        return input;
    }



    public void testEnlarge()
    {
        Debug.Log("Expand Dong");
        Dictionary<Vector3Int, BoardCell> board_state = GameObject.Find("GameController").GetComponent<BoardState>().board_state;
        GameObject.Find("GameController").GetComponent<BoardState>().board_state = Expand(board_state, 0);
        GameObject.Find("Stone_Tilemap").GetComponent<DrawStones>().redraw_stones();
    }


}
