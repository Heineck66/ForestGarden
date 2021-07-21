using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSession : MonoBehaviour
{

    [SerializeField] int coinsNumber = 0;
    [SerializeField] Text coinText = null;
    [SerializeField] int playerLifes = 3;
    [SerializeField] Text lifeText = null;

    private void Awake()
    {
        var numbGameSessions = FindObjectsOfType<GameSession>().Length;
        if (numbGameSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        coinText.text = coinsNumber.ToString();
        lifeText.text = playerLifes.ToString();
    }

    public void ResetLevel()
    {
        playerLifes--;
        lifeText.text = playerLifes.ToString();

        if (playerLifes < 1)
        {
            FindObjectOfType<LevelManager>().LoadMenu();
            Destroy(gameObject);
            Debug.Log("Destroyed!");
            return;
        }

        FindObjectOfType<LevelManager>().ResetLevel();
    }

    public void AddCoin()
    {
        coinsNumber++;
        coinText.text = coinsNumber.ToString();
    }

}
