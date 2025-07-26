using UnityEngine;
using System.Collections;
using TMPro;
public enum PlayerStoneColor
{
    WHITE,
    BLACK
}
public class GameManager : MonoBehaviour
{

    /*
     1. Initialize the game board and special stones. 
     2. Perform our pre-game "Swap" opening. 
     3. Start normal play.
     4. After each turn:
        - Check for a win condition.
        - On win display popup.
    */

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    BoardState _boardState;
    PlayerStoneColor current_players_turn = PlayerStoneColor.BLACK;
    public string CurrentTurn;
    bool _gameOver = false;

    void Start()
    {
        _boardState = GameObject.Find("GameController").GetComponent<BoardState>();

        CurrentTurn = "Black";
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeTurnMove(Vector3Int moveTarget)
    {
        if (_gameOver)
        {
            return;
        }
        if (!_boardState.Place_Stone(moveTarget, (int)current_players_turn))
        {
            return;
        }

        if (CheckWin())
        {
            if (current_players_turn == PlayerStoneColor.BLACK)
            {
                CurrentTurn = "Black Wins!";
            }
            else
            {
                CurrentTurn = "White Wins!";
            }
            _gameOver = true;
            return;
        }
        else
        {
            // Change player's turn after the move
            if (current_players_turn == PlayerStoneColor.BLACK)
            {
                current_players_turn = PlayerStoneColor.WHITE;
                CurrentTurn = "White";
            }
            else
            {
                current_players_turn = PlayerStoneColor.BLACK;
                CurrentTurn = "Black";
            }
        }
    }

    private bool CheckWin()
    {
        return CheckHorizontal() || CheckVertical() || CheckDiagonal();
    }
    bool CheckHorizontal()
    {
        foreach (Vector3Int key in _boardState.board_state.Keys)
        {
            int counter = 0;
            PlayerStoneColor player = (PlayerStoneColor)(int)_boardState.board_state[key];
            for (int i = 0; i < 5; i++)
            {
                Vector3Int potentialKey = new();
                potentialKey.x = key.x + i;
                potentialKey.y = key.y;
                potentialKey.z = key.z;

                if (_boardState.board_state.ContainsKey(potentialKey) && (PlayerStoneColor)(int)_boardState.board_state[potentialKey] == player)
                {
                    counter++;
                }
            }
            if (counter == 5)
            {
                return true;
            }
        }
        return false;
    }
    bool CheckVertical()
    {
        foreach (Vector3Int key in _boardState.board_state.Keys)
        {
            int counter = 0;
            PlayerStoneColor player = (PlayerStoneColor)(int)_boardState.board_state[key];
            for (int j = 0; j < 5; j++)
            {
                Vector3Int potentialKey = new();
                potentialKey.x = key.x;
                potentialKey.y = key.y + j;
                potentialKey.z = key.z;

                if (_boardState.board_state.ContainsKey(potentialKey) && (PlayerStoneColor)(int)_boardState.board_state[potentialKey] == player)
                {
                    counter++;
                }
            }
            if (counter == 5)
            {
                return true;
            }
        }
        return false;
    }
    bool CheckDiagonal()
    {
        foreach (Vector3Int key in _boardState.board_state.Keys)
        {
            int counter = 0;
            PlayerStoneColor player = (PlayerStoneColor)(int)_boardState.board_state[key];
            for (int k = 0; k < 5; k++)
            {
                Vector3Int potentialKey = new();
                potentialKey.x = key.x + k;
                potentialKey.y = key.y + k;
                potentialKey.z = key.z;

                if (_boardState.board_state.ContainsKey(potentialKey) && (PlayerStoneColor)(int)_boardState.board_state[potentialKey] == player)
                {
                    counter++;
                }
            }
            if (counter == 5)
            {
                return true;
            }
            counter = 0;
            for (int k = 0; k < 5; k++)
            {
                Vector3Int potentialKey = new();
                potentialKey.x = key.x - k;
                potentialKey.y = key.y - k;
                potentialKey.z = key.z;

                if (_boardState.board_state.ContainsKey(potentialKey) && (PlayerStoneColor)(int)_boardState.board_state[potentialKey] == player)
                {
                    counter++;
                }
            }
            if (counter == 5)
            {
                return true;
            }
            counter = 0;
            for (int k = 0; k < 5; k++)
            {
                Vector3Int potentialKey = new();
                potentialKey.x = key.x - k;
                potentialKey.y = key.y + k;
                potentialKey.z = key.z;

                if (_boardState.board_state.ContainsKey(potentialKey) && (PlayerStoneColor)(int)_boardState.board_state[potentialKey] == player)
                {
                    counter++;
                }
            }
            if (counter == 5)
            {
                return true;
            }
            counter = 0;
            for (int k = 0; k < 5; k++)
            {
                Vector3Int potentialKey = new();
                potentialKey.x = key.x + k;
                potentialKey.y = key.y - k;
                potentialKey.z = key.z;

                if (_boardState.board_state.ContainsKey(potentialKey) && (PlayerStoneColor)(int)_boardState.board_state[potentialKey] == player)
                {
                    counter++;
                }
            }
            if (counter == 5)
            {
                return true;
            }
        }
        return false;
    }
    public void ResetGame()
    {
        CurrentTurn = "Black";
        _boardState.ResetBoard();
        _gameOver = false;
    }

    public void PlayPowerup()
    {
            // Change player's turn after the move
            if (current_players_turn == PlayerStoneColor.BLACK)
            {
                current_players_turn = PlayerStoneColor.WHITE;
                CurrentTurn = "White";
            }
            else
            {
                current_players_turn = PlayerStoneColor.BLACK;
                CurrentTurn = "Black";
            }
    }
}
