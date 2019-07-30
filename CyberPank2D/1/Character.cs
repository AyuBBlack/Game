using UnityEngine;
using System.Collections;

public class Character : Unit
{
    [SerializeField] //Количество жизней
    private int lives = 5;

    public int Lives
    {
        get { return lives; } //Обновляет количество жизней, если их меньше 5
        set
        {
           if (value < 5) lives = value;
            livesBar.Refresh();
        }
    }
    private LivesBar livesBar;

    [SerializeField]//Скорость персонажа
    private float speed = 3.0F;
    [SerializeField]//Высота прыжка
    private float jumpForce = 15.0F;

    private bool isGrounded = false;

    private Bullet bullet;

    private CharState State //Свойство 
    {
        get { return (CharState)animator.GetInteger("State"); } //Возвращает свойство игрока
        set { animator.SetInteger("State", (int)value); } //Аниматор записывает значения
    }

    new private Rigidbody2D rigidbody;
    private Animator animator;
    private SpriteRenderer sprite;

    private void Awake() //Получение ссылок на компоненты
    {
        livesBar = FindObjectOfType<LivesBar>();
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        bullet = Resources.Load<Bullet>("Bullet"); //подгружает префаб пули
    }

    private void FixedUpdate()//Проверка физики касания 
    {
        CheckGround();
    }

    private void Update() //Вызов методов
    {
        if (isGrounded) State = CharState.Idle; //Прировняем состояние персонажа на стояние
        if (Input.GetButtonDown("Fire1")) Shoot();//Если нажата левая кнопка мыши, то срелять
        if (Input.GetButton("Horizontal")) Run(); 
        if (isGrounded && Input.GetButtonDown("Jump")) Jump();//Можно прыгать когда на земле
    }

    private void Run() //Логика бега 
    {
        Vector3 direction = transform.right * Input.GetAxis("Horizontal"); //Возращает 1 и -1
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime); //Скорость умноженное на время
        sprite.flipX = direction.x < 0.0F;//Меняет сторону спрайта в зависимости от нажатой клавиши
        if (isGrounded) State = CharState.Run;
    }

    private void Jump() //Логика прыжка 
    {
        rigidbody.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
    }

    private void Shoot() //Логика стрельбы
    {
        Vector3 position = transform.position; position.y += 0.8F; //Позиция пули на 0.8 выше от точки персонажа
        Bullet newBullet = Instantiate(bullet, position, bullet.transform.rotation) as Bullet; //Локальная переменная
        newBullet.Parent = gameObject;
        newBullet.Direction = newBullet.transform.right * (sprite.flipX ? -1.0F : 1.0F);//В какую сторону лететь пуле
    }

    public override void ReceiveDamage() //Переопределение метода получения урона
    {
        Lives--; //Отнять 1 жизнь
        rigidbody.velocity = Vector3.zero; //Обнуляем ускорение при касании
        rigidbody.AddForce(transform.up * 8.0F, ForceMode2D.Impulse); //Отбрасывание персонажа при касании
        Debug.Log(lives);
    }

    private void CheckGround() //Проверка того на земли ли персонаж
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.3F); //Проверка есть ли колайдер 
        isGrounded = colliders.Length > 1; //Если колайдеров больше чем 1
        if (!isGrounded) State = CharState.Jump;
    }

    private void OnTriggerEnter2D(Collider2D collider) //Касание об объекты, которые могут нанести урон
    {

        Bullet bullet = collider.gameObject.GetComponent<Bullet>();
        if (bullet && bullet.Parent != gameObject) //если пуля не наша, то получаем урон
        {
            ReceiveDamage();
        }
    }
}


public enum CharState // Возможные состояния игрока.
{
    Idle,
    Run,
    Jump
}