using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DrawStones : MonoBehaviour
{
    
    [SerializeField]
    public List<Tile> StoneTiles;
    public void place_stone(Vector3Int target, int player)
    {
        Tilemap tilemap = GameObject.Find("Stone_Tilemap").GetComponent<Tilemap>();
        tilemap.SetTile(target, StoneTiles[player]);
    }


    public void redraw_stones()
    {

        Tilemap tilemap = GameObject.Find("Stone_Tilemap").GetComponent<Tilemap>();
        tilemap.ClearAllTiles();

        Dictionary<Vector3Int, BoardCell> board_state = GameObject.Find("GameController").GetComponent<BoardState>().board_state;

        foreach (var stone in board_state)
        {
            switch (stone.Value)
            {
                case BoardCell.white:
                    tilemap.SetTile(stone.Key, StoneTiles[0]);
                    break;
            case BoardCell.black:
                    tilemap.SetTile(stone.Key, StoneTiles[1]);
                    break;
            default:
                    break;

            }
            
        }
        

    }
}
