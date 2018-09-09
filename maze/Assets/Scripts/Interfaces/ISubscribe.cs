using System.Collections;
using System.Collections.Generic;
using DarkestMaze.Services;
using UnityEngine;

namespace DarkestMaze.Interfaces
{
    /// <summary>
    /// Интерфейс подписчика на уведомления
    /// </summary>
    public interface ISubscribe
    {
        /// <summary>
        /// Метод, выполняемый при получении уведомления
        /// </summary>
        /// <param name="notification">Вид уведомления</param>
        /// <param name="target">Объект, вызывающий уведомление</param>
        /// <param name="data">Дополнительные параметры уведомления</param>
        void OnNotification(Notification notification, GameObject target, params object[] data);
    }
}