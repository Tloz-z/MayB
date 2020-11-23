using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveDoor : MonoBehaviour
{
    private Vector3 originalPosition;
    private Vector3 openPosition;

    private bool isOpen = false;
    private float doorSpeed = 20f;

    // Start is cad before the first frame update
    void Start()
    {
        originalPosition = transform.position;
        openPosition = new Vector3(originalPosition.x, originalPosition.y + 8.6f, originalPosition.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (isOpen == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, originalPosition, Time.deltaTime * doorSpeed);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, openPosition, Time.deltaTime * doorSpeed);
        }
    }

    public void openDoor()
    {
        isOpen = true;
    }

    public void closeDoor()
    {
        isOpen = false;
    }
}
