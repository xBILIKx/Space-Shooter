using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostsController : MonoBehaviour
{
    PlayerController pc = PlayerController.instance;
    public string boostName;
    public int reloadTime;
    private void Start()
    {
        if(GameObject.Find("Player") != null)
            pc = GameObject.Find("Player").GetComponent<PlayerController>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            pc.UseBoost(reloadTime, boostName);
            Destroy(gameObject);
        }
    }
}
