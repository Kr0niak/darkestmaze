using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Core : MonoBehaviour {
    //Главный класс нашей игры
    // Use this for initialization
    public int num = 1; // какая сцена грузится
    /* 0 - меню 
     * 1 - игра
     * 2 - рейтинг игроков
     * 3 - конец игры
     * */
    public Generator maze;

    public bool game = false;//статус игры

    public int complexity = 1; //сложность игры
    /*
     * 1 - легкий уровень
     * 2 - средний уровень
     * 3 - тяжелый уровень
     * */


    //Данные о пользователе будут посже
    void Start () {
        maze = new Generator();
        maze.generateMaze();
    }
	
	// Update is called once per frame
	/*void Update () {
		
	}*/

}
