using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireAttacker : MonoBehaviour
{
    private Vector3 _arrowpos;
    private int LevelPl = 1;
    public Vector3 arrowPosition => _arrowpos;
    public ArrowPt arrowPt;
    [SerializeField] private float _cooldown;
    [SerializeField] GameObject ObjectPricel; private bool _readyToFire = true;
    private int _time_plus;
    public int timed => _time_plus;
    public List<ArrowPt> arrowPts;
    [SerializeField]UnityEngine.UI.Text GetTextTimed;
    public int LevelPl2 = 0;
    [SerializeField] Texture2D[] GetTexture2Ds;
    [SerializeField] GameObject[] LevelGos;

    private void SetTime()
    {
        if (_time_plus >= 59)
        {
            if (!FindObjectOfType<UIPlay>()._paus) {  FindObjectOfType<UIPlay>().Pause1(); }
            if(LevelPl2<=4)LevelPl2++;
            foreach (var canv in LevelGos)
            {
                canv.gameObject.SetActive(false);
            }
            if(LevelPl2 <= LevelGos.Length-1)LevelGos[LevelPl2].gameObject.SetActive(true);
            _time_plus = 0;
        }
        if(!FindObjectOfType<UIPlay>()._paus) _time_plus++;
    }
    void Start()
    {
        arrowPt = FindObjectOfType<ArrowPt>();
        if(!arrowPts.Contains(arrowPt))
        {
            arrowPts.Add(arrowPt);
        }
        InvokeRepeating("SetTime", 1f, 1f);
    }
    private IEnumerator Reload(float cooldown)
    {
        _readyToFire = false;
        yield return new WaitForSeconds(cooldown);
        _readyToFire = true;
    }
    public int GetScore => score;
    int score = 0;
    [SerializeField]UnityEngine.UI.Text GetText;
    public void SetScore(int sc)
    {
        score += sc;
        GetText.text = "Score:" + score.ToString();
        if (score >= 250 && LevelPl==1) { print("level: " + LevelPl); LevelPl = 2;}
    }
    private void OnGUI()
    {
        if(LevelPl2 < GetTexture2Ds.Length) GUI.Label(new Rect(25, 10, 120, 120), GetTexture2Ds[LevelPl2]);
        //foreach (var canv in LevelGos) 
        //{ 
        //    if(canv!=LevelGos[LevelPl2]) canv.gameObject.SetActive(false);
        //    else { canv.gameObject.SetActive(true); }
        //}
        //if (LevelPl2 < LevelGos.Length && LevelGos[LevelPl2]!=null) { LevelGos[LevelPl2].SetActive(true); }
    }
    bool _canTouch = false;
    void Update()
    {
        
        GetTextTimed.text = _time_plus.ToString();
        transform.position = new Vector3(FindObjectOfType<pricel>().transform.position.x, transform.position.y, transform.position.z);
        if (Input.GetMouseButtonDown(0))
        {
            _canTouch = true;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            _canTouch = false;
        }
        if (_canTouch) {
            if (!_readyToFire)
                return;
            int point1 = Random.Range(0, FindObjectOfType<FBInitial>().itemList.Count); print(point1);
            arrowPt = FindObjectOfType<FBInitial>().Arrows[point1];
            var arrow1 = Instantiate(arrowPt, transform.position, transform.rotation);
            arrow1.setMoved1(); if (LevelPl >= 2) { setNewArrow(); }
            StartCoroutine(Reload(_cooldown));
        }
    }
    public void setNewArrow()
    {
        var arrow1 = Instantiate(arrowPt, transform.position+Vector3.left, transform.rotation);
        arrow1.setMoved1();
    }
    public void setOldRotation()
    {
        var point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var hit2 = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector3.forward);
        if (hit2.collider != null)
        {
            //point = hit2.collider.transform.position;
        }
        //print(point);
        //arrowPt.transform = new Quaternion(0, 0, -50 + point.x * 16.67f, 0);
        if (Input.GetMouseButtonDown(0))
        {
            int point1 = Random.Range(0, FindObjectOfType<FBInitial>().itemList.Count);print(point1);
            arrowPt = FindObjectOfType<FBInitial>().Arrows[point1];
            var arrow1 = Instantiate(arrowPt, transform.position, transform.rotation);
            if (arrow1 != null) _arrowpos = arrow1.transform.position;
            arrow1.setMoved1();
            //ObjectPricel.transform.position = point;
        }
        transform.LookAt(FindObjectOfType<pricel>().transform.position);
    }
    float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }
}
