using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int damage = 1;
    public GameObject lazer; //Префаб лазера
    public GameObject lazer2; //улучшенный лазер
    public GameObject lazer3;
    public GameObject explosion;
    public GameObject gameOverPanel; //панель проигрыша
    float reload = 1; // время между выстрелами
    string gunMode = "FirstGunMode"; //Строка для вызова нужного оружия
    bool sBoostActive;
    bool dBoostActive;
    private void Start()
    {
        CheckKey();
        StartCoroutine(Shoot());
    }
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition); //вычисляем положение курсора(пальца)
            if(pos.x < 1.9f || pos.y < 3.8f)
                transform.position = new Vector3(pos.x, pos.y + 1, 0); //пермещаем игрока к курсору(пальцу), условие нужно что бы когда игрок кликал на паузу, игрока не телепортировало к самому значку 
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "EnemyLaser" || collision.tag == "Asteroid" || collision.tag == "Enemy")
        {
            Instantiate(explosion, transform.position, transform.rotation);
            gameOverPanel.SetActive(true); //Активируем панель
            Destroy(this.gameObject);
            Destroy(collision.gameObject); //если в персонажа попадает вражеский лазер, или метеор(точнее если сам игрок в него попадает) уничтожаем игрока, и объект который с ним столкнулся
        }
    }

    IEnumerator Shoot()
    {
        while (true)
        {
            gameObject.SendMessage(gunMode); //вызываю метод указанный в строке
            yield return new WaitForSeconds(reload);
        }
    }

    void FirstGunMode()
    {
        Instantiate(lazer, transform.position, transform.rotation); //создание лазеров
    }

    void SecondGunMode()
    {
        Instantiate(lazer2, transform.position, transform.rotation);
    }

    void ThirdGunMode()
    {
        Instantiate(lazer3, transform.position, transform.rotation);
    }

    IEnumerator UseBoostCor(int reloadTime, string boostName)
    {
        if(boostName == "ReloadBoostSpeed" && !sBoostActive)
        {
            sBoostActive = true;
            float _reload = reload;
            reload /= 2;
            yield return new WaitForSeconds(reloadTime);
            sBoostActive = false;
            reload = _reload;
            
        }
        else if(boostName == "DamageUp" && !dBoostActive)
        {
            dBoostActive = true;
            int _damage = damage;
            damage *= 2;
            yield return new WaitForSeconds(reloadTime);
            dBoostActive = false;
            damage = _damage;
        }
    }

    public void UseBoost(int reloadTime, string boostName)
    {
        StartCoroutine(UseBoostCor(reloadTime, boostName));
    }

    void CheckKey()
    {
        if (!PlayerPrefs.HasKey("Damage") || !PlayerPrefs.HasKey("Reload") || !PlayerPrefs.HasKey("GunMode"))
        {
            PlayerPrefs.SetInt("Damage", damage);
            PlayerPrefs.SetFloat("Reload", reload);
            PlayerPrefs.SetString("GunMode", gunMode);
        }
        else
        {
            damage = PlayerPrefs.GetInt("Damage");
            reload = PlayerPrefs.GetFloat("Reload");
            gunMode = PlayerPrefs.GetString("GunMode");
        }
    }
}