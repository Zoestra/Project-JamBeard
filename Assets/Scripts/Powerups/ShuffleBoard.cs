using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
public class ShuffleBoard : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Shuffle()
    {

        // Number of (turns - 2)/2 = number of pieces shuffled
        Debug.Log("Board Shuffled");
        GameManager gameManager = GameObject.Find("GameController").GetComponent<GameManager>();
        BoardState boardState = GameObject.Find("GameController").GetComponent<BoardState>();
        if (gameManager.TurnNumber < 4)
        {
            return;
        }
        // Separate out the stones
        List<Vector3Int> white = new List<Vector3Int>();
        List<Vector3Int> black = new List<Vector3Int>();
        foreach (Vector3Int key in boardState.board_state.Keys)
        {
            if (boardState.board_state[key] == 0)
            {
                white.Add(key);
            }
            else
            {
                black.Add(key);
            }
        }

        // Randomly pick n of each
        int n = 3;//(gameManager.TurnNumber - 2) / 2;

        List<Vector3Int> rndWhite = Enumerable
            .Range(0, n)
            .Select(x => UnityEngine.Random.Range(0, 1 + white.Count - n))
            .OrderBy(x => x)
            .Select((x, i) => white[x + i])
            .ToList();

        List<Vector3Int> rndBlack = Enumerable
            .Range(0, n)
            .Select(x => UnityEngine.Random.Range(0, 1 + black.Count - n))
            .OrderBy(x => x)
            .Select((x, i) => black[x + i])
            .ToList();

        //Swap them. Black stones become white stones, White stones become black stones. 
        foreach (Vector3Int key in rndWhite)
        {
            boardState.board_state[key] = (BoardCell)1;
        }

        foreach (Vector3Int key in rndBlack)
        {
            boardState.board_state[key] = (BoardCell)0;
        }
        GameObject.Find("GameController").GetComponent<BoardState>().board_state = boardState.board_state;
        GameObject.Find("Stone_Tilemap").GetComponent<DrawStones>().redraw_stones();
    }
}
