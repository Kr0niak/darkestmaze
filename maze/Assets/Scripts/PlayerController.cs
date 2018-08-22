using UnityEngine;

public class PlayerController : MonoBehaviour {

    private float normalSpeed;
    public float speed = 10f;

    private float transfVert;  // переменные для получение значений перемещения при нажатии клавиш
    private float transfHoriz;

    private Vector2 mouseLook;
    private Vector2 vector;
    public float sesitiv = 5.0f;
    public float smoothing = 2.0f;
    private Vector2 rotation;

    private Camera plCamera;
    public float FastRun = 15f; // какая будет скорость при зажатой кнопке shift

    void Start ()
    {
        Cursor.lockState = CursorLockMode.Locked;    // закрепляем курсор
        plCamera = GetComponentInChildren<Camera>(); // находим камеру

        normalSpeed = speed; // запомнили значение скорости не при беге
	}


    void Update()
    {
        transfVert = Input.GetAxis("Vertical") * speed * Time.deltaTime;  // получаем значения для перемещения
        transfHoriz = Input.GetAxis("Horizontal") * speed * Time.deltaTime;

        transform.Translate(transfHoriz, 0, transfVert);  // перемещаем игрока


        if (Input.GetKey(KeyCode.LeftShift)) // если нажали shift увеличиваем скорость
            speed = FastRun;
        else
            speed = normalSpeed; // возвращаем скорость, которая была изначально, если не нажата кнопка shift
    

        rotation = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y")); //получаем значения с мышки

        Angle(rotation); //  обрабатываем угол (куда должен смотреть игрок)

        plCamera.transform.localRotation = Quaternion.AngleAxis(mouseLook.y, Vector3.left); // поворачиваем камеру вниз и вверх
        transform.localRotation = Quaternion.AngleAxis(mouseLook.x, transform.up); // поворачиваем самого игрока влево и вправо


        if (Input.GetKeyDown("escape"))
            Cursor.lockState = CursorLockMode.None; // курсор больше не закреплен
    }

    private void Angle(Vector2 rotation)
    {
        rotation *= sesitiv;  // чувсвительность мышки
        vector.x = Mathf.Lerp(vector.x, rotation.x, 1f / smoothing);
        vector.y = Mathf.Lerp(vector.y, rotation.y, 1f / smoothing);

        mouseLook += vector;

        if (mouseLook.y >= 50f)  // ограничения на угол
            mouseLook.y = 50f;

        if (mouseLook.y <= -50f)
            mouseLook.y = -50f;
    }

}
