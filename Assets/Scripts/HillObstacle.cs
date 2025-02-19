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
            //원래는 생명 같은걸 넣으려고 했지만 시간 관계상 무리일 것 같음
            //일단 그냥 바로 씬으로 넘겨주기
            //SceneManager.LoadScene("MainScene");
        }
    }


}
