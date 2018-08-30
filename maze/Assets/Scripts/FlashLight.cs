using UnityEngine;
using UnityEngine.UI;

namespace DarkestMaze
{
    /// <summary>
    /// Фонарик
    /// </summary>
    public class FlashLight : MonoBehaviour
    {
        private Light _light;
        /// <summary>
        /// Время работы фонарика
        /// </summary>
        private float WorkTime = 0;
        /// <summary>
        /// Максимальное время работы фонарика
        /// </summary>
        public float MaxWorkTime = 20f;
        private float rnd;

        public Image _image;
        private Color _color;


        private void Awake()
        {
            _light = GetComponent<Light>(); 
            _color = _image.color;
        }

        private void Start()
        {
            On();
        }

        public void UpdateFlashLight(float _deltaTime)
        {
            if (WorkTime >= MaxWorkTime
            ) // если фонарик работает столько же или больше, чем максимальное время работы, то выключаем его
                Off();
            else
            {
                WorkTime += _deltaTime; // увеличиваем текщее время работы

                if (WorkTime >= MaxWorkTime - MaxWorkTime * 0.1f
                ) // если осталось 10% заряда, то фонарь начинает моргать
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

        /// <summary>
        /// Переключение фонарика
        /// </summary>
        public void Switch()
        {
            _light.enabled = !_light.enabled;
        }

        /// <summary>
        /// Включение фонарика
        /// </summary>
        public void On()
        {
            _light.enabled = true;
        }

        /// <summary>
        /// Выключение фонарика
        /// </summary>
        public void Off()
        {
            _light.enabled = false;
        }
    }
}