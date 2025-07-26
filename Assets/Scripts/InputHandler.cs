using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class InputHandler : MonoBehaviour
{
    private Grid grid; 
    Tilemap tilemap;
    Vector3Int previousTilePos;
    public Tile HoverTile;
    BoardState _boardState;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        grid = GameObject.Find("GameBoard").GetComponent<Grid>();
        tilemap = GameObject.Find("Stone_Tilemap").GetComponent<Tilemap>();
        _boardState = GameObject.Find("GameController").GetComponent<BoardState>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //get position
            Vector3 mouse_input = tilemap.WorldToCell(
                Camera.main.ScreenToWorldPoint(Input.mousePosition)
                );
            Vector3Int target = new()
            {
                y = (int)MathF.Round(mouse_input.y),
                x = (int)MathF.Round(mouse_input.x)
            };



            Debug.Log("input recieved at" + target);


            GameManager gameManager = gameObject.GetComponent<GameManager>();
            gameManager.TakeTurnMove(target);
        }

        Vector3Int mousePos = tilemap.WorldToCell(
            Camera.main.ScreenToWorldPoint(Input.mousePosition)
        );

        int boardSize = _boardState.board_size;
        int max = boardSize / 2;
        int min = -max;

        if (mousePos.x < min || mousePos.x > max || mousePos.y < min || mousePos.y > max)
        {
            if (
                !_boardState.board_state.ContainsKey(mousePos))
            {
                tilemap.SetTile(previousTilePos, null); 
                return;
            }
        }

        if (
                !mousePos.Equals(previousTilePos) &&
                !_boardState.board_state.ContainsKey(mousePos))
            {
                if (!_boardState.board_state.ContainsKey(previousTilePos))
                {
                    tilemap.SetTile(previousTilePos, null); // Remove old hoverTile
                }

                tilemap.SetTile(mousePos, HoverTile);
                previousTilePos = mousePos;
            }
    }
}
