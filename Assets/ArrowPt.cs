using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowPt : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite GetSprite;
    Vector2 _moveDirection;
    public bool Ismoved => _ismove;
    private bool _ismove = false;
    public bool isred = false;
    public void setMoved1() { _ismove = true; }
    void Start()
    {
        InvokeRepeating("MoveToForward", 0.1f, 0.1f);
    }
    private void MoveToForward()
    {
        if (_ismove)
        {
            //transform.Translate(FindObjectOfType<pricel>().transform.position/10);
            GetComponent<Gameplay.ShipSystems.MovementSystem>().LotMove(Time.deltaTime*28.35f);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Monkey>()) { FindObjectOfType<fireAttacker>().SetScore(10); Destroy(gameObject); }
    }
}
