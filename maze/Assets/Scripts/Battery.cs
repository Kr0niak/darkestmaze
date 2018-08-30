using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DarkestMaze
{
    /// <summary>
    /// Предмет, представляющий собой батарейку для фонарика
    /// </summary>
    public class Battery : Item
    {
        /// <summary>
        /// Ёмкость заряда батарейки
        /// </summary>
        public readonly float Charge = 10.0f;
    }
}