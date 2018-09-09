using System.Collections;
using System.Collections.Generic;
using DarkestMaze.Interfaces;
using DarkestMaze.Services;
using UnityEngine;

namespace DarkestMaze
{
    /// <summary>
    /// Контроллер игрового времени
    /// </summary>
    public class TimeController : MonoBehaviour, ISubscribe
    {
        private void ResumePlay()
        {
            Time.timeScale = 1f;
        }

        private void PausePlay()
        {
            Time.timeScale = 0f;
        }

        public void OnNotification(Notification notification, GameObject target, params object[] data)
        {
            switch (notification)
            {
                case Notification.ResumePlay:
                    ResumePlay();
                    break;

                case Notification.PausePlay:
                    if (Core.Instance.GameInProgress)
                    {
                        PausePlay();
                    }
                    else
                    {
                        ResumePlay();
                    }

                    break;
            }
        }
    }
}