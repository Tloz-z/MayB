using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallRefugee : MonoBehaviour
{

    private bool isLoad = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if(GameManager.getInstance().currentRefugee == null && isLoad && !GameManager.getInstance().isInfo)
        {
            StartCoroutine("callRefugee");
        }
    }

    IEnumerator callRefugee()
    {
        isLoad = false;
        GameObject backDoor = GameObject.Find("BackDoor");
        backDoor.GetComponent<moveDoor>().openDoor();
        yield return new WaitForSeconds(1f);
        GameManager.getInstance().setRefugee();
        yield return new WaitForSeconds(1f);
        backDoor.GetComponent<moveDoor>().closeDoor();
        isLoad = true;
        yield return null;
    }
}
