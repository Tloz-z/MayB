using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollInfo : MonoBehaviour
{
    private Vector2 mousePos;
    private bool isDrag = false;
    private bool isfixed = false;
    private bool isUp = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isfixed)
        {
            if (Input.GetMouseButton(0) && isDrag)
            {
                mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                transform.position = new Vector3(transform.position.x, Mathf.Min(5.2f, Mathf.Max(-5.8f, mousePos.y)), transform.position.z);
            }

            if (!isDrag)
            {
                GameManager.getInstance().isInfo = true;
                if (transform.position.y > 2.5f)
                {
                    transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x, 5.2f), 20f * Time.deltaTime);
                    if (Mathf.Abs(transform.position.y - 5.2f) < 0.001f)
                    {
                        isUp = false;
                        isfixed = false;
                        GameManager.getInstance().isInfo = false;
                    }
                }
                else
                {
                    transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x, -5.8f), 20f * Time.deltaTime);
                }
            }

            if (Mathf.Abs(transform.position.y + 5.8f) < 0.001f)
            {
                isfixed = true;
                GameManager.getInstance().setInfo();
            }
        }

        if(isUp)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x, 5.2f), 30f * Time.deltaTime);
            if (Mathf.Abs(transform.position.y - 5.2f) < 0.001f)
            {
                isUp = false;
                isfixed = false;
                GameManager.getInstance().isInfo = false;
            }
        }

    }

    public void ScrollUp()
    {
        isUp = true;
    }

    private void OnMouseDown()
    {
        isDrag = true;
    }

    private void OnMouseUp()
    {
        isDrag = false;
    }
}
