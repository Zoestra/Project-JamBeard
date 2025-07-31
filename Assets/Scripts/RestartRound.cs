using UnityEngine;
using UnityEngine.UI;
public class RestartRound : MonoBehaviour
{
    public void ResetRoundPowerup()
    {
        GameManager gameManager = GameObject.Find("GameController").GetComponent<GameManager>();
        gameManager.ResetGame();
        gameObject.GetComponent<Image>().enabled = false;
    }
}
