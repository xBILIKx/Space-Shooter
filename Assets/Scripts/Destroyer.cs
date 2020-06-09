using UnityEngine;

public class Destroyer : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        Destroy(collision.gameObject); // уничтожение любого объекта который выходит из коллайдера(триггера)
    }
}
