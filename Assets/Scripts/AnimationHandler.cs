using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class AnimationHandler : MonoBehaviour
{
    private static readonly int IsMoving = Animator.StringToHash("IsMoving");
    private static readonly int PlayerDirection = Animator.StringToHash("PlayerDirection");

    //확인용
    public float playerDirectionDegree = 0f;

    protected Animator animator;

    protected virtual void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }

    public void Move(Vector2 obj)
    {
        //magnitude == 벡터의 길이를 구해줌
        //obj에는 방향 벡터가 들어오므로 현재 움직이고 있는지 확인할 수 있음.
        animator.SetBool(IsMoving, obj.magnitude > .5f);
    }

    public void InvincibilityEnd()
    {
        animator.SetBool(IsMoving, false);
    }

    public void CheckDirection(Vector2 direction)
    {
        //아무 입력도 받지 않는 상태를 먼저 체크함
        if(direction == Vector2.zero)
        {
            animator.SetBool("IsVertical", true);
            animator.SetBool("IsBack", false);
            return;
        }

        //IsBack : 뒤(위)를 향하고 있는가?
        //IsLeft : 왼쪽을 향하고 있는가?
        //IsVertical : 방향이 위/아래인가?

        animator.SetBool("IsVertical", direction.x == 0);
        animator.SetBool("IsBack", direction.y > 0);
        animator.SetBool("IsLeft", direction.x < 1);

    }
}
