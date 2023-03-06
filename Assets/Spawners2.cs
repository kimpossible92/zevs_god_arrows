using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawners2 : MonoBehaviour
{
    [SerializeField]
    private GameObject _object;
    int level = 0;
    [SerializeField]
    private Transform _parent;

    [SerializeField]
    private Vector2 _spawnPeriodRange;

    [SerializeField]
    private Vector2 _spawnDelayRange;

    [SerializeField]
    private bool _autoStart = true;
    [SerializeField]
    private Sprite[] Objects;
    [SerializeField] private int anothermovement = 0;
    public void lvlplus()
    {
        level++;
    }
    private void Start()
    {
        if (_autoStart) { FindObjectOfType<UIPlay>().setvisiblereset(); StartSpawn(); }
    }
    public void NoSpawnStart() { _autoStart = false; }

    public void StartSpawn()
    {
        StartCoroutine(Spawn());
    }

    public void StopSpawn()
    {
        StopAllCoroutines();
    }
    private IEnumerator Spawn()
    {
        yield return new WaitForSeconds(Random.Range(_spawnDelayRange.x, _spawnDelayRange.y));
        while (true)
        {
            var enem = Instantiate(_object, transform.position, transform.rotation, _parent);
            enem.GetComponent<Animator>().SetBool("level2", false);
            if (23 >= level)
            {
                //enem.transform.Find("Hull").GetComponent<SpriteRenderer>().sprite = Objects[level];
                if (level >= 8) { enem.GetComponent<Monkey>().setlive(200f); enem.GetComponent<Gameplay.ShipSystems.WeaponSystem>().setRocketOrBeam(); }
                else if (level >= 16) { enem.GetComponent<Monkey>().setlive(300f); enem.GetComponent<Gameplay.ShipSystems.WeaponSystem>().setBeam(); }
                else if (level >= 21) { enem.GetComponent<Monkey>().setlive(400f); enem.GetComponent<Gameplay.ShipSystems.WeaponSystem>().setBeam(); }
                else {
                    int prand = Random.Range(0, 3);
                    if (prand == 0) { enem.GetComponent<SpriteRenderer>().color = Color.gray; enem.GetComponent<Monkey>().setlive(200f); }
                    else if (prand == 0&&FindObjectOfType<fireAttacker>().GetScore>300) { enem.GetComponent<Animator>().SetBool("level2", true); ; enem.GetComponent<SpriteRenderer>().color = Color.gray; enem.GetComponent<Monkey>().setlive(300f); }
                    else { enem.GetComponent<Monkey>().setlive(1f); } 
                }
            }
            else { level = 0; }
            enem.GetComponent<Monkey>().GetSpawner = this;
            //if (anothermovement == 1) { enem.GetComponent<EnemyShipController>().setAnotherMovement(1); }
            //if (anothermovement == -1) { enem.GetComponent<EnemyShipController>().setAnotherMovement(-1); }
            //else { }
            yield return new WaitForSeconds(Random.Range(_spawnPeriodRange.x, _spawnPeriodRange.y));
        }
    }
}
