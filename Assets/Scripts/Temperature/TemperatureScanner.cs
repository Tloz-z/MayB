using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemperatureScanner : MonoBehaviour
{
    public GameObject laserFront;
    public GameObject laserBack;
    public GameObject scanner;

    public Sprite tem36dot5;
    public Sprite tem36dot6;
    public Sprite tem36dot8;
    public Sprite tem37dot3;

    private Vector2 mousePos;
    private SpriteRenderer scannerRen;
    private Sprite temBase;

    private bool isDrag = false;
    private bool isScan = false;


    private float dropPosition;

    // Start is called before the first frame update
    void Start()
    {
        scannerRen = scanner.GetComponent<SpriteRenderer>();
        temBase = scannerRen.sprite;

        laserFront.SetActive(false);
        laserBack.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && isDrag)
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(transform.position.x, Mathf.Min(2.3f, Mathf.Max(-4.2f, mousePos.y)), transform.position.z);
        }

        if(!isDrag)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x, 2.3f), 5f * Time.deltaTime);
            if (Mathf.Abs(transform.position.y - 2.3f) < 0.001f && !isScan)
            {
                laserFront.SetActive(false);
                laserBack.SetActive(false);
                SetScanner();
                isScan = true;
            }
        }
    }

    public void laserOff()
    {
        laserFront.SetActive(false);
        laserBack.SetActive(false);
    }

    private void OnMouseDown()
    {
        if (!GameManager.getInstance().isPassOrOut && !GameManager.getInstance().isInfo)
        {
            laserFront.SetActive(false);
            laserBack.SetActive(false);
            isDrag = true;
            isScan = false;
            scannerRen.sprite = temBase;
        }
    }

    private void OnMouseUp()
    {
        if (!GameManager.getInstance().isPassOrOut && !GameManager.getInstance().isInfo && isDrag)
        {
            laserFront.SetActive(true);
            laserBack.SetActive(true);
            isDrag = false;
            dropPosition = transform.position.y;
        }
    }

    private void SetScanner()
    {
        GameObject currentRefugee = GameManager.getInstance().currentRefugee;
        if(currentRefugee == null)
        {
            return;
        }

        if(currentRefugee.GetComponent<refugee>().getScanablePos() < dropPosition)
        {
            return;
        }

        switch (currentRefugee.GetComponent<refugee>().getTemperature())
        {
            case "36.5":
                scannerRen.sprite = tem36dot5;
                break;
            case "36.6":
                scannerRen.sprite = tem36dot6;
                break;
            case "36.8":
                scannerRen.sprite = tem36dot8;
                break;
            case "37.3":
                scannerRen.sprite = tem37dot3;
                break;
            default:
                scannerRen.sprite = temBase;
                break;
        }
    }
}
