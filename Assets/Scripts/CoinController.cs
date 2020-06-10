using UnityEngine;

public class CoinController : MonoBehaviour
{
    int price;
    AudioSource coin;
    private void Start()
    {
        coin = FindObjectOfType<AudioController>().coin;
        price = PlayerPrefs.GetInt("Coins");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            coin.Play();
            PlayerPrefs.SetInt("Coins", price + 1);
            Destroy(gameObject);
        }
    }
}
