using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newCanvas : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    [SerializeField]GameObject GetGameObject;

    public void setActive()
    {
        if (GetGameObject.activeSelf) { GetGameObject.SetActive(false); }
        else { GetGameObject.SetActive(true); }
    }
}
