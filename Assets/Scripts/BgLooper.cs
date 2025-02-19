using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BgLooper : MonoBehaviour
{
    public int numBgCount = 4;
    public int obstacleCount = 0;
    public Vector3 obstacleLastPosition = Vector3.zero;

    float widthOfBgObject = 0f;
    int count = 0;
    Vector3 collsionPos = Vector3.zero;


    void Start()
    {
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == (int)Layer.Ground)
        {
            count++;

            //충돌한 콜라이더의 넓이를 받아와서 저장
            widthOfBgObject = ((BoxCollider2D)(collision.collider)).size.x;
            //충돌한 콜라이더의 위치를 받아와서 저장
            collsionPos = collision.transform.position;

            if (count % 2 == 0)
            {
                // 충돌 물체의 x축 값 = 기존 x축 + 충돌 물체의 넓이 * 4 값으로 설정
                collsionPos.x += widthOfBgObject * numBgCount;

                //계산한 값을 충돌한 콜라이더의 부모의 위치로 설정
                collision.transform.parent.position = collsionPos;
            }

            return;
        }
    }

    //충돌했을 때
    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Triggered: " + collision.name);

        if (collision.CompareTag("Obstacle"))
        {
            collsionPos = collision.transform.position;

            collsionPos.x += widthOfBgObject * numBgCount;

            collision.transform.position = collsionPos;

            return;
        }
        

    }
}