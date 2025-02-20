using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    Button homeButton;
    Button gameButton;

    public void Awake()
    {
        homeButton = transform.GetChild(1).Find("HomeButton").GetComponent<Button>();
        gameButton = transform.GetChild(1).Find("GameButton").GetComponent<Button>();

        homeButton.onClick.AddListener(OnClickHomeButton);
        gameButton.onClick.AddListener(OnClickGameButton);
    }

    public void OnClickGameButton()
    {
        Time.timeScale = 1.0f;

        GameManager.Instance.CurrentScene = Scene.MiniGame;
        SceneManager.LoadScene("MiniGameScene");
    }

    public void OnClickHomeButton()
    {
        Time.timeScale = 1.0f;

        GameManager.Instance.CurrentScene = Scene.Main;
        SceneManager.LoadScene("MainScene");
    }
}
