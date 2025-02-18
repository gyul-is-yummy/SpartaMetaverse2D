using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class AnimationHandler : MonoBehaviour
{
    private static readonly int IsMoving = Animator.StringToHash("IsMoving");
    private static readonly int PlayerDirection = Animator.StringToHash("PlayerDirection");

    //Ȯ�ο�
    public float playerDirectionDegree = 0f;

    protected Animator animator;

    protected virtual void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }

    public void Move(Vector2 obj)
    {
        //magnitude == ������ ���̸� ������
        //obj���� ���� ���Ͱ� �����Ƿ� ���� �����̰� �ִ��� Ȯ���� �� ����.
        animator.SetBool(IsMoving, obj.magnitude > .5f);
    }

    public void InvincibilityEnd()
    {
        animator.SetBool(IsMoving, false);
    }

    public void CheckDirection(Vector2 direction)
    {
        //�ƹ� �Էµ� ���� �ʴ� ���¸� ���� üũ��
        if(direction == Vector2.zero)
        {
            animator.SetBool("IsVertical", true);
            animator.SetBool("IsBack", false);
            return;
        }

        //IsBack : ��(��)�� ���ϰ� �ִ°�?
        //IsLeft : ������ ���ϰ� �ִ°�?
        //IsVertical : ������ ��/�Ʒ��ΰ�?

        animator.SetBool("IsVertical", direction.x == 0);
        animator.SetBool("IsBack", direction.y > 0);
        animator.SetBool("IsLeft", direction.x < 1);

    }
}
