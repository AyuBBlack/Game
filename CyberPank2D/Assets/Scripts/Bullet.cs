using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
    private GameObject parent; //родитель
    public GameObject Parent { set { parent = value; }  get { return parent; } } //получает метод

    private float speed = 10.0F; //Скорость пули
    private Vector3 direction; //Наравление 
    public Vector3 Direction { set { direction = value; } }

    public Color Color //Цвет пули
    {
        set { sprite.color = value; } //Записывает в спрайтрендер 
    }

    private SpriteRenderer sprite;

    private void Awake() //Метод получает ссылки
    {
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    private void Start() //Уничтожение пули
    {
        Destroy(gameObject, 1.4F); //уничтожить объект через 1.4 секунды
    }
	

    private void Update() //Движение пули
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collider) //уничтожение пули при касании в юнита
    {
        Unit unit = collider.GetComponent<Unit>(); 

        if (unit && unit.gameObject != parent) //Если юнит не родитель
        {
            Destroy(gameObject);//то уничтожить объект.
        }
    }
}
