using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DarkestMaze
{
    /// <summary>
    /// Объект лабиринта
    /// </summary>
    public abstract class MazeObject
    {
        /// <summary>
        /// Координаты объекта
        /// </summary>
        public float X = 0.0f, Y = 0.0f, Z = 0.0f;
        /// <summary>
        /// Имя объекта
        /// </summary>
        public string Name;
        /// <summary>
        /// Название префаба объекта
        /// </summary>
        public string Prefab;
    }
}