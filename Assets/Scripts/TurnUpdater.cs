using UnityEngine;
using TMPro;
using System.Collections.Generic;
public class TurnUpdater : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    TMP_Text _tmpTurnDisplay;
    GameManager _gameManager;
    public List<SpriteRenderer> bowls;
    public List<Sprite> BowlSprites;
    private SpriteRenderer _white_bowl;
    private SpriteRenderer _black_bowl;
    private Sprite _selected_sprite;
    private Sprite _bowl_sprite;
    void Start()
    {
        _gameManager = GameObject.Find("GameController").GetComponent<GameManager>();
        _tmpTurnDisplay = GameObject.Find("TurnDisplayTMP").GetComponent<TMP_Text>();
        _white_bowl = bowls[0];
        _black_bowl = bowls[1];
        _selected_sprite = BowlSprites[0];
        _bowl_sprite = BowlSprites[1];
    }

    // Update is called once per frame
    void Update()
    {
        _tmpTurnDisplay.text = _gameManager.CurrentTurn;
        Update_Bowl_Sprites();
    }

    void Update_Bowl_Sprites()
        {
            switch (_gameManager.CurrentTurn)
            {
                case "White":
                    _white_bowl.sprite = _selected_sprite;
                    _black_bowl.sprite = _bowl_sprite;
                    break;
                case "Black":
                    _white_bowl.sprite = _bowl_sprite;
                    _black_bowl.sprite = _selected_sprite;
                    break;

            }

        }

}
