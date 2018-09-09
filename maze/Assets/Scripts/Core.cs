using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DarkestMaze.Interfaces;
using DarkestMaze.Services;
using DarkestMaze.UI;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using ISubscribe = DarkestMaze.Interfaces.ISubscribe;

namespace DarkestMaze
{
    /// <summary>
    /// Ядро программы. Основной класс в игре
    /// </summary>
    public class Core : Singleton<Core>, ISubscribe
    {
        /// <summary>
        /// Генератор лабиринта
        /// </summary>
        private Generator _maze;

        /// <summary>
        /// Флаг состояния активности игры
        /// </summary>
        public bool GameInProgress { get; private set; }

        /// <summary>
        /// Уровень сложности игры
        /// </summary>
        public DifficultyLevel DifficultyLevel { get; private set; }

        /// <summary>
        /// Список подписчиков уведомлений
        /// </summary>
        public List<ISubscribe> Subscribers { get; private set; }

        public UiController UiController { get; private set; }
        public InputController InputController { get; private set; }
        public TimeController TimeController { get; private set; }
        public PlayerController PlayerController { get; private set; }

        private void Awake()
        {
            GameInProgress = false;
            DifficultyLevel = DifficultyLevel.Easy;

            Subscribers = new List<ISubscribe> {Instance};

            UiController = gameObject.AddComponent<UiController>();
            Subscribers.Add(UiController);
            
            TimeController = gameObject.AddComponent<TimeController>();
            Subscribers.Add(TimeController);

            InputController = gameObject.AddComponent<InputController>();
            Subscribers.Add(InputController);
        }

        private void NewGameStart()
        {
            //_maze = new Generator();
            //_maze.GenerateMaze();

            PlayerController = gameObject.AddComponent<PlayerController>();
            Subscribers.Add(PlayerController);

            GameInProgress = true;
        }

        private void ResetScene()
        {
            //Логика дегенерации сцены и рестарта игры

            Subscribers.Remove(PlayerController);
            Destroy(PlayerController);
        }

        private void ResumePlay()
        {
            GameInProgress = !GameInProgress;
        }

        private void Exit()
        {
#if UNITY_EDITOR
            EditorApplication.isPlaying = false;
#else
		        Application.Quit();
#endif
        }

        /// <summary>
        /// Отправка уведомления подписчикам
        /// </summary>
        /// <param name="notification">Вид уведомления</param>
        /// <param name="target">Объект, вызывающий уведомление</param>
        /// <param name="data">Дополнительные параметры уведомления</param>
        public void Notify(Notification notification, GameObject target, params object[] data)
        {
            for (var i = 0; i < Subscribers.Count; i++)
            {
                var subscriber = Subscribers[i];
                subscriber.OnNotification(notification, target, data);
            }
        }

        public void OnNotification(Notification notification, GameObject target, params object[] data)
        {
            switch (notification)
            {
                case Notification.PausePlay:
                case Notification.ResumePlay:
                    ResumePlay();
                    break;

                case Notification.NewGame:
                    ResetScene();
                    NewGameStart();
                    break;

                case Notification.Exit:
                    Exit();
                    break;

                case Notification.ChangeGameDifficulty:
                    var index = Convert.ToInt32(data.FirstOrDefault());
                    DifficultyLevel = Config.Instance.DifficultyLevels[index];
                    break;
            }
        }
    }
}
