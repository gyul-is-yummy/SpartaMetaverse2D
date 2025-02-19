using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class BridgeObstacle : MonoBehaviour
{
    //하...
    private PlayerController player;
    private bool isCrash = false;

    private void Awake()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
        if (player == null)
            Debug.Log("Player NULL");
    }

    private void Start()
    {
        isCrash = false;
    }

    private void Update()
    {
        //if (isCrash && !player.isJump)
        //{
        //    Debug.Log("다리가 플레이어와 충돌");
        //    isCrash = false;
        //}
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //만약 다리가 플레이어와 충돌했다면
        if(collision.gameObject.CompareTag("Player") && !player.isJump)
        {
            Debug.Log("다리가 플레이어와 충돌");
            //isCrash = true;
            //원래는 생명 같은걸 넣으려고 했지만 시간 관계상 무리일 것 같음
            //일단 그냥 바로 씬으로 넘겨주기
            //SceneManager.LoadScene("MainScene");
        }
    }


}
