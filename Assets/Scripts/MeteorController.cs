using System;
using UnityEngine;

public class MeteorController : MonoBehaviour
{
    public GameObject explosion; //Взрыв
    public ParticleSystem meteorParticle; //частицы метеора
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
        hp = maxHP;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PlayerLaser" && GameObject.Find("Player") != null)
        {
            hp -= FindObjectOfType<PlayerController>().damage; //если в метеор попадает лазер игрока, то он теряет одно очко здоровья
            Destroy(collision.gameObject); //уничтожение лазера при поподании
            if (hp > 0)
                meteorParticle.Play();
            else
                DestroyObject();
        } 
    }
    void DestroyObject()
    {
        Instantiate(explosion, transform.position, transform.rotation); //создаем эффект взрыва
        FindObjectOfType<UIController>().score += 5;
        Destroy(this.gameObject); //если здоровье равно 0 уничтожить метеор
    }
}
