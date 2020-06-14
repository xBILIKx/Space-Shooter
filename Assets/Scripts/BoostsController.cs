using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostsController : MonoBehaviour
{
    public string boostName;
    public int reloadTime;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            PlayerController.instance.UseBoost(reloadTime, boostName);
            Destroy(gameObject);
        }
    }
}
