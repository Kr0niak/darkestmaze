using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DarkestMaze
{
    /// <summary>
    /// Ядро программы. Основной класс в игре
    /// </summary>
    public class Core : MonoBehaviour
    {
        /// <summary>
        /// Единственный экземпляр класса
        /// </summary>
        public static Core Instance;
        /// <summary>
        /// Генератор лабиринта
        /// </summary>
        private Generator _maze;

        /// <summary>
        /// Номер активной в данный момент сцены
        /// </summary>
        public int ActiveSceneNumber { get; private set; }
        /* 0 - меню 
         * 1 - игра
         * 2 - рейтинг игроков
         * 3 - конец игры
         */
        /// <summary>
        /// Флаг состояния активности игры
        /// </summary>
        public bool GameInProgress { get; private set; }
        /// <summary>
        /// Скриптуемый объект класса настроек игры
        /// </summary>
        public GameConfig GameConfig { get; private set; }

        /// <summary>
        /// Загрузка сцены
        /// </summary>
        /// <param name="sceneIndex">Номер сцены в билде</param>
        public void LoadScene(int sceneIndex)
        {
            SceneManager.LoadScene(sceneIndex);
            ActiveSceneNumber = sceneIndex;
        }

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Debug.LogWarning("Экземпляр класса-ядра уже существует!", gameObject);
            }

           // GameConfig = Config.Instance.GameConfig;

            _maze = new Generator(4,4,4);
            _maze.GenerateMaze();
        }
    }
}
