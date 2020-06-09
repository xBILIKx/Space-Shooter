using UnityEngine;

public class Background : MonoBehaviour
{
    public float speed = 0.1f; //скорость "перемотки" заднего фона
    void Update()
    {
        transform.position += new Vector3(0, -speed, 0); //происходит эта самая "перемотка"
        if (Mathf.Abs(transform.position.y) >= 20.48f + 5) //проверяем если первый спрайт заднего фона закончился (20.48 - это половина от размера спрайта по оси y, а 5 - это половина размера камеры, вычислялось вручную)
            transform.position = new Vector3(0, 15.5f, 0); //возврощаем задний фон в начальнее положение
    }
}
