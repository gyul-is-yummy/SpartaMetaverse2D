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

    //스코어 카운터에서 hillCount를 만든다면 여기는 필요 없음
    //나중에 시간이 된다면 수정할 것

    public Text hillCountText;
    public Text bridgeCountText;

    public Text resultHillCountText;
    public Text resultBridgeCountText;

    public Text bestHillCountText;
    public Text bestBridgeCountText;

    private int hillCount;
    public int HillCount
    {
        get { return hillCount; }
        set
        {
            hillCount = value;
            hillCountText.text = $"{hillCount}";
            resultHillCountText.text = $"{hillCount}";
        }
    }

    private int bridgeCount;
    public int BridgeCount
    {
        get { return bridgeCount; }
        set
        {
            bridgeCount = value;
            bridgeCountText.text = $"{bridgeCount}";
            resultBridgeCountText.text = $"{bridgeCount}";
        }
    }

    public int bestHillCount;
    public int bestBridgeCount;

    private const string BEST_HILL_COUNT_KEY = "BestHillCount";
    private const string BEST_BRIDGE_COUNT_KEY = "BestBridgeCount";

    public GameObject gameOverUI;
    public GameObject gameUI;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        gameUI = transform.Find("GameUI").gameObject;

        hillCountText = gameUI.transform.Find("HillCount").GetComponent<Text>();
        bridgeCountText = gameUI.transform.Find("BridgeCount").GetComponent<Text>();

        gameOverUI = transform.Find("GameOverUI").gameObject;

        resultHillCountText = gameOverUI.transform.GetChild(2).Find("HillCount").GetComponent<Text>();
        resultBridgeCountText = gameOverUI.transform.GetChild(2).Find("BridgeCount").GetComponent<Text>();

        bestHillCountText = gameOverUI.transform.GetChild(2).Find("RecordHillCount").GetComponent<Text>();
        bestBridgeCountText = gameOverUI.transform.GetChild(2).Find("RecordBridgeCount").GetComponent<Text>();

        bestHillCount = PlayerPrefs.GetInt(BEST_HILL_COUNT_KEY, 0);
        bestBridgeCount = PlayerPrefs.GetInt(BEST_BRIDGE_COUNT_KEY, 0);

        gameUI.SetActive(true);
        gameOverUI.SetActive(false);
    }

    public void GameOver()
    {
        if (bestHillCount < hillCount
            && bestBridgeCount < bridgeCount) UpdateScore();

        bestHillCountText.text = $"{bestHillCount}";
        bestBridgeCountText.text = $"{bestBridgeCount}";

        gameUI.SetActive(false);
        gameOverUI.SetActive(true);
        Time.timeScale = 0f;

    }

    public void UpdateScore()
    {
        //최고기록을 경신 했을 때만 이 메서드를 실행.
        if (bestHillCount < hillCount && bestBridgeCount < bridgeCount)
        {
            bestHillCount = hillCount;
            bestBridgeCount = bridgeCount;

            PlayerPrefs.SetInt(BEST_HILL_COUNT_KEY, bestHillCount);
            PlayerPrefs.SetInt(BEST_BRIDGE_COUNT_KEY, bestBridgeCount);
        }
    }


}
