using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioController : MonoBehaviour
{
    public static AudioController instance { get; set; }
    //public static AudioController instance 
    //{ get
    //    {
    //        if (_instance == null)
    //        {
    //            _instance = FindObjectOfType<AudioController>();
    //        }
    //        return _instance;
    //    }
    //}                                      Такой способ почему то у меня просто не работает(не смоттря на то что в интернете все говорят делать именно так, либо отдельным классом через обобщения)
    public AudioSource playerShootSound;
    public AudioSource playerDeathSound;
    public AudioSource meteorExplosionSound;
    public AudioSource enemyExplosioSound;
    public AudioSource enemyShootSound;
    public AudioSource coin;
    public AudioSource upgrade;
    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }
}
