using UnityEngine;
using System.Collections;

public class Obstacle : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider) //Проверка тригера
    {
        Unit unit = collider.GetComponent<Unit>(); // юнит это или нет

        if (unit && unit is Character) //Если это юнит
        {
            unit.ReceiveDamage(); //Получить урон
        }
    }
}
