﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class passDoor : MonoBehaviour, ILineEnd
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseEnter()
    {
        if(MouseLine.isDraw)
        {
            GameObject line = GameObject.Find("LineDrawer");
            line.GetComponent<MouseLine>().setTargetObj(this.gameObject);
            GameObject rightDoor = GameObject.Find("RightDoor");
            rightDoor.GetComponent<moveDoor>().openDoor();
        }
    }

    private void OnMouseExit()
    {
        if (MouseLine.isDraw)
        {
            GameObject line = GameObject.Find("LineDrawer");
            line.GetComponent<MouseLine>().setTargetObj(null);
            GameObject rightDoor = GameObject.Find("RightDoor");
            rightDoor.GetComponent<moveDoor>().closeDoor();
        }
    }

    public void LineEnd()
    {
        GameManager.getInstance().currentRefugee.GetComponent<refugee>().sprRen.sortingLayerName = "Medium";
        GameManager.getInstance().isPassOrOut = true;
        GameManager.getInstance().currentRefugee.GetComponent<refugee>().PassDoor();
    }
}
