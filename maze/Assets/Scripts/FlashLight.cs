using UnityEngine;
using UnityEngine.UI;


public class FlashLight : MonoBehaviour
{

    private Light _light;
    private float WorkTime = 0;
    public float MaxWorkTime = 20f;
    private float rnd;

    public Image _image;
    private Color _color;


    private void Awake()
    {
        _light = GetComponent<Light>(); // берем наш фонарик
        _color = _image.color; // запоминаем цвет у батарейки
    }

    private void Start()
    {
        On(); // сразу включаем фонарик
    }

    public void UpdateFlashLight(float _deltaTime)
    {
        if (WorkTime >= MaxWorkTime) // если фонарик работает столько же или больше, чем максимальное время работы, то выключаем его
            Off();
        else
        {
            WorkTime += _deltaTime; // увеличиваем текщее время работы

            if (WorkTime >= MaxWorkTime - MaxWorkTime * 0.1f) // если осталось 10% заряда, то фонарь начинает моргать
            {
                rnd = Random.Range(0, 5);
                if (rnd < 1)
                    Switch();
                _image.color = Color.red; // меняем цвет иконки заряда на красный 
            }
            else
                _image.color = _color; // если заряд больше 10%, то цвет будет такой, как сначала
        }

        _image.fillAmount = 1 - WorkTime / MaxWorkTime; // уменьшаем заряд на картинке
    }

    public void Switch() // меняет вкл и выкл фонарика на проивоположное значение
    {
        _light.enabled = !_light.enabled;
    }

    public void On() // включает фонарик
    {
        _light.enabled = true;
    }

    public void Off() // отключает фонарик
    {
        _light.enabled = false;
    }
}
