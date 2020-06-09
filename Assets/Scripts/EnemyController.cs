using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    //точно такой же скрипт стрельбы как и у игрока, манипуляция здоровьем, частицами и полетом такая же как и у метеора
    public GameObject[] boosts = new GameObject[2];
    public GameObject explosion;
    public GameObject lazer;
    public float maxHP = 6;
    public float reload = 1;
    public int score; //указываем в инспекторе количество выдаваемых очков за уничтожение врага: красный - 15 очков, зеленый - 20 очков
    float hp;
    int boostIndex;
    int chance;
    void Start()
    {
        hp = maxHP;
        boostIndex = UnityEngine.Random.Range(0, boosts.Length);
        chance = UnityEngine.Random.Range(0, 100);
        StartCoroutine(Shoot());
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PlayerLaser" && GameObject.Find("Player") != null)
        {
            hp -= FindObjectOfType<PlayerController>().damage; ;
            Destroy(collision.gameObject);
            if (hp <= 0)
            {
                Instantiate(explosion, transform.position, transform.rotation);
                FindObjectOfType<UIController>().score += score; //увеличиваем переменную score из скрипта UIController
                if (chance <= 25)
                    Instantiate(boosts[boostIndex], transform.position, transform.rotation);
                Destroy(this.gameObject);
            }
        }
    }
    IEnumerator Shoot()
    {
        while (true)
        {
            Instantiate(lazer, transform.position, transform.rotation);
            yield return new WaitForSeconds(reload);
        }
    }
}
