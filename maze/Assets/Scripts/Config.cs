using System.Collections;
using System.Collections.Generic;
using DarkestMaze.Services;
using UnityEngine;

namespace DarkestMaze
{
    /// <summary>
    /// Класс, представляющий все настройки в игре
    /// </summary>
    [DefaultExecutionOrder(-1)]
    public class Config : Singleton<Config>
    {
        /// <summary>
        /// Конфигурация поведения игрока
        /// </summary>
        public PlayerConfig PlayerConfig;

        /// <summary>
        /// Конфигурация комнаты
        /// </summary>
        public RoomConfig RoomConfig;

        /// <summary>
        /// Список уровней сложности игры
        /// </summary>
        public List<DifficultyLevel> DifficultyLevels;

        /// <summary>
        /// Конфигурация главного меню игры
        /// </summary>
        public MenuConfig MainMenu;

        /// <summary>
        /// Конфигурация меню опций игры
        /// </summary>
        public MenuConfig OptionsMenu;

        /// <summary>
        /// Конфигурация меню паузы игры
        /// </summary>
        public MenuConfig PauseMenu;
    }
}