using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class InputHandler : MonoBehaviour
{
    private Grid grid; 
        Tilemap tilemap;  

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

            
            
            gameObject.GetComponent<BoardState>().Place_Stone(target);
            
            
            // if clicked in board
                    //

            // if clicked outside of board


        }
    }
}
