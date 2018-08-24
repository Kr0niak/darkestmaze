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
                rooms[i, j].x = fX;
                rooms[i, j].y = 0.0f;
                rooms[i, j].z = fZ;
                rooms[i, j].num = Random.Range(1, 10); 
                //генерируем разные комнаты
                Debug.Log(rooms[i, j].num.ToString());
                if (rooms[i, j].num >= 1 && rooms[i, j].num <= 4)
                        {
                            rooms[i, j].prefab = "Room";
                            //Debug.Log(rooms[i, j].prefab.ToString());
                        }
                else if(rooms[i, j].num >=5 && rooms[i, j].num <= 9)
                        {
                            rooms[i, j].prefab = "Room_1";
                            //Debug.Log(rooms[i, j].prefab.ToString());
                        }
                GameObject maze = Instantiate(Resources.Load(rooms[i, j].prefab), new Vector3(rooms[i, j].x, rooms[i, j].y, rooms[i, j].z), Quaternion.identity) as GameObject;
            }
        }
    }
}
