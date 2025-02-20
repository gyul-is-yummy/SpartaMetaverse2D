using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class HillObstacle : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);

        //���� ����� ��Ʈ�� �浹�ߴٸ�
        if(collision.CompareTag("Boat"))
        {
            Debug.Log("����� ��Ʈ�� �浹");

            UIManager.Instance.GameOver();
        }
    }


}
