using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExpandBoard : MonoBehaviour
{
    public Dictionary<Vector3Int, BoardCell> Expand(
        Dictionary<Vector3Int, BoardCell> input)
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

        GameObject.Find("GameController").GetComponent<GameManager>().PlayPowerup();
        return input;
    }



    public void onClick()
    {
        Debug.Log("Expand Dong");
        Dictionary<Vector3Int, BoardCell> board_state = GameObject.Find("GameController").GetComponent<BoardState>().board_state;
        GameObject.Find("GameController").GetComponent<BoardState>().board_state = Expand(board_state);
        GameObject.Find("GameController").GetComponent<PowerupManager>().cleanup();
        gameObject.GetComponent<Image>().enabled = false;
    }


}
