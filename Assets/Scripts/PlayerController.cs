using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : BaseController
{
    //private Camera camera;
    bool isJump = false;
    public float jumpTimer = 0.7f;

    bool isGrounded = true;
    Vector2 jumpPosition = Vector2.zero;

    protected override void Start()
    {
        base.Start();
        //camera = Camera.main;
        jumpTimer = 0.7f;
    }
   
    protected override void Update()
    {
        base.Update();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            isJump = true;
        }

    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();

        Vector3 velocity = _rigidbody.velocity;

        if(isJump)
        {
            Jump();
        }



        //_rigidbody.velocity = velocity;

        //float angle = Mathf.Clamp((_rigidbody.velocity.y * 10f), -90, 90);
        //float lerpAngle = Mathf.Lerp(transform.rotation.eulerAngles.z, angle, Time.fixedDeltaTime * 5f);
        //transform.rotation = Quaternion.Euler(0, 0, lerpAngle);

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

    public void Jump() 
    {
        //�߷� ����
        isGrounded = false;
        //_rigidbody.gravityScale = 13f;

        //������Ŵ
        _rigidbody.AddForce(5000f * Vector3.up);
        //Debug.Log("Jump ����");

        Invoke("JumpDown", jumpTimer);
        
        isJump = false; 
    }

    public void JumpDown()
    {
        //_rigidbody.gravityScale = 0f;
    }

}