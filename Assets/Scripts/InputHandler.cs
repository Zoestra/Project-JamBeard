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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        grid = GameObject.Find("GameBoard").GetComponent<Grid>();
        tilemap = GameObject.Find("Stone_Tilemap").GetComponent<Tilemap>();
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
                x = (int)MathF.Round(mouse_input.x),
                z = 0
            };



            Debug.Log("input recieved at" + target);


            GameManager gameManager = gameObject.GetComponent<GameManager>();
            gameManager.TakeTurnMove(target);



            // if clicked in board
            //

            // if clicked outside of board


        }
        Vector3Int mousePos = tilemap.WorldToCell(
            Camera.main.ScreenToWorldPoint(Input.mousePosition)
        );
        if (!mousePos.Equals(previousTilePos)) {
            tilemap.SetTile(previousTilePos, null); // Remove old hoverTile
            tilemap.SetTile(mousePos, HoverTile);
            previousTilePos = mousePos;
        }

    }
}
