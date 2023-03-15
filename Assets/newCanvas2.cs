using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newCanvas2 : MonoBehaviour
{
    [SerializeField]
    public UnityEngine.UI.CanvasScaler Scroll1;
    public UnityEngine.UI.CanvasScaler GetImage => Scroll1;
    // Start is called before the first frame update
    
    void Start()
    {
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
