using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

public enum POWERUP
{
    SWAP_COLORS,
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
    private List<GameObject> _prefabs;
    private Transform _canvas;
    

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _board = GameObject.Find("GameController").GetComponent<BoardState>();
        _manager = GameObject.Find("GameController").GetComponent<GameManager>();
        _stones = GameObject.Find("Stone_Tilemap").GetComponent<DrawStones>();
        _canvas = GameObject.Find("Powerup_Pool").GetComponent<RectTransform>();
    }

    public void StartRound()
    {
        GeneratePool();
        DrawPool();
    }

    private void GeneratePool()
    {
        Debug.Log("Generating Powerup Pool");
        Powerup_Pool = new();
        
        while (Powerup_Pool.Count < 3 )
        {
            int selection = UnityEngine.Random.Range((int)0, (int)7);
            if ( !Powerup_Pool.Contains((POWERUP)selection))
            {
                Debug.Log("Adding " + (POWERUP)selection + " to powerup pool");
                Powerup_Pool.Add((POWERUP)selection);
            }
        }
    }

    private void DrawPool(){
        Vector3 position1 = new(){x=-14, y=1.28F , z=0};
        Vector3 position2 = new(){x=-12.51F, y=.38F, z=0};
        Vector3 position3 = new(){x=-14.66F, y=-.82F, z=0};
        GeneratePool();
        GameObject powerup_1 = Instantiate(_prefabs[(int)Powerup_Pool[0]]);
        powerup_1.transform.parent = GameObject.Find("Canvas").transform;
        powerup_1.transform.position = position1;

        GameObject powerup_2 = Instantiate(_prefabs[(int)Powerup_Pool[1]]);
        powerup_2.transform.parent = GameObject.Find("Canvas").transform;
        powerup_2.transform.position = position2;
        
        GameObject powerup_3 = Instantiate(_prefabs[(int)Powerup_Pool[2]]);
        powerup_3.transform.parent = GameObject.Find("Canvas").transform;
        powerup_3.transform.position = position3;
    }
    

    public void PlacePowerup(Vector3Int target)
    {
        if (_manager.GAMEOVER)
        {
            Debug.Log("Disallow placing stones!");
            return;
        }
        waiting_for_powerup = false;
        GameObject.Find("Destroy(Clone)").GetComponent<DestroyStones>().onPlaceStone(target);
        
    }

    public void cleanup()
    {
        _stones.redraw_stones();
        _manager.PlayPowerup();
    }


}
