using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class BridgeObstacle : MonoBehaviour
{
    //점프 중인지를 체크하기 위해 받아와야 했음...
    private PlayerController player;

    private void Awake()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
        if (player == null)
            Debug.Log("Player NULL");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //만약 다리가 플레이어와 충돌했다면
        if(collision.gameObject.CompareTag("Player") && !player.isJump)
        {
            Debug.Log("다리가 플레이어와 충돌");
            UIManager.Instance.GameOver();
        }
    }

}
