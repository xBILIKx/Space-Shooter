using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioController : MonoBehaviour
{
    public AudioSource playerShootSound;
    public AudioSource playerDeathSound;
    public AudioSource meteorExplosionSound;
    public AudioSource enemyExplosioSound;
    public AudioSource enemyShootSound;
    public AudioSource coin;
    public AudioSource upgrade;
    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Music");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }
}
