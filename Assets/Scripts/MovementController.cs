using UnityEngine;

public class MovementController : MonoBehaviour
{
    public float speed;
    Rigidbody2D rb;
    public int vector; 
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
        rb.velocity = vector * transform.up * speed; 
    }
}
