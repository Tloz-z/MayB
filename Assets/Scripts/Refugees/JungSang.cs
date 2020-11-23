using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class JungSang : refugee
{

    private Animator animator;

    private bool isPass = false;
    private float passSpeed = 8f;

    private bool isOut = false;
    private float outSpeed = 5f;

    public override void Awake()
    {
        base.Awake();
        animator = GetComponent<Animator>();

        originalPos = new Vector2(0f, -1.72f);
        temperature = "36.5";
        scanablePos = -1.3f;
    }


    public override void Update()
    {
        base.Update();
        
        if(isPass)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector2(10f, transform.position.y), Time.deltaTime * passSpeed);
            if(transform.position.x >= 8f)
            {
                isPass = false;
                endMoving();
            }
        }

        if(isOut)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector2(-10f, transform.position.y), Time.deltaTime * outSpeed);
            if (transform.position.x <= -8f)
            {
                isOut = false;
                endMoving();
            }
        }
    }
    public override void OutDoor()
    {
        refugeeCol.enabled = false;
        animator.SetBool("Out", true);
        isOut = true;
    }

    public override void PassDoor()
    {
        refugeeCol.enabled = false;
        animator.SetBool("Pass", true);
        isPass = true;
    }


}
