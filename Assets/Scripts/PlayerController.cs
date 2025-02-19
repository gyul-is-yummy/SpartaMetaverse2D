using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum Layer
{
    Player = 3,
    Ground = 6,
    Obstacle = 7,
    Boat = 8,
}

public enum Scene
{
    Main,
    MiniGame
}

public class PlayerController : BaseController
{
    [SerializeField] private Transform weaponPivot;

    public float jumpForse = 0f;

    Scene CurrentScene;

    //private Camera camera;
    public bool isJump = false;
    public float jumpTimer = 0.7f;

    bool isGrounded = true;
    Vector2 boatVelocity = Vector2.zero;

    Collision2D boatCollision = null;

    GameObject boatObject;

    protected override void Start()
    {
        base.Start();
        //camera = Camera.main;

        boatObject = GameObject.Find("Boat");


        jumpForse = 7f;

        CurrentScene = Scene.MiniGame;
    }
   
    protected override void Update()
    {
        base.Update();

        if (Input.GetKeyDown(KeyCode.Space) && !isJump)
        {
            Jump();
        }
    }

    protected override void FixedUpdate()
    {
        if (isJump)
        {
            //transform.position.x = 
            return;
        }

        base.FixedUpdate();

        Vector3 velocity = _rigidbody.velocity;
    }

    protected override void HandleAction()
    {
        if (CurrentScene == Scene.MiniGame)
        {   
            if(isJump)
            {
                //보트와 x좌표 동기화
                transform.position = new Vector2(boatObject.transform.position.x, transform.position.y);
            }
            else
            {
                //보트와 좌표 동기화
                transform.position = new Vector2(boatObject.transform.position.x, boatObject.transform.position.y);
            }
        }

        //보트를 타고 있으면 아래 연산을 하지 않음
        if(transform.parent != null)
        {
            return;
        }

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
        isJump = true;

        //점프시킴
        _rigidbody.AddForce(jumpForse * Vector3.up, ForceMode2D.Impulse);
        _rigidbody.velocity = new Vector2(0f, _rigidbody.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == (int)Layer.Ground
            || collision.gameObject.layer == (int)Layer.Boat)
        {

            isJump = false;
        }
    }

}