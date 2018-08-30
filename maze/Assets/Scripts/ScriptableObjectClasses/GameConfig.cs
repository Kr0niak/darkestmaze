using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DarkestMaze
{
    /// <summary>
    /// Обьекты этого класса хранят информацию о настройках игры
    /// </summary>
    [CreateAssetMenu(menuName = "Config/Game")]
    public class GameConfig : ScriptableObject
    {
        /// <summary>
        /// Уровень сложности игры
        /// </summary>
        public DifficultyLevel Difficulty;
    }
}