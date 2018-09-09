using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace DarkestMaze.UI
{
    /// <summary>
    /// Абстракция элементов интерфейса меню
    /// </summary>
    public abstract class UiElementModel : UIBehaviour
    {
        /// <summary>
        /// Элемент интерфейса меню
        /// </summary>
        protected UIBehaviour UiElement;

        /// <summary>
        /// Тип элемента интерфейса меню
        /// </summary>
        public abstract Type UiElementType { get; }
    }
}