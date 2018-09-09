using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DarkestMaze.Services
{
    /// <summary>
    /// Элемент интерфеса
    /// </summary>
    [Serializable]
    public struct MenuElement
    {
        /// <summary>
        /// Название скрипта элемента интерфейса
        /// </summary>
        public string ScriptName;

        /// <summary>
        /// Название префаба элемента интерфейса
        /// </summary>
        public string PrefabName;
    }
}