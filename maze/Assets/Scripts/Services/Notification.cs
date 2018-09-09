using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DarkestMaze.Services
{
    /// <summary>
    /// Вид уведомления
    /// </summary>
    public enum Notification
    {
        /// <summary>
        /// Остановка или возобновление игры с вызовом внутриигрового меню
        /// </summary>
        PausePlay,

        /// <summary>
        /// Возобновление игрового процесса
        /// </summary>
        ResumePlay,

        /// <summary>
        /// Начало новой игры
        /// </summary>
        NewGame,

        /// <summary>
        /// Вызов меню опций
        /// </summary>
        OptionsMenu,

        /// <summary>
        /// Выход из игры
        /// </summary>
        Exit,

        /// <summary>
        /// Возврат к предыдущему меню
        /// </summary>
        BackInMenu,

        /// <summary>
        /// Изменение уровня сложности игры
        /// </summary>
        ChangeGameDifficulty
    }
}