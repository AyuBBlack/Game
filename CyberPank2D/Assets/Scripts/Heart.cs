using UnityEngine;
using System.Collections;

public class Heart : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        Character character = collider.GetComponent<Character>(); //Если объект коснулся
        
        if (character)
        {
            character.Lives++;// то добавлям здоровье на +1
            Destroy(gameObject); // и уничтожаем объект здоровья 
        }
    }
}
