using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwapColors : MonoBehaviour
{
    public Dictionary<Vector3Int, BoardCell> SwapColor(
        Dictionary<Vector3Int, BoardCell> input)
    {
        Dictionary<Vector3Int, BoardCell> output = new();

        foreach(var stone in input)
        {
            switch (stone.Value)
            {
                case (BoardCell)0:
                    output.Add(stone.Key, (BoardCell)1);
                    break;
                case (BoardCell)1:
                    output.Add(stone.Key, (BoardCell)0);
                    break;
                case (BoardCell)2:
                    break;
            }
        }

        GameObject.Find("GameController").GetComponent<GameManager>().PlayPowerup();
        return output;
    }

    

    public void onClick()
    {
        Debug.Log("swapping colors");
        Dictionary<Vector3Int, BoardCell> board_state = GameObject.Find("GameController").GetComponent<BoardState>().board_state;
        GameObject.Find("GameController").GetComponent<BoardState>().board_state = SwapColor(board_state);
        GameObject.Find("GameController").GetComponent<PowerupManager>().cleanup();
        gameObject.GetComponent<Image>().enabled = false;
    }

}