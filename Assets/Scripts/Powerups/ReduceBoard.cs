using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReduceBoard : MonoBehaviour
{
    public Dictionary<Vector3Int, BoardCell> Reduce(
        Dictionary<Vector3Int, BoardCell> input)
    {
        Dictionary<Vector3Int, BoardCell> output = new();

        BoardState board = GameObject.Find("GameController").GetComponent<BoardState>();
        GridBuilder grid = GameObject.Find("Board_Tilemap").GetComponent<GridBuilder>();
        Camera camera    = GameObject.Find("Main Camera").GetComponent<Camera>();
        DrawStones tiles = GameObject.Find("Stone_Tilemap").GetComponent<DrawStones>();


        if(board.reduceBoardSize())
        {
            grid.redrawGrid();
            camera.orthographicSize -= 2;

            int boardSize = board.getBoardSize();
            int max  = boardSize / 2;
            int min  = -max;

            foreach (var stone in input)
            {
                if(stone.Key.x >= min && stone.Key.y <= max)
                {
                    if(stone.Key.y >= min && stone.Key.y <= max)
                    {
                        output.Add(stone.Key, stone.Value);
                    }
                }
            }

        tiles.redraw_stones();
        GameObject.Find("GameController").GetComponent<GameManager>().PlayPowerup();
        return output;
        }
        return input;
    }


    public void onClick()
    {
        Debug.Log("Retract Dong");
        Dictionary<Vector3Int, BoardCell> board_state = GameObject.Find("GameController").GetComponent<BoardState>().board_state;
        GameObject.Find("GameController").GetComponent<BoardState>().board_state = Reduce(board_state);
        GameObject.Find("GameController").GetComponent<PowerupManager>().cleanup();
        gameObject.GetComponent<Image>().enabled = false;
    }


}

