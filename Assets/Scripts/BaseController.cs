using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseController : MonoBehaviour
{
    protected Rigidbody2D _rigidbody;

    [SerializeField] private SpriteRenderer characterRenderer;
    [SerializeField] private Transform weaponPivot;


    protected Vector2 movementDirection = Vector2.zero; // 이동 방향
    public Vector2 MovementDirection { get { return movementDirection; }}

    protected Vector2 lookDirection = Vector2.zero;
    public Vector2 LookDirection = Vector2.zero;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
