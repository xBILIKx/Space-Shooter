using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostsController : MonoBehaviour
{
    PlayerController pc;
    public string boostName;
    public int reloadTime;
    private void Start()
    {
        try
        {
            pc = GameObject.Find("Player").GetComponent<PlayerController>();
        }
        catch { }
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
