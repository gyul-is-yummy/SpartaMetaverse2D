using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Obstacle : MonoBehaviour
{

    //자리 지정해주는 메서드 정도는 있어야 할듯

    //장애물이 2개니까 이 클래스를 부모 클래스로 만들고
    //hill이랑 bridge를 자식 클래스로 만들어도 좋을듯

    //일단 bridge를 먼저 만들어 보자 (얘는 x축 이동만 하니까)

    public float highPosY = 1f;
    public float lowPosY = -1f;

    //최소 최대 간격 설정
    public float holeSizeMin = 50f;
    public float holeSizeMax = 80f;

    public Transform topObject;
    public Transform bottomObject;

    public float widthPadding = 4f;

    public Vector3 SetRandomPlace(Vector3 lastPosition)
    {
        //간격 설정
        float widthPadding = Random.Range(holeSizeMin, holeSizeMax);

        Vector3 placePosition = lastPosition + new Vector3(widthPadding, 0);
        
        //placePosition.y = Random.Range(lowPosY, highPosY);
        
        transform.position = placePosition;
        
        return placePosition;
    }




}
