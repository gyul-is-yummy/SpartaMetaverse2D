using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class BridgeObstacle : MonoBehaviour
{
    //���� �������� üũ�ϱ� ���� �޾ƿ;� ����...
    private PlayerController player;

    private void Awake()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
        if (player == null)
            Debug.Log("Player NULL");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //���� �ٸ��� �÷��̾�� �浹�ߴٸ�
        if(collision.gameObject.CompareTag("Player") && !player.isJump)
        {
            Debug.Log("�ٸ��� �÷��̾�� �浹");
            UIManager.Instance.GameOver();
        }
    }

}
