using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//генератор лабиринта

public class Generator : MonoBehaviour {

    public int num = 1;//номер лабиринта
    public int height = 4,width = 4; //массив комнат
    private GameObject maze; //дочерний объект
    private Room[,] rooms = new Room[4,4];//комнаты лабиринта

    public void generateMaze() //Генерация лабиринта
    {
        maze = new GameObject();
        for (int i = 0; i <= height - 1; i++)// построение поля циклом координата x
        {
            for (int j = 0; j <= width - 1; j++)//построение поля координата z
            {
                float fX = i * height; //координата клетки x
                float fZ = j * width; //координата клетки z
                rooms[i, j] = new Room();
                rooms[i, j].drawRoom(fX, 0.0f, fZ);
                //rooms[i, j].transform.parent = maze.transform;
            }
        }
    }
}
