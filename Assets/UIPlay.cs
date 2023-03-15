using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPlay : MonoBehaviour
{
    public static bool isInvincible = false; public static float timeSpentInvincible;
    [SerializeField] UnityEngine.UI.Button play;
    [SerializeField] UnityEngine.UI.Button pause;
    [SerializeField] UnityEngine.UI.Button newgame;
    public bool setColss = false;
    public void setVisiblenewGame()
    {
        newgame.gameObject.SetActive(false);
    }
    public void setvisiblereset()
    {
        play.gameObject.SetActive(false);
        newgame.gameObject.SetActive(false);
    }
    private void Awake()
    {
        foreach(var pi in FindObjectsOfType<Gameplay.Spawners.Spawner>())
        {
            //pi.NoSpawnStart();
        }
    }
    int score = 0;
    public void NewGame()
    {
        score = 0;
        foreach (var pi in FindObjectsOfType<Gameplay.Spawners.Spawner>())
        {
            pi.StartSpawn();
        }
        foreach (var pi in FindObjectsOfType<Spawners2>())
        {
            pi.StartSpawn();
        }
        foreach (var pi in FindObjectsOfType<Road>())
        {
            pi.StSpawn();
        }
        if(setColss)FindObjectOfType<CollShip>().NewStart(); 
        isInvincible = true; newgame.gameObject.SetActive(false);
        pse = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (isInvincible)
        //{
        //    timeSpentInvincible += Time.deltaTime;

        //    if (timeSpentInvincible < 3f)
        //    {
        //        float remainder = timeSpentInvincible % .3f;
        //        GameObject.Find("Canvas").transform.Find("New Game").gameObject.SetActive(remainder > .8f);
        //    }

        //    else
        //    {
        //        GameObject.Find("Canvas").transform.Find("New Game").gameObject.SetActive(false);
        //        isInvincible = false;
        //    }
        //}
        if (!pse)
        {
           
        }
    }
    public void Pause1()
    {

        if (pse)
        {
            Time.timeScale = 1;
            //play.gameObject.SetActive(false);
            newgame.gameObject.SetActive(false);
            pse = false;
        }
        else
        {
            Time.timeScale = 0;
            pse = true;
        }
    }
    public void Resume()
    {

        Time.timeScale = 1;
        play.gameObject.SetActive(false);
        newgame.gameObject.SetActive(false);
        pse = false;
    }
    public void Reset()
    {
        foreach (var pi in FindObjectsOfType<EnemyShipController>())
        {
            Destroy(pi.gameObject);
        }
        foreach (var pi in FindObjectsOfType<Gameplay.Spawners.Spawner>())
        {
            pi.StopSpawn();
        }
        foreach (var pi in FindObjectsOfType<Spawners2>())
        {
            pi.StopSpawn();
        }
        foreach (var pi in FindObjectsOfType<Road>())
        {
            pi.StopSpawn();
        }
        Time.timeScale = 1;
        score = 0;
        foreach (var pi in FindObjectsOfType<Gameplay.Spawners.Spawner>())
        {
            pi.StartSpawn();
        }
        foreach (var pi in FindObjectsOfType<Spawners2>())
        {
            pi.StartSpawn();
        }
        foreach (var pi in FindObjectsOfType<Road>())
        {
            pi.StSpawn();
        }
        if (setColss) FindObjectOfType<CollShip>().NewStart(); isInvincible = true;
        play.gameObject.SetActive(false);
        newgame.gameObject.SetActive(false);
        //GameObject.Find("Canvas").transform.Find("New Game").gameObject.SetActive(false);
        pse = false;
    }
    public void addScore(int sc)
    {
        score += sc;
    }
    bool pse = false;
    [HideInInspector]public bool _paus => pse;
    private void OnGUI()
    {
        ScoreUI();
        if (!pse)
        {
            pause.gameObject.SetActive(true);
        }
        else
        {
            pause.gameObject.SetActive(false);
            //play.gameObject.SetActive(true);
            newgame.gameObject.SetActive(true);
        }
        var x = 10;
        x += 40;
        x += 40;
        //if (pse && GUI.Button(new Rect(x, 10, 160, 160), ""))
        //{ }
    }
    public void SetSActive()
    {
        if (FindObjectOfType<newCanvas2>() == null) { print("ret"); return; }
        if(FindObjectOfType<newCanvas2>().Scroll1.gameObject.activeSelf)FindObjectOfType<newCanvas2>().Scroll1.gameObject.SetActive(false);
        else { FindObjectOfType<newCanvas2>().Scroll1.gameObject.SetActive(true); }
    }
    public void SetSActive2()
    {
        FindObjectOfType<newCanvas2>().Scroll1.gameObject.SetActive(false);
    }
    void ScoreUI()
    {
        Rect lifeIconRect = new Rect(10, 10, 32, 32);

        GUIStyle style = new GUIStyle();
        style.fontSize = 30;
        style.fontStyle = FontStyle.Bold;
        style.normal.textColor = Color.yellow;

        Rect labelRect = new Rect(lifeIconRect.xMax + 10, lifeIconRect.y, 60, 32);
        GUI.Label(labelRect, score.ToString(), style);
    }
}
