using UnityEngine;
using UnityEngine.UI;
public class RestartRound : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ResetRoundPowerup()
    {
        GameManager gameManager = GameObject.Find("GameController").GetComponent<GameManager>();
        gameManager.ResetGame();
        gameObject.GetComponent<Image>().enabled = false;
    }
}
