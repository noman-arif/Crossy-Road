using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public int coin = 0;
    public Text coinUI;
    public GameObject gameOver;
    public GameObject lvlPass;
    // this function will increment in coin whenever it call and update UI as well
    public void AddScore()
    {
        coin++;
        coinUI.text = "Coin: " + coin;
    }
    // this function will display Game Over UI when call
    public void GameOver()
    {
        gameOver.SetActive(true);
    }
    //this function will display Level Completed UI when call
    public void LevelCompeled()
    {
        lvlPass.SetActive(true);
    }
}
