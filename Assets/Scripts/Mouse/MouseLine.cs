using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLine : MonoBehaviour
{
    public static bool isDraw = false;

    private LineRenderer lineRend;
    private Vector2 mousePos;

    private GameObject startObj;
    private GameObject targetObj;

    // Start is called before the first frame update
    void Start()
    {
        lineRend = GetComponent<LineRenderer>();
        lineRend.positionCount = 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDraw && startObj != null)
        {

            if (Input.GetMouseButton(0))
            {
                mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                lineRend.SetPosition(0, new Vector3(startObj.transform.position.x, startObj.transform.position.y, 0f));
                if(targetObj != null)
                {
                    lineRend.SetPosition(1, new Vector3(targetObj.transform.position.x, targetObj.transform.position.y, 0f));
                } else
                {
                    lineRend.SetPosition(1, new Vector3(mousePos.x, mousePos.y, 0f));
                }
            }

            if (Input.GetMouseButtonUp(0))
            {
                if(targetObj != null)
                {
                    ILineEnd endObj = targetObj.GetComponent<ILineEnd>();
                    endObj.LineEnd();
                    targetObj = null;
                }
                lineRend.positionCount = 0;
                startObj = null;
                isDraw = false;
            }
        }
    }

    public void startLine(GameObject start)
    {
        if (GameManager.getInstance().isInfo == false)
        {
            lineRend.positionCount = 2;
            isDraw = true;
            startObj = start;
        }
    }

    public void setTargetObj(GameObject target)
    {
        this.targetObj = target;
    }
}
