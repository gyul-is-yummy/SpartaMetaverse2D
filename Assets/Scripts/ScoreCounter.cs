using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle_Hill"))
        {
            UIManager.Instance.HillCount++;
            return;
        }

        if (collision.CompareTag("Obstacle_Bridge"))
        {
            UIManager.Instance.BridgeCount++;
            return;
        }
    }
}
