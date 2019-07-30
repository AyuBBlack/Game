using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private float speed = 2.0F; //Скорость камеры

    [SerializeField]
    private Transform target; //За кем летит

    private void Awake() 
    {
        if (!target) target = FindObjectOfType<Character>().transform; //Если нет таргеты, то ищет на сцене активные объекты
    }

    private void Update() //Метод движение камеры
    {
        Vector3 position = target.position;         position.z = -10.0F; //позиция камеры на -10, чтобы не сливалось с 2Д
        transform.position = Vector3.Lerp(transform.position, position, speed * Time.deltaTime);
    }
}
