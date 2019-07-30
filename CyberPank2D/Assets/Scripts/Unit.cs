using UnityEngine;
using System.Collections;

public class Unit : MonoBehaviour
{
    public virtual void ReceiveDamage() //Получить урон
    {
        Die();
    }

    protected virtual void Die() //Уничтожаем объект
    {
        Destroy(gameObject);
    }
}
