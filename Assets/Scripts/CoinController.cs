using UnityEngine;

public class CoinController : MonoBehaviour
{
    AudioSource coin;

    private void Start()
    {
        coin = AudioController.instance.coin;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            coin.Play();
            UIController.instance.ChangeCoins();
            Destroy(gameObject);
        }
    }
}
