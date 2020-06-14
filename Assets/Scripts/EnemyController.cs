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
    AudioSource explosioSound;
    AudioSource shootSound;
    public float maxHP = 6;
    public float reload = 1;
    public int score; //указываем в инспекторе количество выдаваемых очков за уничтожение врага: красный - 15 очков, зеленый - 20 очков
    float hp;
    int boostIndex;
    //int chance;
    void Start()
    {
        explosioSound = AudioController.instance.enemyExplosioSound;
        shootSound = AudioController.instance.enemyShootSound;
        hp = maxHP;
        boostIndex = UnityEngine.Random.Range(0, boosts.Length);
        //chance = UnityEngine.Random.Range(0, 100);
        StartCoroutine(Shoot());
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PlayerLaser" && PlayerController.instance != null)
        {
            hp -= PlayerController.instance.damage;
            Destroy(collision.gameObject);
            if (hp <= 0)
            {
                Instantiate(explosion, transform.position, transform.rotation);
                UIController.instance.ChangeScore(score); //увеличиваем переменную score из скрипта UIController
                if (UnityEngine.Random.Range(0, 100) <= 25)
                    Instantiate(boosts[boostIndex], transform.position, transform.rotation);
                explosioSound.Play();
                Destroy(this.gameObject);
            }
        }
    }
    IEnumerator Shoot()
    {
        while (true)
        {
            Instantiate(lazer, transform.position, transform.rotation);
            shootSound.Play();
            yield return new WaitForSeconds(reload);
        }
    }
}
