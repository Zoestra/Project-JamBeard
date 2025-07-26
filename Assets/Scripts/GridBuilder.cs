using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GridBuilder : MonoBehaviour
{
    public List<Tile> GridTiles;

    public Dictionary<String, Tile> TileDict;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        TileDict = new Dictionary<string, Tile>
        {
            {"DLcorner", GridTiles[0]},
            {"DRcorner", GridTiles[1]},
            {"ULcorner", GridTiles[2]},
            {"URcorner", GridTiles[3]},
            {"cross"   , GridTiles[4]},
            {"Dedge"   , GridTiles[5]},
            {"Ledge"   , GridTiles[6]},
            {"Redge"   , GridTiles[7]},
            {"Uedge"   , GridTiles[8]},
            {"star"    , GridTiles[9]}
        };

        DrawGrid();
    }

    void DrawGrid()
    {
        int boardSize = GameObject.FindWithTag("GameController").GetComponent<BoardState>().board_size;
        Tilemap tilemap = GetComponentInParent<Tilemap>();
        
        int max  = boardSize / 2;
        int min  = -max;
        int star = max - 3;


        for (int x = min; x <= max; x++)
        {
            for (int y = min; y <= max; y++)
            {
                // left edge
                if (x == min)
                {
                    if (y == min)
                    {
                        tilemap.SetTile(new Vector3Int(x,y,0), TileDict["DLcorner"]);
                    }
                    else if (y == max)
                    {
                        tilemap.SetTile(new Vector3Int(x,y,0), TileDict["ULcorner"]);
                    }
                    else
                    {
                        tilemap.SetTile(new Vector3Int(x,y,0), TileDict["Ledge"]);
                    }
                }
                
                // center
                if (x > min && x < max)
                {
                    if (y == min)
                    {
                        tilemap.SetTile(new Vector3Int(x,y,0), TileDict["Dedge"]);
                    }
                    else if (y == max)
                    {
                        tilemap.SetTile(new Vector3Int(x,y,0), TileDict["Uedge"]);
                    }
                    else
                    {
                        tilemap.SetTile(new Vector3Int(x,y,0), TileDict["cross"]);
                    }
                    // stars
                    if ( Math.Abs(x) == star || x == 0)
                    {
                        if ( Math.Abs(y) == star || y == 0)
                        {
                            tilemap.SetTile(new Vector3Int(x,y,0), TileDict["star"]);
                        }
                    }
                }

                // right edge
                if (x == max)
                {
                    if (y == min)
                    {
                        tilemap.SetTile(new Vector3Int(x,y,0), TileDict["DRcorner"]);
                    }
                    else if (y == max)
                    {
                        tilemap.SetTile(new Vector3Int(x,y,0), TileDict["URcorner"]);
                    }
                    else
                    {
                        tilemap.SetTile(new Vector3Int(x,y,0), TileDict["Redge"]);
                    }
                }
            }
        }
    }

    void DrawVoids()
    {

    }

}