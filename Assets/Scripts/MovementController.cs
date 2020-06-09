using UnityEngine;

public class MovementController : MonoBehaviour
{
    public float speed; //скорость полета
    Rigidbody2D rb;
    public int vector; //в этой переменной будет хранится направление вектора полета (-1 вниз, 1 вверх)
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
        rb.velocity = vector * transform.up * speed; //направляем объект по вектору нужному вектору, и придаем ей скорость полета
    }
}
