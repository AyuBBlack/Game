using UnityEngine;
using System.Collections;

public class ShootableMonster : Monster
{
    [SerializeField]
    private float rate = 2.0F; //Частота стерльбы 
    [SerializeField]
    private Color bulletColor = Color.white;

    private Bullet bullet;

    protected override void Awake() //Получаем пулю
    {
        bullet = Resources.Load<Bullet>("Bullet");
    }

    protected override void Start()
    {
        InvokeRepeating("Shoot", rate, rate);
    }

    private void Shoot() //Метод стрельбы 
    {
        Vector3 position = transform.position;          position.y += 0.5F; //Поднимаем позицию
        Bullet newBullet = Instantiate(bullet, position, bullet.transform.rotation) as Bullet; //

        newBullet.Parent = gameObject;
        newBullet.Direction = -newBullet.transform.right; //Стрелят в влево из-за -
        newBullet.Color = bulletColor;
    }

    protected override void OnTriggerEnter2D(Collider2D collider) //Пероопределяем метод
    {
        Unit unit = collider.GetComponent<Unit>(); 

        if (unit && unit is Character)
        {
            if (Mathf.Abs(unit.transform.position.x - transform.position.x) < 0.3F) ReceiveDamage();
            else unit.ReceiveDamage();
        }
    }
}
