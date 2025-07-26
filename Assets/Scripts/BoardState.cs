
using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BoardState : MonoBehaviour
{
    public int board_size = 19;
    public enum BoardCell { white, black, destroyed }
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
        int boardSize = GameObject.FindWithTag("GameController").GetComponent<BoardState>().board_size;
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

    // private Vector2Int quantize_input(Vector3Int input)
    // {
    //     Vector2Int target = new()
    //     {
    //         y = (int)MathF.Round(input.y),
    //         x = (int)MathF.Round(input.x)
    //     };

    //     return target;
    // }



    private void invalid_selection()
    {
        //todo: idk, lol
        Debug.Log("invalid location");
    }
}