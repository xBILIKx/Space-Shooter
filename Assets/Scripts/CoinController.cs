using UnityEngine;

public class CoinController : MonoBehaviour
{
    int price;
    private void Start()
    {
        price = PlayerPrefs.GetInt("Coins");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            PlayerPrefs.SetInt("Coins", price + 1);
            Destroy(gameObject);
        }
    }
}
