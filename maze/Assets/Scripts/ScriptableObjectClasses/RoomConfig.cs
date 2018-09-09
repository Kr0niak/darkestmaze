using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DarkestMaze
{
    /// <summary>
    /// Информация о настройках комнаты
    /// </summary>
    [CreateAssetMenu(menuName = "Config/Room")]
    public class RoomConfig : ScriptableObject
    {
        /// <summary>
        /// Высота комнаты
        /// </summary>
        public float Height = 1.0f;
        /// <summary>
        /// Ширина комнаты
        /// </summary>
        public float Width = 1.0f;
        /// <summary>
        /// Длина комнаты
        /// </summary>
        public float Length = 1.0f;
        /// <summary>
        /// Максимальное количество предметов для взаимодействия в комнате
        /// </summary>
        public int MaxItems = 5;
    }
}