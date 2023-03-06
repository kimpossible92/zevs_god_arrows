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
    // Start is called before the first frame update
    void Start()
    {
        arrowPt = FindObjectOfType<ArrowPt>();
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
        if (score >= 250 && LevelPl==1) { print("level:" + LevelPl); LevelPl = 2;}
    }
    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(FindObjectOfType<pricel>().transform.position.x, transform.position.y, transform.position.z);
        if (Input.GetMouseButtonDown(0))
        {
            if (!_readyToFire)
                return;
            var arrow1 = Instantiate(arrowPt, transform.position, transform.rotation);
            arrow1.setMoved1();if (LevelPl >= 2) { setNewArrow(); }
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
