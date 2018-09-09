using System.Collections;
using System.Collections.Generic;
using DarkestMaze.Interfaces;
using DarkestMaze.Services;
using UnityEngine;

namespace DarkestMaze
{
    /// <summary>
    /// Контроллер пользовательского ввода
    /// </summary>
    public class InputController : MonoBehaviour, ISubscribe
    {
        /// <summary>
        /// Флаг доступности пользовательского ввода
        /// </summary>
        public bool InputEnabled = false;

        /// <summary>
        /// Флаг доступности управления игроком
        /// </summary>
        public bool PlayerInputEnabled = true;

        private void Update()
        {
            if (!InputEnabled)
            {
                return;
            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                PlayerInputEnabled = !PlayerInputEnabled;
                Core.Instance.Notify(Notification.PausePlay, gameObject);
            }

            if (!PlayerInputEnabled)
            {
                return;
            }
        }

        public void OnNotification(Notification notification, GameObject target, params object[] data)
        {
            switch (notification)
            {
                case Notification.ResumePlay:
                    PlayerInputEnabled = true;
                    break;

                case Notification.NewGame:
                    InputEnabled = true;
                    break;
            }
        }
    }
}