using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Noise : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < -20.5f)
        {
            transform.position = new Vector2(transform.position.x, 14.5f);
        }
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x, -21f), Time.deltaTime * 12);
    }
}
