using UnityEngine;
using System.Collections;

public class LivesBar : MonoBehaviour
{
    private Transform[] hearts = new Transform[5]; //Массив сердечек

    private Character character;


    private void Awake()
    {
        character = FindObjectOfType<Character>();//Находит игрока

        for (int i = 0; i < hearts.Length; i++) //Цикл от нуля до hearts.Length
        {
            hearts[i] = transform.GetChild(i); //Передаем индекс сердечек
            Debug.Log(hearts[i]);
        }
    }

    public void Refresh() //Активирует нужное кол-во сердечек
    {
        for (int i = 0; i < hearts.Length; i++) 
        {
            if (i < character.Lives) hearts[i].gameObject.SetActive(true); 
            else hearts[i].gameObject.SetActive(false);
        }
    }
}
