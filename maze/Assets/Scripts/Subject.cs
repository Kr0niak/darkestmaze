using System.Collections;
using System.Collections.Generic;


public class Subject : Object { // базовый предмет (думаю потом нужно модифицировать)
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
