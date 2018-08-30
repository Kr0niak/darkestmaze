using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DarkestMaze
{
    /// <summary>
    /// Класс, представляющий все настройки в игре
    /// </summary>
    [DefaultExecutionOrder(-1)]
    public class Config : MonoBehaviour
    {
        /// <summary>
        /// Скриптуемый объект класса настроек игрока
        /// </summary>
        public PlayerConfig PlayerConfig;
        /// <summary>
        /// Скриптуемый объект класса настроек игры
        /// </summary>
        public GameConfig GameConfig;
        /// <summary>
        /// Скриптуемый объект класса настроек комнаты
        /// </summary>
        public RoomConfig RoomConfig;

        /// <summary>
        /// Единственный экземпляр класса
        /// </summary>
        public static Config Instance;

        void Awake()
        {
            DontDestroyOnLoad(gameObject);
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Debug.LogWarning("Экземпляр класса с настройками уже существует!", gameObject);
            }
        }
    }
}