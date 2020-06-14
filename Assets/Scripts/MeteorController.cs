﻿using System;
using UnityEngine;

public class MeteorController : MonoBehaviour
{
    public GameObject explosion; //Взрыв
    AudioSource explosionSound;
    public float maxHP = 5; //максимально возможное количество здоровья игрока (нужна что бы в дальнейшем использовать ее в других скриптах)
    float hp; //Здоровье метеора
     private void Awake()
     {
        float scale = UnityEngine.Random.Range(0.6f, 1.5f);
        transform.localScale = new Vector3(scale, scale, 0); //даем метеору случайное значение scale(посчитал что так будет интереснее)
        explosion.transform.localScale = new Vector3(scale, scale, 0); //приравниваем scale взрыва к scale метеора
     }
    void Start()
    {
        explosionSound = AudioController.instance.meteorExplosionSound;
        hp = maxHP;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PlayerLaser" && PlayerController.instance != null)
        {
            hp -= PlayerController.instance.damage; //если в метеор попадает лазер игрока, то он теряет одно очко здоровья
            Destroy(collision.gameObject); //уничтожение лазера при поподании
            if (hp <= 0)
            {
                explosionSound.Play();
                DestroyObject();
            }
        } 
    }
    void DestroyObject()
    {
        Instantiate(explosion, transform.position, transform.rotation); //создаем эффект взрыва
        UIController.instance.ChangeScore(5);
        Destroy(this.gameObject); //если здоровье равно 0 уничтожить метеор
    }
}
