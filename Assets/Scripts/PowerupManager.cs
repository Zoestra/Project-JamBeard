using System;
using System.Collections.Generic;
using UnityEngine;

public enum POWERUP
{
    SWAP_COLORS,
    EXPAND_BOARD,
    REDUCE_BOARD,
    SHUFFLE_BOARD,
    RESET,
    DESTROY
}

public class PowerupManager : MonoBehaviour
{

    private POWERUP _current_powerup;
    public bool waiting_for_powerup = false;
    private BoardState _board;
    private GameManager _manager;
    private DrawStones _stones;
    

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _board = GameObject.Find("GameController").GetComponent<BoardState>();
        _manager = GameObject.Find("GameController").GetComponent<GameManager>();
        _stones = GameObject.Find("Stone_Tilemap").GetComponent<DrawStones>();
    }


    public void cleanup()
    {
        _stones.redraw_stones();
        _manager.PlayPowerup();
    }

    public void PlacePowerup(Vector3Int target)
    {
        waiting_for_powerup = false;
        // switch (_current_powerup)
        // {
        // case POWERUP.DESTROY: 
        //     GameObject.Find("Destroy").GetComponent<DestroyStones>().onPlaceStone(target);
        //     break;
        // }           
        GameObject.Find("Destroy").GetComponent<DestroyStones>().onPlaceStone(target);
        
    }

}
