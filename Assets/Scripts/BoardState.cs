
using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public enum BoardCell{white, black, destroyed}
public class BoardState: MonoBehaviour
{
    private List<int> _BoardSizes = new(){9, 13, 19, 31};
    private int _board_size = 2;
    public Dictionary<Vector3Int, BoardCell> board_state = new();

    [SerializeField]
    public List<Tile> StoneTiles;

    public int current_player = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    public void ResetBoard()
    {
        Tilemap tilemap = GameObject.Find("Stone_Tilemap").GetComponent<Tilemap>();
        foreach (Vector3Int key in board_state.Keys)
        {
            tilemap.SetTile(key, null);
        }
        board_state = new();
    }


    public bool Place_Stone(Vector3Int target, int input_player)
    { // player: 0=white, 1=black
        int boardSize = getBoardSize();
        int max = boardSize / 2;
        int min = -max;
        if (target.x < min || target.x > max || target.y < min || target.y > max)
        {
            Debug.Log("Out of bounds: " + target);
            invalid_selection();
            return false;
        }

        if (board_state.ContainsKey(target))
        {
            invalid_selection();
            return false;
        }
        else
        {
            Debug.Log("valid location, placing stone at " + target);
            board_state.Add(target, (BoardCell)input_player);
            //todo place stone tile
            Tilemap tilemap = GameObject.Find("Stone_Tilemap").GetComponent<Tilemap>();
            tilemap.SetTile(target, StoneTiles[input_player]);
            return true;
        }

    }

    public int getBoardSize()
    {
        return _BoardSizes[_board_size];
    }

    public bool increaseBoardSize()
    {
        if (_board_size < 3)
        {
            _board_size++;
            Debug.Log("Increased board size");
            return true;
        }
        else
        {
            Debug.Log("Cant increase board size past 31");
            return false;
        }
    }

    public bool reduceBoardSize()
    {
        if (_board_size > 1)
        {
            _board_size--;
            Debug.Log("Reduced board size");
            return true;
        }
        else
        {
            Debug.Log("Cant reduce board size lower than 9");
            return false;
        }
    }

    private void invalid_selection()
    {
        //todo: idk, lol
        Debug.Log("invalid location");
    }
}