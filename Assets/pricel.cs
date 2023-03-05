using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pricel : MonoBehaviour
{
    public float limitx1 = -2, limitx = 16f, limity1 = -1, limity = 7;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < limitx || transform.position.x > limitx1)
        {
            transform.position = new Vector3((Input.mousePosition.x * 0.013f)-5, transform.position.y, transform.position.z);
        }
        if (transform.position.x > limitx) { transform.position = new Vector3(limitx, transform.position.y, transform.position.z); }
        if (transform.position.x < limitx1) { transform.position = new Vector3(limitx1, transform.position.y, transform.position.z); }
    }
}
