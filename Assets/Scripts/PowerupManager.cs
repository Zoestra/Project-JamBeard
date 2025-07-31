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
    DESTROY,
    GRAVITY,
    SWIRL
}

public class PowerupManager : MonoBehaviour
{

    public bool waiting_for_powerup = false;
    private BoardState _board;
    private GameManager _manager;
    private DrawStones _stones;
    public List<POWERUP> Powerup_Pool;
    private POWERUP _current_powerup;
    [SerializeField]
    private List<GameObject> PowerupPrefabs;
    

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _board = GameObject.Find("GameController").GetComponent<BoardState>();
        _manager = GameObject.Find("GameController").GetComponent<GameManager>();
        _stones = GameObject.Find("Stone_Tilemap").GetComponent<DrawStones>();
    }


    private void GeneratePool()
    {
        Powerup_Pool = new();
        
        while (Powerup_Pool.Count < 3 )
        {
            int selection = UnityEngine.Random.Range((int)0, (int)7);
            if ( !Powerup_Pool.Contains((POWERUP)selection))
            {
                Powerup_Pool.Add((POWERUP)selection);
            }
        }
    }
    

    private void DrawPool(){
        
    }
    

    public void PlacePowerup(Vector3Int target)
    {
        waiting_for_powerup = false;
        GameObject.Find("Destroy").GetComponent<DestroyStones>().onPlaceStone(target);
        
    }

    public void cleanup()
    {
        _stones.redraw_stones();
        _manager.PlayPowerup();
    }


}
