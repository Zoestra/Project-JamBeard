using UnityEngine;
using TMPro;
using System.Collections.Generic;
public class TurnUpdater : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    TMP_Text _tmpTurnDisplay;
    GameManager _gameManager;
    PowerupManager _powerMan;
    public List<SpriteRenderer> bowls;
    public List<Sprite> BowlSprites;
    private SpriteRenderer _white_bowl;
    private SpriteRenderer _black_bowl;
    private SpriteRenderer _super_bowl;
    private Sprite _selected_sprite;
    private Sprite _bowl_sprite;
    void Start()
    {
        _gameManager = GameObject.Find("GameController").GetComponent<GameManager>();
        _powerMan = GameObject.Find("GameController").GetComponent<PowerupManager>();
        _white_bowl = bowls[0];
        _black_bowl = bowls[1];
        _super_bowl = bowls[2];
        _selected_sprite = BowlSprites[0];
        _bowl_sprite = BowlSprites[1];
    }

    // Update is called once per frame
    void Update()
    {
        if (!_powerMan.waiting_for_powerup)
        {
            switch (_gameManager.CurrentTurn)
            {
                case "White":
                    _white_bowl.sprite = _selected_sprite;
                    _black_bowl.sprite = _bowl_sprite;
                    _super_bowl.sprite = _bowl_sprite;
                    break;
                case "Black":
                    _white_bowl.sprite = _bowl_sprite;
                    _black_bowl.sprite = _selected_sprite;
                    _super_bowl.sprite = _bowl_sprite;
                    break;
                default:
                    _white_bowl.sprite = _bowl_sprite;
                    _black_bowl.sprite = _bowl_sprite;
                    _super_bowl.sprite = _bowl_sprite;
                    break;

            }
        }
        else{
            _super_bowl.sprite = _selected_sprite;
        }
    }
}
