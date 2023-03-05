using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireMonkey : MonoBehaviour
{
    // Start is called before the first frame update
    fireAttacker attacker;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            var point = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            float x1 = gameObject.transform.position.x;
            float y1 = gameObject.transform.position.y;
            if (Mathf.Sqrt((point.x - x1) * (point.x - x1) + (point.y - y1) * (point.y - y1)) <= 0.7f)
            { 
         
            }
         }
    }
}
