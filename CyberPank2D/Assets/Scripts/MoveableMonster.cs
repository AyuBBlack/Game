using UnityEngine;
using System.Collections;
using System.Linq;

public class MoveableMonster : Monster
{
    [SerializeField]
    private float speed = 2.0F; //Задаем скорость

    private Vector3 direction;
    

    private SpriteRenderer sprite;

    protected override void Awake() //Переопределяем метод
    {
        sprite = GetComponentInChildren<SpriteRenderer>(); //Получение спрайта
    }

    protected override void Start() //По умолчанию направление направо 
    {
        direction = transform.right;
    }

    protected override void Update() //Вызов метода Move
    {
        Move();
    }

    protected override void OnTriggerEnter2D(Collider2D collider)
    {
        Unit unit = collider.GetComponent<Unit>();

        if (unit && unit is Character) //Если это персонаж 
        {
            if (Mathf.Abs(unit.transform.position.x - transform.position.x) < 0.3F) ReceiveDamage(); //Если растояние меньше 0,3, то игрок получает урон
            else unit.ReceiveDamage(); //персонажу нанести урон 
        }
    }

    private void Move() //Движение 
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position + transform.up * 0.5F + transform.right * direction.x * 0.5F, 0.1F); //Проверяет стоит ли рядом объект или нет

        if (colliders.Length > 0 && colliders.All(x => !x.GetComponent<Character>())) direction *= -1.0F; //Возращает тру или фолсе
        
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime); //Движение по оси
    }
}
