using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//генерация комнаты
public class Room : Object {
    private float height = 1.0f, width = 1.0f, length = 1.0f; //ширина / высота /длинна комнаты

    public int num = 1;// Какую комнату грузить по номерам (вроде договорились 10 комнат) пока будет 2

    public int point = 5;//сколько точек генерации предметов в комнате 

    public int generatePoint = 0; //количество гененируемых предметов

    private Subject[] subjects;

    public void generateSubject() // сколько всего предметов будет генерироваться
    {
        generatePoint = Random.Range(0, point);
    }
	public void paramRoom(float px,float py, float pz) // рисование | генерирование комнаты
    {
        subjects = new Subject[generatePoint];
        //заполняем массив данными о предметах
        for (int i = 0; i<= point-1; i++)
        {
            subjects[i].createSubject( 0, 0, 0, "Subject");
        }

    }
}
