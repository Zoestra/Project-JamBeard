using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestroyStones : MonoBehaviour
{


    private BoardState _board;
    private PowerupManager _manager;
    private InputHandler _input;
    private Vector3Int _target;
    private Dictionary<Vector3Int, BoardCell> output;
    private int min;
    private int max;
 
    public void onClick()
    {
        _board = GameObject.Find("GameController").GetComponent<BoardState>();
        _manager = GameObject.Find("GameController").GetComponent<PowerupManager>();
        _input = GameObject.Find("GameController").GetComponent<InputHandler>();
 
        _input.HoverTile = _input.HoverTiles[2];
        _manager.waiting_for_powerup = true;
    }
    
    public void onPlaceStone(Vector3Int target)
    {
        _target = target;
        output = new();

        max = _board.getBoardSize() / 2;
        min = -max;

        foreach(var stone in _board.board_state)
        {
            output.Add(stone.Key, stone.Value);
        }

        switch (Random.Range((int) 0, (int) 4))
        {
            case 0:
                destroy_horiz();
                break;
            case 1:
                destroy_vert();
                break;
            case 2:
                destroy_square();
                break;
            case 3:
                destroy_diag_f();
                break;
            case 4:
                destroy_diag_b();
                break;
        }

        _board.board_state = output;

        _manager.cleanup();
        gameObject.GetComponent<Image>().enabled = false;

    }

    private void destroy_horiz()
    {
        int y = _target.y;
        for(int x = min; x < max; x++){
            output.Remove(new Vector3Int(){x = x, y = y, z = 0});
        }
    }

    private void destroy_vert()
    {
        int x = _target.x;
        for(int y = min; y < max; y++){
            output.Remove(new Vector3Int(){x = x, y = y, z = 0});
        }
    }

    private void destroy_square()
    {
        int n = 1; 

        for (int x = _target.x - n; x < _target.x + n; x++)
        {
            for (int y = _target.y - n; y < _target.y + n; y++)
            {
                output.Remove(new Vector3Int(){x = x, y = y, z = 0});
            }
        }
    }

    private void destroy_diag_f()
    {
        int x = _target.x;
        int y = _target.y;

        for (int i = 0; i < _board.getBoardSize(); i++)
        {
            if (x + i < max || y + i < max)
            {
                output.Remove(new Vector3Int(){x = x + i, y = y + i, z = 0});
            }
            if (x - i > min || y - i > min)
            {
                output.Remove(new Vector3Int(){x = x - i, y = y - i, z = 0});
            }
        }
    }

    private void destroy_diag_b()
    {
        int x = _target.x;
        int y = _target.y;

        for (int i = 0; i < _board.getBoardSize(); i++)
        {
            if (x + i < max || y - i < min)
            {
                output.Remove(new Vector3Int(){x = x + i, y = y - i, z = 0});
            }
            if (x - i > min || y + i > max)
            {
                output.Remove(new Vector3Int(){x = x - i, y = y + i, z = 0});
            }
        }
    }

}

