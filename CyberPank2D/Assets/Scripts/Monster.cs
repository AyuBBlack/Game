using UnityEngine;
using System.Collections;

public class Monster : Unit
{
    protected virtual void Awake() { }
    protected virtual void Start() { }
    protected virtual void Update() { }

    protected virtual void OnTriggerEnter2D(Collider2D collider)
    {
        Bullet bullet = collider.GetComponent<Bullet>(); //Если коснулся пули

        if (bullet)
        {
            ReceiveDamage(); //получаем урон
        }

        Character character = collider.GetComponent<Character>(); //Если персонаж коснулся монстра, то получает урон

        if (character)
        {
            character.ReceiveDamage();
        }
    }
}
