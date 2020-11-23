using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AeMae : refugee
{
    public Sprite passSpr;
    public Sprite outSpr;

    private bool isPass = false;
    private float passSpeed = 8f;

    private bool isOut = false;
    private float outSpeed = 5f;

    public override void Awake()
    {
        base.Awake();

        originalPos = new Vector2(0f, -2.6f);
        temperature = "36.8";
    }

    public override void Update()
    {
        base.Update();

        if (isPass)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector2(10f, transform.position.y), Time.deltaTime * passSpeed);
            if (transform.position.x >= 8f)
            {
                isPass = false;
                endMoving();
            }
        }

        if (isOut)
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
        sprRen.sprite = outSpr;
        isOut = true;
    }

    public override void PassDoor()
    {
        refugeeCol.enabled = false;
        sprRen.sprite = passSpr;
        isPass = true;
    }


}
