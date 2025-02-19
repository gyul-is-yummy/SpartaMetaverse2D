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
        //왼쪽(혹은 A)키를 누르면 -1, 오른쪽(혹은 D)키를 누르면 1, 아무것도 안 누르면 0 반환
        float horizontal = Input.GetAxisRaw("Horizontal");

        //아래(혹은 S)키를 누르면 -1, 위(혹은 W)키를 누르면 1, 아무것도 안 누르면 0 반환
        float vertical = Input.GetAxisRaw("Vertical");

        //반환된 숫자를 벡터 값으로 사용한다.
        //normalized == 백터의 크기를 1로 만들어 방향만을 추출
        movementDirection = new Vector2(horizontal, vertical).normalized;
        //Debug.Log(movementDirection);
    }

    public void Jump() 
    {
        //중력 적용
        isGrounded = false;
        //_rigidbody.gravityScale = 13f;

        //점프시킴
        _rigidbody.AddForce(5000f * Vector3.up);
        //Debug.Log("Jump 진입");

        Invoke("JumpDown", jumpTimer);
        
        isJump = false; 
    }

    public void JumpDown()
    {
        //_rigidbody.gravityScale = 0f;
    }

}