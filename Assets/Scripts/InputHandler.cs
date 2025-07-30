using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class InputHandler : MonoBehaviour
{
    private Vector3Int previousTilePos;
    public Tile HoverTile;
    public List<Tile> HoverTiles;

    private Tilemap tilemap;
    private Grid grid; 
    private BoardState _board;
    private PowerupManager _power_man;
    private GameManager _gameManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        grid = GameObject.Find("GameBoard").GetComponent<Grid>();
        tilemap = GameObject.Find("Stone_Tilemap").GetComponent<Tilemap>();
        _board = gameObject.GetComponent<BoardState>();
        _power_man = gameObject.GetComponent<PowerupManager>();
        _gameManager = gameObject.GetComponent<GameManager>();

        HoverTile = HoverTiles[1];
    }

    // Update is called once per frame
    void Update()
    {
        // on click
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

            if (_power_man.waiting_for_powerup)
            {
                 _power_man.PlacePowerup(target);   
            }
            else
            {
                _gameManager.TakeTurnMove(target);
            }
        }

        // on hover

        Vector3Int mousePos = tilemap.WorldToCell(
            Camera.main.ScreenToWorldPoint(Input.mousePosition)
        );

        int boardSize = _board.getBoardSize();
        int max = boardSize / 2;
        int min = -max;

        if (mousePos.x < min || mousePos.x > max || mousePos.y < min || mousePos.y > max)
        {
            if (
                !_board.board_state.ContainsKey(mousePos))
            {
                tilemap.SetTile(previousTilePos, null); 
                return;
            }
        }

        if (
                !mousePos.Equals(previousTilePos) &&
                !_board.board_state.ContainsKey(mousePos))
            {
                if (!_board.board_state.ContainsKey(previousTilePos))
                {
                    tilemap.SetTile(previousTilePos, null); // Remove old hoverTile
                }

                tilemap.SetTile(mousePos, HoverTile);
                previousTilePos = mousePos;
            }
    }

    public void SwapHoverTiles()
    {
        switch (_gameManager.current_players_turn)
        {
            case PlayerStoneColor.WHITE:
                HoverTile = HoverTiles[0];
                break;
          
            case PlayerStoneColor.BLACK:
                HoverTile = HoverTiles[1];
                break;  
        }

        // if (_gameManager.CurrentTurn == "WHITE")
        // {
        //     HoverTile = HoverTiles[0];
        // }
        // else if (_gameManager.CurrentTurn == "BLACK")
        // {
        //     HoverTile = HoverTiles[1];
        // }
    }
}
