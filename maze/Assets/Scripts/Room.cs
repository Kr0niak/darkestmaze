using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour {
    private float height = 1.0f, width = 1.0f, length = 1.0f; //ширина / высота /длинна комнаты
    public float x = 0.0f, y = 0.0f, z = 0.0f; //начальные координаты
    public GameObject prefab; // префаб комнаты

	public GameObject drawRoom(float x,float y, float z) // рисование комнаты
    {
          return Instantiate(Resources.Load("Room"), new Vector3(x, 0, z), Quaternion.identity) as GameObject; 
    }
}
