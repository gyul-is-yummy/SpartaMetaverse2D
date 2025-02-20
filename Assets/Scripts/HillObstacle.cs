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

        //만약 언덕이 보트와 충돌했다면
        if(collision.CompareTag("Boat"))
        {
            Debug.Log("언덕이 보트와 충돌");

            UIManager.Instance.GameOver();
        }
    }


}
