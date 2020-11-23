using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class refugee : MonoBehaviour
{


    public SpriteRenderer sprRen;
    protected BoxCollider2D refugeeCol;

    private bool isLoad = false;

    // 공통 정보들 각각 Start에서 초기화 필요
    protected Vector2 originalPos;
    protected string temperature;
    protected float scanablePos;

    public Vector2 getOriginalPos()
    {
        return this.originalPos;
    }

    public string getTemperature()
    {
        return this.temperature;
    }

    public float getScanablePos()
    {
        return this.scanablePos;
    }

    // Start is called before the first frame update
    public virtual void Awake()
    {
        refugeeCol = GetComponent<BoxCollider2D>();
        sprRen = GetComponent<SpriteRenderer>();
        sprRen.color = new Color(sprRen.color.r, sprRen.color.g, sprRen.color.b, 0f);
    }

    // Update is called once per frame
    public virtual void Update()
    {
        if(!isLoad)
        {
            sprRen.color = new Color(sprRen.color.r, sprRen.color.g, sprRen.color.b, sprRen.color.a + 1f * Time.deltaTime);
            if (sprRen.color.a >= 1f)
            {
                isLoad = true;
            }
        }
    }

    private void OnMouseDown()
    {
        if (isLoad)
        {
            GameObject line = GameObject.Find("LineDrawer");
            line.GetComponent<MouseLine>().startLine(this.gameObject);
        } 
    }

    protected void endMoving()
    {
        GameObject.Find("RightDoor").GetComponent<moveDoor>().closeDoor();
        GameObject.Find("LeftDoor").GetComponent<moveDoor>().closeDoor();
        GameManager.getInstance().currentRefugee = null;
        GameManager.getInstance().isPassOrOut = false;
        Destroy(this.gameObject);
    }

    public abstract void PassDoor();

    public abstract void OutDoor();
}
