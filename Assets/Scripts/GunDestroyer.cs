using UnityEngine;

public class GunDestroyer : MonoBehaviour
{
    void Update()
    {
        if (gameObject.transform.childCount == 0)
            Destroy(gameObject);
    }
}
