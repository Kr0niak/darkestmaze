using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Core : MonoBehaviour {
    //Главный класс нашей игры
    // Use this for initialization
    public int num = 1; // какая сцена грузится
    public Generator maze;
    //Данные о пользователе будут посже
	void Start () {
        maze = new Generator();
        maze.generateMaze();
    }
	
	// Update is called once per frame
	/*void Update () {
		
	}*/

}
