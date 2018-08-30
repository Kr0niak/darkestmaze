using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DarkestMaze
{
    /// <summary>
    /// Предмет взаимодействия
    /// </summary>
    public class Item : MazeObject
    {
        /// <summary>
        /// Высота предмета
        /// </summary>
        public float Height;
        /// <summary>
        /// Ширина предмета
        /// </summary>
        public float Width;
        /// <summary>
        /// Длина предмета
        /// </summary>
        public float Length;
    }
}