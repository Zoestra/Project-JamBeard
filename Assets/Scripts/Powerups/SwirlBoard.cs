using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;
public class Swirl : MonoBehaviour
{
    public Dictionary<Vector3Int, BoardCell> ApplySwirl(Dictionary<Vector3Int, BoardCell> input, int current_player)
    {
        Dictionary<Vector3Int, BoardCell> output = new();
        List<Vector3Int> pieceList = new List<Vector3Int>(input.Keys);
        foreach (Vector3Int piece in pieceList)
        {
            output.Add(SwirlPiece(piece), input[piece]);
        }
        return output;
    }

    private Vector3Int SwirlPiece(Vector3Int input)
    {
        var x = input.x;
        var y = input.y;
        var deg = Math.Max(Math.Abs(x), Math.Abs(y));
        if (deg == 0)
        {
            return new Vector3Int(x, y, 0);
        }
        if (x == deg)
        {
            y = y + 1;
            if (y > deg)
            {
                y = deg;
                x = x - 1;
            }
        }
        else if (x == -deg)
        {
            y = y - 1;
            if (y < -deg)
            {
                y = -deg;
                x = x + 1;
            }
        }
        else if (y == deg)
        {
            x = x - 1;
            if (x < -deg)
            {
                x = -deg;
                y = y - 1;
            }
        }
        else if (y == -deg)
        {
            x = x + 1;
            if (x > deg)
            {
                x = deg;
                y = y + 1;
            }
        }
        return new Vector3Int(x, y, 0);
    }

    public void onClick()
    {
        Debug.Log("applying swirl");
        Dictionary<Vector3Int, BoardCell> board_state = GameObject.Find("GameController").GetComponent<BoardState>().board_state;
        GameObject.Find("GameController").GetComponent<BoardState>().board_state = ApplySwirl(board_state, 0);
        GameObject.Find("GameController").GetComponent<PowerupManager>().cleanup();
        gameObject.GetComponent<Image>().enabled = false;

    }
}
