using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    static UIManager instance;
    public static UIManager Instance
    {
        get { return instance; }
    }

    public Text hillCountText;
    public Text bridgeCountText;

    public GameObject gameOverUI;
    public GameObject gameUI;

    public void Awake()
    {
        instance = this;
    }

    public void Start()
    {
        gameUI = transform.Find("GameUI").gameObject;

        hillCountText = gameUI.transform.Find("HillCount").GetComponent<Text>();
        bridgeCountText = gameUI.transform.Find("BridgeCount").GetComponent<Text>();

        gameOverUI = transform.Find("GameOverUI").gameObject;


        gameUI.SetActive(true);
        gameOverUI.SetActive(false);
    }

    public void GameOver()
    {
        gameUI.SetActive(false);
        gameOverUI.SetActive(true);
        Time.timeScale = 0f;
    }


}
