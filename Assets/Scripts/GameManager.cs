using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum Scene
{
    Main,
    MiniGame
}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {  get; private set; }

    public Scene CurrentScene = Scene.Main;

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(Instance);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
