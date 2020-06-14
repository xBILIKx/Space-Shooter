using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public static Spawner instance;
    [SerializeField] GameObject[] enemies = new GameObject[10]; 
    public float spawnReload = 1;
    GameObject enemy;
    Vector3 enemyPos;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }
    private void Start()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        while (GameObject.Find("Player") != null)
        {
            enemy = enemies[Random.Range(0, 10)]; 
            enemyPos = new Vector3(Random.Range(-2.5f, 2.5f), transform.position.y, 0); 
            Instantiate(enemy, enemyPos, enemy.transform.rotation); 
            yield return new WaitForSeconds(spawnReload);
        }
    }
}
