using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject[] enemies = new GameObject[10]; //массив из "враждебных" объектов
    public float spawnReload = 1; //время между "спавном" объектов
    GameObject enemy;
    Vector3 enemyPos;
    private void Start()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        while (GameObject.Find("Player") != null)
        {
            enemy = enemies[Random.Range(0, 10)]; //берем случайного "врага" из имеющегося массива (или же монетку)
            enemyPos = new Vector3(Random.Range(-2.5f, 2.5f), transform.position.y, 0); //"спавним" его в случайное место по оси x, -2.5, 2.5 это координата от одного края камеры до другого по оси x
            Instantiate(enemy, enemyPos, enemy.transform.rotation); //иначе просто создаем врага
            yield return new WaitForSeconds(spawnReload);
        }
    }
}
