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
        //����(Ȥ�� A)Ű�� ������ -1, ������(Ȥ�� D)Ű�� ������ 1, �ƹ��͵� �� ������ 0 ��ȯ
        float horizontal = Input.GetAxisRaw("Horizontal");

        //�Ʒ�(Ȥ�� S)Ű�� ������ -1, ��(Ȥ�� W)Ű�� ������ 1, �ƹ��͵� �� ������ 0 ��ȯ
        float vertical = Input.GetAxisRaw("Vertical");

        //��ȯ�� ���ڸ� ���� ������ ����Ѵ�.
        //normalized == ������ ũ�⸦ 1�� ����� ���⸸�� ����
        movementDirection = new Vector2(horizontal, vertical).normalized;
        //Debug.Log(movementDirection);
    }
}