using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monkey : MonoBehaviour
{
    public Spawners2 GetSpawner { get; internal set; }
    private float _lives = 50; int pos1, pos2;
    public float Live => _lives;
    private float amount1 = 0;
    private float amount2 = 0;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Jumping2", 0.2f, 0.2f);
        pos1 = UnityEngine.Random.Range(-1, 2);
        pos2 = UnityEngine.Random.Range(-1, 2);
        if (pos2 == 0)
        {
            pos2 = -1;
        }
        Invoke("RemoveDestroy", 13);
    }
    private void RemoveDestroy()
    {
        Destroy(gameObject);
    }
    private void MovingMonkey()
    {
        transform.Translate((transform.position + new Vector3(amount1, 0, 0)));
    }
    private void Jumping2()
    {
        pos1 = UnityEngine.Random.Range(-1, 2);
        pos2 = UnityEngine.Random.Range(-1, 2);
        if (pos2 == 0)
        {
            pos2 = -1;
        }
    }
    private void Jumping()
    {
        transform.Translate((transform.position + Vector3.up*0.6f));
    }
    public float limitx1 = -2, limitx = 16f, limity1 = -1, limity = 7;
    public GameObject RotateGO;
    bool ingredientFly = false;
    IEnumerator StartAnimateRotate(GameObject item)
    {
        //if (ingrCountTarget[i] > 0)
        //ingrCountTarget[i]--;

        ingredientFly = true;
        GameObject ingr = RotateGO.gameObject;
        AnimationCurve curveX = new AnimationCurve(new Keyframe(0, item.transform.localPosition.x), new Keyframe(0.4f, ingr.transform.position.x));
        AnimationCurve curveY = new AnimationCurve(new Keyframe(0, item.transform.localPosition.y), new Keyframe(0.5f, ingr.transform.position.y));
        curveY.AddKey(0.2f, item.transform.localPosition.y + UnityEngine.Random.Range(-2, 0.5f));
        float startTime = Time.time;
        Vector3 startPos = item.transform.localPosition;
        float speed = UnityEngine.Random.Range(0.4f, 0.6f);
        float distCovered = 0;
        while (distCovered < 0.5f && item != null)
        {
            distCovered = (Time.time - startTime) * speed;
            item.transform.localPosition = new Vector3(curveX.Evaluate(distCovered), curveY.Evaluate(distCovered), 0);
            //item.transform.Rotate(Vector3.back, Time.deltaTime * 30);
            yield return new WaitForFixedUpdate();
        }
        Destroy(item);
        ingredientFly = false;
    }
    private void JumpAnimate()
    {
        GameObject item = gameObject;
        RotateGO.transform.position = transform.position + new Vector3(UnityEngine.Random.Range(0.5f, 1f), UnityEngine.Random.Range(0.3f, 0.6f), 0);
        ingredientFly = true;
        GameObject ingr = RotateGO.gameObject;
        AnimationCurve curveX = new AnimationCurve(new Keyframe(0, item.transform.localPosition.x), new Keyframe(0.4f, ingr.transform.position.x));
        AnimationCurve curveY = new AnimationCurve(new Keyframe(0, item.transform.localPosition.y), new Keyframe(0.5f, ingr.transform.position.y));
        curveY.AddKey(0.2f, item.transform.localPosition.y + UnityEngine.Random.Range(-2, 0.5f));
        float startTime = Time.time;
        float speed = UnityEngine.Random.Range(0.4f, 0.6f);
        float distCovered = 0;
        if (distCovered < 0.5f && item != null)
        {
            distCovered = (Time.time - startTime) * speed;
            item.transform.localPosition = new Vector3(curveX.Evaluate(distCovered), curveY.Evaluate(distCovered), 0);
            //item.transform.Rotate(Vector3.back, Time.deltaTime * 30);
            //new WaitForFixedUpdate();
        }
        ingredientFly = false;
    }
    
    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0.08f * pos2, pos1*0.03f, 0));
        if (transform.position.x > limitx) { amount1 = -amount1; transform.position = new Vector3(limitx, transform.position.y, transform.position.z); }
        if (transform.position.x < limitx1) { amount1 = -amount1; transform.position = new Vector3(limitx1, transform.position.y, transform.position.z); }
        if (transform.position.y > limity) { transform.position = new Vector3(transform.position.x, limity, transform.position.z); }
        if (transform.position.y < limity1) { transform.position = new Vector3(transform.position.x, limity1, transform.position.z); }
        if (transform.position.y > -0.1f)
        {
            GetComponent<Animator>().SetBool("anim", true);
        }
        else { GetComponent<Animator>().SetBool("anim", false); }
        if (transform.position.x < -0.8f) { GetComponent<SpriteRenderer>().flipX = true; }
        else { GetComponent<SpriteRenderer>().flipX = false; }
    }

    internal void setlive(float v)
    {
        _lives = v;print(_lives);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "arrow")
        {
            Destroy(gameObject);
        }
    }
}
