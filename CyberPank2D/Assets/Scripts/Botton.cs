using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Botton : MonoBehaviour {
    public GameObject settings;

    public void NewGame()//Создаем новый метод
    {
        Application.LoadLevel(1); //Добавляем сцену Уровень 1
    }
    public void Settings()
    {
        settings.SetActive(!settings.activeSelf); //Активировать и деактивировать настройки
    }
    public void Exit()
    {
        Application.Quit(); //Выход из приложения 
    }
    public void setMusic(float value)
    {
        Global.music = value;
    }
    public void setSound (float value)
    {
        Global.sound = value;
    }
}