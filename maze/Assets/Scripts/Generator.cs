using UnityEngine;

//генератор лабиринта компонент

public class Generator : MonoBehaviour {

    public int num = 1;//номер лабиринта
    public int height = 4,width = 4; //ширина высота
    private GameObject maze; //дочерний объект
    private Room[,] rooms = new Room[4,4];//комнаты лабиринта

    public void generateMaze() //Генерация лабиринта
    {
        maze = new GameObject();
        for (int i = 0; i <= height - 1; i++)
        {
            for (int j = 0; j <= width - 1; j++)
            {
                float fX = i * height; 
                float fZ = j * width; 

                rooms[i, j] = new Room();
                rooms[i, j].x = fX;
                rooms[i, j].y = 0.0f;
                rooms[i, j].z = fZ;
                rooms[i, j].num = Random.Range(1, 10); 

                //генерируем разные комнаты
                if (rooms[i, j].num >= 1 && rooms[i, j].num <= 4)
                {
                    rooms[i, j].prefab = "Floor_A";
                }
                else if(rooms[i, j].num >=5 && rooms[i, j].num <= 9)
                {
                    rooms[i, j].prefab = "Floor_B";
                }

                //пол
                GameObject maze = objectLabirint(rooms[i, j].prefab, rooms[i, j].x, rooms[i, j].y, rooms[i, j].z, 0);

                //генерируем стены
                if (i == 0)
                {
                    GameObject wallI = objectLabirint("Wall_C", rooms[i, j].x - (0.68f * 2) - 0.4f, 0.0f, rooms[i, j].z,0);  
                }

                if (i == width - 1)
                {
                    GameObject wallI = objectLabirint("Wall_C", rooms[i, j].x + (0.68f * 2) + 0.4f, 0.0f, rooms[i, j].z, 0);
                }

                if (j == 0)
                {
                    GameObject wallJ= objectLabirint("Wall_C", rooms[i, j].x, 0.0f, rooms[i, j].z - (0.68f * 2) - 0.4f, 90);
                }

                if (j == height - 1)
                {
                    GameObject wallJ = objectLabirint("Wall_C", rooms[i, j].x, 0.0f, rooms[i, j].z + (0.68f * 2) + 0.4f, 90);
                }

                
                if (i > 0 || i < width - 1 || j == 0)
                {
                    GameObject wallV = objectLabirint("Doorway_C", rooms[i, j].x - (0.68f * 2) - 0.4f, 0.0f, rooms[i, j].z, 0);
                }

                if (j > 0 || j < height - 1 || i == 0)
                {
                    GameObject wallV = objectLabirint("Doorway_C", rooms[i, j].x, 0.0f, rooms[i, j].z - (0.68f * 2) - 0.4f, 90);
                }


            }
        }
    }
    private GameObject objectLabirint(string prefab = "",
                            float x = 0.0f,
                            float y = 0.0f,
                            float z = 0.0f,
                            int rotate = 0
                            )
    { 
        return Instantiate(Resources.Load(prefab), new Vector3(x, y, z), Quaternion.Euler(0, rotate, 0)) as GameObject;
    }



}
