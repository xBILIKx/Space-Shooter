using UnityEngine;

public class Background : MonoBehaviour
{
    public float speed = 0.1f; 
    void Update()
    {
        transform.position += new Vector3(0, -speed, 0);
        if (Mathf.Abs(transform.position.y) >= 20.48f + 5)
            transform.position = new Vector3(0, 15.5f, 0);
    }
}
