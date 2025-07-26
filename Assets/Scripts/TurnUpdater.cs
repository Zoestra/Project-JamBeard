using UnityEngine;
using TMPro;
public class TurnUpdater : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    TMP_Text _tmpTurnDisplay;
    GameManager _gameManager;
    void Start()
    {
        _gameManager = GameObject.Find("GameController").GetComponent<GameManager>();
        _tmpTurnDisplay = GameObject.Find("TurnDisplayTMP").GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        _tmpTurnDisplay.text = _gameManager.CurrentTurn;
    }
}
