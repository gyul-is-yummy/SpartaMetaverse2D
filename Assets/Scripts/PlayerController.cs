using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : BaseController
{
    //private Camera camera;

    protected override void Start()
    {
        base.Start();
        //camera = Camera.main;
    }
   
    protected override void Update()
    {
        base.Update();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    protected override void HandleAction()
    {
        //왼쪽(혹은 A)키를 누르면 -1, 오른쪽(혹은 D)키를 누르면 1, 아무것도 안 누르면 0 반환
        float horizontal = Input.GetAxisRaw("Horizontal");

        //아래(혹은 S)키를 누르면 -1, 위(혹은 W)키를 누르면 1, 아무것도 안 누르면 0 반환
        float vertical = Input.GetAxisRaw("Vertical");

        //반환된 숫자를 벡터 값으로 사용한다.
        //normalized == 백터의 크기를 1로 만들어 방향만을 추출
        movementDirection = new Vector2(horizontal, vertical).normalized;
        //Debug.Log(movementDirection);
    }
}