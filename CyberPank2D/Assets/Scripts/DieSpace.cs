using UnityEngine;

public class DieSpace : MonoBehaviour {

    public GameObject respawn;
    private void OnTriggerEnter2D(Collider2D collider)
    {
        Character character = collider.GetComponent<Character>(); //Если объект коснулся колайдера
        if (character) 
        {
            character.transform.position = respawn.transform.position; //Меняем позицию на указанную в респавн
            character.Lives--;// -1 жизнь
        }
    }
}
