using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public enum Layer
{
    Player = 3,
    Ground = 6,
    Obstacle = 7,
    Boat = 8,
}



public class PlayerController : BaseController
{


    [SerializeField] private Transform weaponPivot;

    public float jumpForse = 0f;

    

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
        if (GameManager.Instance.CurrentScene == Scene.MiniGame)
        {   
            if(isJump)
            {
                //��Ʈ�� x��ǥ ����ȭ
                transform.position = new Vector2(boatObject.transform.position.x, transform.position.y);
            }
            else
            {
                //��Ʈ�� ��ǥ ����ȭ
                transform.position = new Vector2(boatObject.transform.position.x, boatObject.transform.position.y);
            }
        }

        //��Ʈ�� Ÿ�� ������ �Ʒ� ������ ���� ����
        if(transform.parent != null)
        {
            return;
        }

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
        if (GameManager.Instance.CurrentScene != Scene.MiniGame) return;

        isJump = true;

        //������Ŵ
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "GameButton")
        {
            collision.transform.GetChild(0).gameObject.SetActive(false);
            collision.transform.GetChild(1).gameObject.SetActive(true);

            //MiniGameStart();

            Invoke("MiniGameStart", 1f);


        }
    }

    void MiniGameStart()
    {
        GameManager.Instance.CurrentScene = Scene.MiniGame;
        SceneManager.LoadScene("MiniGameScene"); 
    }

}