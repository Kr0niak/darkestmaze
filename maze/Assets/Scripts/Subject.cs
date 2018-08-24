using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Subject  { // базовый предмет (думаю потом нужно модифицировать)
    public float x = 0.0f, y = 0.0f, z = 0.0f; //начальные координаты предмета
    public string name; //имя предмета
    public string prefab; //префаб

    public void createSubject(float px,float py,float pz, string pname) //создание предмета
    {
        //координаты
        x = px;
        y = py;
        z = pz;
        //название
        name = pname;
        //префаб
        prefab = "tresure_box"; //пока один префаб
    }

}
