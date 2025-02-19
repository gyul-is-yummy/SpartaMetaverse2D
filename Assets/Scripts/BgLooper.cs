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

            //�浹�� �ݶ��̴��� ���̸� �޾ƿͼ� ����
            widthOfBgObject = ((BoxCollider2D)(collision.collider)).size.x;
            //�浹�� �ݶ��̴��� ��ġ�� �޾ƿͼ� ����
            collsionPos = collision.transform.position;

            if (count % 2 == 0)
            {
                // �浹 ��ü�� x�� �� = ���� x�� + �浹 ��ü�� ���� * 4 ������ ����
                collsionPos.x += widthOfBgObject * numBgCount;

                //����� ���� �浹�� �ݶ��̴��� �θ��� ��ġ�� ����
                collision.transform.parent.position = collsionPos;
            }

            return;
        }
    }

    //�浹���� ��
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