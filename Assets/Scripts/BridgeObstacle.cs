using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class BridgeObstacle : MonoBehaviour
{
    //��...
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
        //    Debug.Log("�ٸ��� �÷��̾�� �浹");
        //    isCrash = false;
        //}
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //���� �ٸ��� �÷��̾�� �浹�ߴٸ�
        if(collision.gameObject.CompareTag("Player") && !player.isJump)
        {
            Debug.Log("�ٸ��� �÷��̾�� �浹");
            //isCrash = true;
            //������ ���� ������ �������� ������ �ð� ����� ������ �� ����
            //�ϴ� �׳� �ٷ� ������ �Ѱ��ֱ�
            //SceneManager.LoadScene("MainScene");
        }
    }


}
