using UnityEngine;
using System.Collections;

public class Finish : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        Character character = collider.GetComponent<Character>(); //Если объект коснулся

        if (character)
        {
            Application.LoadLevel(0);
        }

    }
}
