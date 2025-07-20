using System;
using System.Collections.Generic;
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
        TileDict = new Dictionary<string, Tile>{
            {"DL-corner", GridTiles[0]},
            {"DR_corner", GridTiles[1]},
            {"UL_corner", GridTiles[2]},
            {"UR_corner", GridTiles[3]},
            {"cross"    , GridTiles[4]},
            {"D_edge"   , GridTiles[5]},
            {"L_edge"   , GridTiles[6]},
            {"R_edge"   , GridTiles[7]},
            {"U_edge"   , GridTiles[8]},
            {"star"     , GridTiles[9]}
        };

        DrawGrid();
    }

    void DrawGrid()
    {
        int boardSize = GameObject.Find("GameBoard").GetComponent<GameBoard>().Board_Size;
        Tilemap tilemap = GetComponentInParent<Tilemap>();
        
        tilemap.SetTile(new Vector3Int(0,0,0), TileDict["star"]);
        tilemap.SetTile(new Vector3Int(1,1,0), TileDict["cross"]);
        tilemap.SetTile(new Vector3Int(1,-1,0), TileDict["DL-corner"]);
        

    }

    void DrawVoids()
    {

    }

}