using System;
using UnityEngine;

public class MeteorController : MonoBehaviour
{
    public GameObject explosion; 
    AudioSource explosionSound;
    public float maxHP = 5; 
    float hp; 
     private void Awake()
     {
        float scale = UnityEngine.Random.Range(0.6f, 1.5f);
        transform.localScale = new Vector3(scale, scale, 0); 
        explosion.transform.localScale = new Vector3(scale, scale, 0); 
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
            hp -= PlayerController.instance.damage; 
            Destroy(collision.gameObject); 
            if (hp <= 0)
            {
                explosionSound.Play();
                DestroyObject();
            }
        } 
    }
    void DestroyObject()
    {
        Instantiate(explosion, transform.position, transform.rotation); 
        UIController.instance.ChangeScore(5);
        Destroy(this.gameObject); 
    }
}
