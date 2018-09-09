using DarkestMaze.Interfaces;
using DarkestMaze.Services;
using UnityEngine;

namespace DarkestMaze
{
    /// <summary>
    /// Контроллер игрока
    /// </summary>
    public class PlayerController : MonoBehaviour, ISubscribe
    {
        /// <summary>
        /// Состояние доступности курсора
        /// </summary>
        private CursorLockMode CursorLock
        {
            get { return Cursor.lockState; }
            set { Cursor.lockState = value; }
        }

        /// <summary>
        /// Настройки игрока
        /// </summary>
        public PlayerConfig PlayerConfig { get; private set; }
        /// <summary>
        /// Текущая скорость игрока
        /// </summary>
        private float _speed;
        /// <summary>
        /// Значение фронтального перемещения игрока
        /// </summary>
        private float _transfVert;
        /// <summary>
        /// Значение бокового перемещения игрока
        /// </summary>
        private float _transfHoriz;

        /// <summary>
        /// Обновленное положение курсора
        /// </summary>
        private Vector2 _mouseLook;
        /// <summary>
        /// Ожидаемое положение курсора после сглаживания движения
        /// </summary>
        private Vector2 _vector;
        /// <summary>
        /// Ожидаемое положение курсора до сглаживания движения
        /// </summary>
        private Vector2 _rotation;
        /// <summary>
        /// Камера игрока от первого лица
        /// </summary>
        private Camera _plCamera;
        /// <summary>
        /// Игрок
        /// </summary>
        private Player _player;

        private void Start()
        {
            PlayerConfig = Config.Instance.PlayerConfig;

            CursorLock = CursorLockMode.Locked; // закрепляем курсор

            //Сначала нужно создать игрока
            var playerGameObject = GameObject.FindGameObjectWithTag("Player");
            if (playerGameObject==null)
            {
                return;
            }
            _player = playerGameObject.GetComponentInChildren<Player>();

            _plCamera = _player.GetComponentInChildren<Camera>(); // находим камеру

            _speed = PlayerConfig.NormalSpeed; // запомнили значение скорости не при беге
        }


        private void Update()
        {
            if (_player == null)
            {
                return;
            }

            _player.UpdatePlayer(Time.deltaTime);
            
            if (Input.GetKey(KeyCode.LeftShift)) // если нажали shift увеличиваем скорость
                _speed = PlayerConfig.AccelerationSpeed;
            else
                _speed = PlayerConfig
                    .NormalSpeed; // возвращаем скорость, которая была изначально, если не нажата кнопка shift

            _transfVert = Input.GetAxis("Vertical") * _speed * Time.deltaTime; // получаем значения для перемещения
            _transfHoriz = Input.GetAxis("Horizontal") * _speed * Time.deltaTime;

            _player.transform.Translate(_transfHoriz, 0, _transfVert); // перемещаем игрока


            _rotation = new Vector2(Input.GetAxisRaw("Mouse X"),
                Input.GetAxisRaw("Mouse Y")); //получаем значения с мышки

            Angle(_rotation); //  обрабатываем угол (куда должен смотреть игрок)

            _plCamera.transform.localRotation =
                Quaternion.AngleAxis(_mouseLook.y, Vector3.left); // поворачиваем камеру вниз и вверх
            _player.transform.localRotation =
                Quaternion.AngleAxis(_mouseLook.x, _player.transform.up); // поворачиваем самого игрока влево и вправо
        }

        private void Angle(Vector2 rotation)
        {
            rotation *= PlayerConfig.Sensitivity; // чувсвительность мышки
            _vector.x = Mathf.Lerp(_vector.x, rotation.x, 1f / PlayerConfig.Smoothing);
            _vector.y = Mathf.Lerp(_vector.y, rotation.y, 1f / PlayerConfig.Smoothing);

            _mouseLook += _vector;

            Mathf.Clamp(_mouseLook.y, -PlayerConfig.MaxRotationAngle, PlayerConfig.MaxRotationAngle);
        }

        public void OnNotification(Notification notification, GameObject target, params object[] data)
        {
            switch (notification)
            {
                case Notification.ResumePlay:
                    CursorLock = CursorLockMode.Locked;
                    break;

                case Notification.PausePlay:
                    CursorLock = CursorLock == CursorLockMode.Locked ?
                        CursorLockMode.None : CursorLockMode.Locked;
                    break;
            }
        }
    }
}