using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatController : BaseController
{
    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
    }


    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        Vector3 velocity = _rigidbody.velocity;
    }

    protected override void HandleAction()
    {
        //float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        movementDirection = new Vector2(1f, vertical).normalized;
    }


}
