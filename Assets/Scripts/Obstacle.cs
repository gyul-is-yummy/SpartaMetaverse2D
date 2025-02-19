using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Obstacle : MonoBehaviour
{

    //�ڸ� �������ִ� �޼��� ������ �־�� �ҵ�

    //��ֹ��� 2���ϱ� �� Ŭ������ �θ� Ŭ������ �����
    //hill�̶� bridge�� �ڽ� Ŭ������ ���� ������

    //�ϴ� bridge�� ���� ����� ���� (��� x�� �̵��� �ϴϱ�)

    public float highPosY = 1f;
    public float lowPosY = -1f;

    //�ּ� �ִ� ���� ����
    public float holeSizeMin = 50f;
    public float holeSizeMax = 80f;

    public Transform topObject;
    public Transform bottomObject;

    public float widthPadding = 4f;

    public Vector3 SetRandomPlace(Vector3 lastPosition)
    {
        //���� ����
        float widthPadding = Random.Range(holeSizeMin, holeSizeMax);

        Vector3 placePosition = lastPosition + new Vector3(widthPadding, 0);
        
        //placePosition.y = Random.Range(lowPosY, highPosY);
        
        transform.position = placePosition;
        
        return placePosition;
    }




}
